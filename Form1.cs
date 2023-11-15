using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using WMPLib;
using SharpDX.Multimedia;
using SharpDX.DirectSound;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Media;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Windows.Forms.VisualStyles;
using static UP___Karta.Player;
using System.Runtime.InteropServices.ComTypes;
using System.Threading;
using static System.Windows.Forms.CheckedListBox;

namespace UP___Karta
{
    public partial class Karta_Dzwiekowa : Form
    {
        private Player player = new Player();
        public Karta_Dzwiekowa()
        {
            InitializeComponent();
            comboBoxPlayMethod.SelectedIndex = 0;
            player.SetDirectCooperative(this.Handle);
        }

        private void Karta_Dzwiekowa_Load(object sender, EventArgs e)
        {

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            player.Play();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            player.SetFilePath(textBox1.Text);
        }

        private void comboBoxPlayMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            player.SetPlayMethod((string)comboBoxPlayMethod.SelectedItem);
        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            var dialog1 = new OpenFileDialog();

            dialog1.Title = "Wybierz plik do odtworzenia";
            dialog1.InitialDirectory = @"c:\";
            dialog1.Filter = "Wav Files (*.wav)|*.wav";
            dialog1.FilterIndex = 2;
            dialog1.RestoreDirectory = true;

            if (dialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = dialog1.FileName;
                player.SetFilePath(dialog1.FileName);
            }
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            player.Pause();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            player.Stop();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckedItemCollection a = checkedListBox1.CheckedItems;
            string[] s = new string[a.Count];
            a.CopyTo(s, 0);
            player.SetEqualizerSettings(s);
        }

        private void buttonRecord_Click(object sender, EventArgs e)
        {
            if (player.IsRecording())
            {
                player.StopRecord();
                textBoxRecording.Text = "";
            }                
            else
            {
                player.Record();
                textBoxRecording.Text = "Nagrywanie w toku!";
            }                
        }
    }

    public struct MCI_Data
    {
        public StringBuilder msg;  // MCI Error message
        public StringBuilder returnData;  // MCI return data
        public int error;
        public string Pcommand;  // String that holds the MCI command
        public bool Paused { get; set; }
    }
    public class Player
    {
        // https://learn.microsoft.com/pl-pl/dotnet/csharp/advanced-topics/interop/how-to-use-platform-invoke-to-play-a-wave-file

        [DllImport("winmm.DLL", EntryPoint = "PlaySound", SetLastError = true, CharSet = CharSet.Unicode, ThrowOnUnmappableChar = true)]
        private static extern bool PlaySound(string szSound, System.IntPtr hMod, PlaySoundFlags flags);

        [System.Flags]
        public enum PlaySoundFlags : int
        {
            SND_SYNC = 0x0000,
            SND_ASYNC = 0x0001,
            SND_NODEFAULT = 0x0002,
            SND_LOOP = 0x0008,
            SND_NOSTOP = 0x0010,
            SND_NOWAIT = 0x00002000,
            SND_FILENAME = 0x00020000,
            SND_RESOURCE = 0x00040004
        }

        // https://www.codeproject.com/Articles/63094/Simple-MCI-Player
        [DllImport("winmm.dll")]
        private static extern int mciSendString(string strCommand,
        StringBuilder strReturn, int iReturnLength, IntPtr hwndCallback);
        [DllImport("winmm.dll")]
        public static extern int mciGetErrorString(int errCode,
                      StringBuilder errMsg, int buflen);

        MCI_Data mci_data;

        // https://learn.microsoft.com/pl-pl/windows/win32/wmp/creating-the-windows-media-player-control-programmatically
        WMPLib.WindowsMediaPlayer PlayerWMP;
        
        // https://www.codeproject.com/Articles/866347/Streaming-Audio-to-the-WaveOut-Device
        
        [DllImport("winmm.dll")]
        public static extern int waveOutOpen(out IntPtr hWaveOut, int uDeviceID, ref WAVEFORMAT lpFormat, IntPtr dwCallback, IntPtr dwInstance, int dwFlags);
        [DllImport("winmm.dll")]
        public static extern int waveOutReset(IntPtr hWaveOut);
        [DllImport("winmm.dll")]
        public static extern int waveOutRestart(IntPtr hWaveOut);
        [DllImport("winmm.dll")]
        public static extern int waveOutPrepareHeader(IntPtr hWaveOut, ref WaveHdr lpWaveOutHdr, int uSize);
        [DllImport("winmm.dll")]
        public static extern int waveOutWrite(IntPtr hWaveOut, ref WaveHdr lpWaveOutHdr, int uSize);
        [DllImport("winmm.dll")]
        public static extern int waveOutClose(IntPtr hWaveOut);

        [StructLayout(LayoutKind.Sequential)]
        public struct WaveHdr
        {
            public IntPtr lpData;                                                       // pointer to locked data buffer
            public int dwBufferLength;                                                  // length of data buffer
            public int dwBytesRecorded;                                                 // used for input only
            public IntPtr dwUser;                                                       // for client's use
            public int dwFlags;                                                         // assorted flags (see defines)
            public int dwLoops;                                                         // loop control counter
            public IntPtr lpNext;                                                       // PWaveHdr, reserved for driver
            public int reserved;                                                        // reserved for driver
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct WAVEFORMAT
        {
            public short wFormatTag;                                                       // pointer to locked data buffer
            public short nChannels;                                                  // length of data buffer
            public int nSamplesPerSec;                                                 // used for input only
            public int nAvgBytesPerSec;                                                       // for client's use
            public short nBlockAllign;                                                         // assorted flags (see defines)
            public short wBitsPerSample;                                                         // loop control counter
            public short cbSize;                                                       // PWaveHdr, reserved for driver
        }

        public const int CALLBACK_FUNCTION = 0x00030000;                                // flag used if we require a callback when audio frames are completed
        public const int CALLBACK_NULL = 0x00000000;                                    // flag used if no callback is required
        public const int BUFFER_DONE = 0x3BD;

        public delegate void WaveDelegate(IntPtr dev, int uMsg, int dwUser, int dwParam1, int dwParam2);
        private WaveDelegate woDone = new WaveDelegate(WaveOutDone);

        DirectSound directSound = new DirectSound();
        SecondarySoundBuffer soundBuffer;
        private int directCurrentPosition = 0;
        private bool isPlaying = false;
        private bool isRecording = false;
        private bool isPaused = false;

        private string playMethod = "PlaySound",
            filePath = "";

        public Player()
        {
            mci_data.returnData = new StringBuilder("");
        }
        public void Play()
        {
            if (filePath == "")
            {
                MessageBox.Show("Nie wybrano pliku!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (isPlaying) return;

            isPlaying = true;

            switch (playMethod)
            {
                case "PlaySound":
                    PlaySound(filePath, new IntPtr(), PlaySoundFlags.SND_SYNC);
                    break;
                case "Windows Media Player":
                    PlayWMP(filePath);
                    // playMethod = "Windows Media Player";
                    break;
                case "WaveOutWrite":
                    PlayWaveOutWrite();
                    break;
                case "MCI":
                    PlayMCI();
                    // playMethod = "MCI";
                    break;
                case "DirectSound":
                    PlayDirect();
                    // playMethod = "DirectSound";
                    break;
            }
        }
        public void Stop()
        {
            isPlaying = false;
            switch (playMethod)
            {
                case "PlaySound":
                    PlaySound(null, new IntPtr(), PlaySoundFlags.SND_SYNC);
                    break;
                case "Windows Media Player":
                    if (PlayerWMP == null) return;
                    PlayerWMP.controls.stop();
                    break;
                case "WaveOutWrite":
                    StopWaveOutWrite();
                    break;
                case "MCI":
                    StopMCI();
                    break;
                case "DirectSound":
                    StopDirect();
                    break;
            }
        }
        
        public void Pause()
        {
            switch (playMethod)
            {
                case "PlaySound":
                    PlaySound(null, new IntPtr(), PlaySoundFlags.SND_SYNC);
                    break;
                case "Windows Media Player":
                    if (PlayerWMP == null) return;

                    // jesli gra
                    if (PlayerWMP.playState == (WMPLib.WMPPlayState)3)
                    {
                        PlayerWMP.controls.pause();
                    }
                    // paused
                    else if (PlayerWMP.playState == (WMPLib.WMPPlayState)2)
                    {
                        PlayerWMP.controls.play();
                    }
                    break;
                case "WaveOutWrite":
                    // playMethod = "WaveOutWrite";
                    break;
                case "MCI":
                    PauseMCI();
                    break;
                case "DirectSound":
                    PauseDirect();
                    break;
            }
        }

        public void Record()
        {
            isRecording = true;

            mciSendString("open new type waveaudio alias wavfile", null, 0, IntPtr.Zero);
            mciSendString("record wavfile", null, 0, IntPtr.Zero);
        }

        public void StopRecord()
        {
            if (filePath == "")
            {
                filePath = "test.wav";
                mci_data.Pcommand = "save wavfile test.wav";
            }
            else
            {
                MessageBox.Show(filePath, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mci_data.Pcommand = "save wavfile " + filePath + ".wav";
                filePath += ".wav";
            }            

            mci_data.error = mciSendString(mci_data.Pcommand, null, 0, IntPtr.Zero);
            if (mci_data.error != 0)
            {
                return;
            }
            mciSendString("close wavfile", null, 0, IntPtr.Zero);
            isRecording = false;
        }
        public void SetPlayMethod(string playMethod)
        {
            this.playMethod = playMethod;
        }

        public void SetFilePath(string filePath)
        {
            this.filePath = filePath;
        }

        public bool IsRecording()
        {
            return isRecording;
        }

        public void CloseMCI()
        {
            mci_data.Pcommand = "close MediaFile";
            mciSendString(mci_data.Pcommand, null, 0, IntPtr.Zero);
        }
        public bool OpenMCI(string sFileName)
        {
            CloseMCI();
            // Try to open as mpegvideo 
            mci_data.Pcommand = "open \"" + sFileName +
                       "\" type mpegvideo alias MediaFile";
            mci_data.error = mciSendString(mci_data.Pcommand, null, 0, IntPtr.Zero);
            // nie otworzyło
            if (mci_data.error != 0)
            {
                // Let MCI deside which file type the song is
                mci_data.Pcommand = "open \"" + sFileName +
                           "\" alias MediaFile";
                mci_data.error = mciSendString(mci_data.Pcommand, null, 0, IntPtr.Zero);
                if (mci_data.error == 0)
                    return true;
                else
                    return false;
            }
            else
                return true;
        }

        public bool PlayMCI()
        {
            if (OpenMCI(this.filePath))
            {
                mci_data.Pcommand = "play MediaFile";
                mci_data.error = mciSendString(mci_data.Pcommand, null, 0, IntPtr.Zero);
                if (mci_data.error == 0)
                {
                    return true;
                }
                else
                {
                    CloseMCI();
                    return false;
                }
            }
            else
                return false;
        }

        public void PauseMCI()
        {
            if (mci_data.Paused)
            {
                ResumeMCI();
                mci_data.Paused = false;
            }
            else if (IsPlayingMCI())
            {
                mci_data.Pcommand = "pause MediaFile";
                mci_data.error = mciSendString(mci_data.Pcommand, null, 0, IntPtr.Zero);
                mci_data.Paused = true;
            }
        }

        private void StopMCI()
        {
            mci_data.Pcommand = "stop MediaFile";
            mci_data.error = mciSendString(mci_data.Pcommand, null, 0, IntPtr.Zero);
            mci_data.Paused = false;
            CloseMCI();
        }

        private void ResumeMCI()
        {
            mci_data.Pcommand = "resume MediaFile";
            mci_data.error = mciSendString(mci_data.Pcommand, null, 0, IntPtr.Zero);
        }

        private bool IsPlayingMCI()
        {
            mci_data.Pcommand = "status MediaFile mode";
            mci_data.error = mciSendString(mci_data.Pcommand, mci_data.returnData, 128, IntPtr.Zero);
            if (mci_data.returnData.Length == 7 &&
                    mci_data.returnData.ToString().Substring(0, 7) == "playing")
                return true;
            else
                return false;
        }
        private void PlayWMP(String url)
        {
            PlayerWMP = new WMPLib.WindowsMediaPlayer();
            PlayerWMP.PlayStateChange +=
                new WMPLib._WMPOCXEvents_PlayStateChangeEventHandler(Player_PlayStateChange);
            PlayerWMP.MediaError +=
                new WMPLib._WMPOCXEvents_MediaErrorEventHandler(Player_MediaError);
            PlayerWMP.URL = url;
            PlayerWMP.controls.play();
        }

        private void Player_PlayStateChange(int NewState)
        {
            switch ((WMPLib.WMPPlayState)NewState)
            {
                case WMPLib.WMPPlayState.wmppsStopped:
                    PlayerWMP.close();
                    break;
                case WMPLib.WMPPlayState.wmppsPaused:
                    break;
            }
        }

        private void Player_MediaError(object pMediaObject)
        {
            MessageBox.Show("Cannot play media file.");
            // this.Close();
        }

        public void SetDirectCooperative(IntPtr handle)
        {
            directSound.SetCooperativeLevel(handle, CooperativeLevel.Priority);
        }

        // Example equalization settings
        private Guid[] eq;
        public static readonly Guid StandardFlanger = new Guid("efca3d92-dfd8-4672-a603-7420894bad98");
        public static readonly Guid StandardChorus = new Guid("efe6629c-81f7-4281-bd91-c9d604a95af6");
        public static readonly Guid StandardCompressor = new Guid("ef011f79-4000-406d-87af-bffb3fc39d57");
        public static readonly Guid StandardI3DL2REVERB = new Guid("ef985e71-d5c7-42d4-ba4d-2d073e2e96f4");
        public static readonly Guid WavesReverb = new Guid("87fc0268-9a55-4360-95aa-004a1d9de26c");
        public static readonly Guid StandardGargle = new Guid("dafd8210-5711-4b91-9fe3-f75b7ae279bf");
        public static readonly Guid StandardEcho = new Guid("ef3e932c-d40b-4f51-8ccf-3f98f1b29d5d");
        public static readonly Guid StandardParameq = new Guid("120ced89-3bf4-4173-a132-3cb406cf3231");
        public static readonly Guid StandardDistortion = new Guid("ef114c90-cd1d-484e-96e5-09cfaf912a21");
        public void SetEqualizerSettings(string[] effectsType)
        {
            Guid[] outputGuid = new Guid[effectsType.Length];

            for (int i = 0; i < effectsType.Length; i++) 
            {
                switch (effectsType[i])
                {
                    case "Flanger":
                        outputGuid[i] = StandardFlanger;
                        break;
                    case "Chorus":
                        outputGuid[i] = StandardChorus;
                        break;
                    case "Compressor":
                        outputGuid[i] = StandardCompressor;
                        break;
                    case "I3DL2 Reverb":
                        outputGuid[i] = StandardI3DL2REVERB;
                        break;
                    case "Waves Reverb":
                        outputGuid[i] = WavesReverb;
                        break;
                    case "Gargle":
                        outputGuid[i] = StandardGargle;
                        break;
                    case "Echo":
                        outputGuid[i] = StandardEcho;
                        break;
                    case "Param EQ":
                        outputGuid[i] = StandardParameq;
                        break;
                    case "Distortion":
                        outputGuid[i] = StandardDistortion;
                        break;
                    default:
                        Console.WriteLine("Invalid equalizer settings length.");
                        break;
                }
            }
            eq = outputGuid;
        }       

        private void PlayDirect()
        {
            WaveFormat waveFormat = new WaveFormat();

            var stream = new SoundStream(File.OpenRead(filePath));
            waveFormat = stream.Format;

            // Create PrimarySoundBuffer
            var primaryBufferDesc = new SoundBufferDescription();
            primaryBufferDesc.BufferBytes = File.ReadAllBytes(filePath).Length;// waveFormat.ConvertLatencyToByteSize(60000);
            primaryBufferDesc.Format = waveFormat;
            primaryBufferDesc.Flags = SharpDX.DirectSound.BufferFlags.GetCurrentPosition2 | SharpDX.DirectSound.BufferFlags.ControlPositionNotify | SharpDX.DirectSound.BufferFlags.GlobalFocus |
                                        SharpDX.DirectSound.BufferFlags.ControlVolume | SharpDX.DirectSound.BufferFlags.StickyFocus | SharpDX.DirectSound.BufferFlags.ControlEffects;
            primaryBufferDesc.AlgorithmFor3D = Guid.Empty;
            soundBuffer = new SecondarySoundBuffer(directSound, primaryBufferDesc);
            soundBuffer.Write(File.ReadAllBytes(filePath), 0, LockFlags.None);

            // Play the song
            if (eq.Length > 0)
                soundBuffer.SetEffect(eq);
            soundBuffer.Play(0, PlayFlags.None);
        }

        private void StopDirect()
        {
            isPlaying = false;
            soundBuffer.Stop();
        }

        private void PauseDirect()
        {
            if (isPlaying)
            {
                int dummy = 0;
                soundBuffer.GetCurrentPosition(out directCurrentPosition, out dummy);
                soundBuffer.Stop();
                isPlaying = false;
            }
            else
            {
                isPlaying = true;
                soundBuffer.Write(File.ReadAllBytes(filePath), 0, LockFlags.None);
                soundBuffer.CurrentPosition = directCurrentPosition;
                soundBuffer.Play(0, PlayFlags.None);
            }
        }
        static void WaveOutDone(IntPtr dev, int uMsg, int dwUser, int dwParam1, int dwParam2)
        {
            int a = 1;
        }
        IntPtr hWaveOut = IntPtr.Zero;
        IntPtr hWaveHdr = IntPtr.Zero;
        private void PlayWaveOutWrite()
        {
            hWaveOut = IntPtr.Zero;
            hWaveHdr = IntPtr.Zero;

            WAVEFORMAT format = new WAVEFORMAT();
            format.wFormatTag = 1;
            format.nChannels = 2;
            format.nSamplesPerSec = 44100;
            format.wBitsPerSample = 16;
            format.nBlockAllign = (short)(format.nChannels * (format.wBitsPerSample / 8));
            format.nAvgBytesPerSec = format.nSamplesPerSec * format.nBlockAllign;
            format.cbSize = 0;
            
            waveOutOpen(out hWaveOut, 0, ref format, IntPtr.Zero, IntPtr.Zero, 0);

            using(FileStream fileStream = new FileStream(filePath, FileMode.Open))
            {
                byte[] buffer = new byte[fileStream.Length];
                fileStream.Read(buffer, 0, buffer.Length);

                WaveHdr waveHeader = new WaveHdr();

                waveHeader.lpData = Marshal.AllocHGlobal(buffer.Length);
                Marshal.Copy(buffer, 0, waveHeader.lpData, buffer.Length);
                waveHeader.dwBufferLength = buffer.Length;
                waveHeader.dwFlags = 0;
                waveHeader.dwLoops = 1;

                waveOutPrepareHeader(hWaveOut, ref waveHeader, Marshal.SizeOf(typeof(WaveHdr)));
                waveOutWrite(hWaveOut, ref waveHeader, Marshal.SizeOf(typeof(WaveHdr)));

                while ((waveHeader.dwFlags & 1) == 0) { System.Threading.Thread.Sleep(50); }

                waveOutClose(hWaveOut);
                Marshal.FreeHGlobal(waveHeader.lpData);
            }
        }

        public void StopWaveOutWrite()
        {
            if (hWaveOut != IntPtr.Zero)
            {
                waveOutClose(hWaveOut);
            }
        }
    }
}
