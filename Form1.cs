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
using WIA;
using WMPLib;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Media;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace UP___Karta
{
    public partial class Karta_Dzwiekowa : Form
    {
        private string playMethod = "PlaySound";
        private string filePath = "";

        // https://www.codeproject.com/Articles/866347/Streaming-Audio-to-the-WaveOut-Device
        /*
        [DllImport("winmm.dll")]
        public static extern int waveOutOpen(out IntPtr hWaveOut, int uDeviceID, WaveFormat lpFormat, WaveDelegate dwCallback, IntPtr dwInstance, int dwFlags);
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
        */

        // https://www.codeproject.com/Articles/63094/Simple-MCI-Player
        [DllImport("winmm.dll")]
        private static extern int mciSendString(string strCommand,
        StringBuilder strReturn, int iReturnLength, IntPtr hwndCallback);
        [DllImport("winmm.dll")]
        public static extern int mciGetErrorString(int errCode,
                      StringBuilder errMsg, int buflen);

        // https://learn.microsoft.com/pl-pl/dotnet/csharp/advanced-topics/interop/how-to-use-platform-invoke-to-play-a-wave-file
        WMPLib.WindowsMediaPlayer Player;

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

        private void PlayFile(String url)
        {
            Player = new WMPLib.WindowsMediaPlayer();
            Player.PlayStateChange +=
                new WMPLib._WMPOCXEvents_PlayStateChangeEventHandler(Player_PlayStateChange);
            Player.MediaError +=
                new WMPLib._WMPOCXEvents_MediaErrorEventHandler(Player_MediaError);
            Player.URL = url;
            Player.controls.play();
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            // TODO  Insert a valid path in the line below.
            PlayFile(@"c:\myaudio.wma");
        }

        private void Player_PlayStateChange(int NewState)
        {
            if ((WMPLib.WMPPlayState)NewState == WMPLib.WMPPlayState.wmppsStopped)
            {
                this.Close();
            }
        }

        private void Player_MediaError(object pMediaObject)
        {
            MessageBox.Show("Cannot play media file.");
            this.Close();
        }

        public Karta_Dzwiekowa()
        {
            InitializeComponent();
            comboBoxPlayMethod.SelectedIndex = 0;
        }

        private void Skaner_Load(object sender, EventArgs e)
        {

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            // check czy plik zaznaczony
            if (filePath != "")
            {
                switch (playMethod)
                {
                    case "PlaySound":
                        PlaySound(filePath, new System.IntPtr(), PlaySoundFlags.SND_SYNC);
                        break;
                    case "Windows Media Player":
                        playMethod = "Windows Media Player";
                        break;
                    case "WaveOutWrite":
                        playMethod = "WaveOutWrite";
                        break;
                    case "MCI":
                        playMethod = "MCI";
                        break;
                    case "DirectSound":
                        playMethod = "DirectSound";
                        break;
                };
            }
            else
            {
                MessageBox.Show("Nie wybrano pliku!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxImageFormats_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch((string)comboBoxPlayMethod.SelectedItem)
            {
                case "PlaySound":
                    playMethod = "PlaySound";
                    break;
                case "Windows Media Player":
                    playMethod = "Windows Media Player";
                    break;
                case "WaveOutWrite":
                    playMethod = "WaveOutWrite";
                    break;
                case "MCI":
                    playMethod = "MCI";
                    break;
                case "DirectSound":
                    playMethod = "DirectSound";
                    break;
            };
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void buttonShowScanners_Click(object sender, EventArgs e)
        {
            var dialog1 = new OpenFileDialog();

            dialog1.Title = "Browse to find sound file to play";
            dialog1.InitialDirectory = @"c:\";
            //<Snippet5>
            dialog1.Filter = "Wav Files (*.wav)|*.wav";
            //</Snippet5>
            dialog1.FilterIndex = 2;
            dialog1.RestoreDirectory = true;

            if (dialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = dialog1.FileName;
                filePath = dialog1.FileName;
                // PlaySound(dialog1.FileName, new System.IntPtr(), PlaySoundFlags.SND_SYNC);
            }
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            switch(playMethod)
            {
                case "PlaySound":
                    // playMethod = "PlaySound";
                    break;
                case "Windows Media Player":
                    // playMethod = "Windows Media Player";
                    break;
                case "WaveOutWrite":
                    // playMethod = "WaveOutWrite";
                    break;
                case "MCI":
                    // playMethod = "MCI";
                    break;
                case "DirectSound":
                    // playMethod = "DirectSound";
                    break;
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            switch (playMethod)
            {
                case "PlaySound":
                    // playMethod = "PlaySound";
                    break;
                case "Windows Media Player":
                    // playMethod = "Windows Media Player";
                    break;
                case "WaveOutWrite":
                    // playMethod = "WaveOutWrite";
                    break;
                case "MCI":
                    // playMethod = "MCI";
                    break;
                case "DirectSound":
                    // playMethod = "DirectSound";
                    break;
            }
        }
    }

    public class Scanner
    {
        const string WIA_SCAN_COLOR_MODE = "6146";
        const string WIA_HORIZONTAL_SCAN_RESOLUTION_DPI = "6147";
        const string WIA_VERTICAL_SCAN_RESOLUTION_DPI = "6148";
        //const string WIA_HORIZONTAL_SCAN_START_PIXEL = "6149";
        //const string WIA_VERTICAL_SCAN_START_PIXEL = "6150";
        const string WIA_HORIZONTAL_SCAN_SIZE_PIXELS = "6151";
        const string WIA_VERTICAL_SCAN_SIZE_PIXELS = "6152";
        const string WIA_SCAN_BRIGHTNESS_PERCENTS = "6154";
        const string WIA_SCAN_CONTRAST_PERCENTS = "6155";

        private readonly DeviceInfo _deviceInfo;

        public Scanner(DeviceInfo deviceInfo)
        {
            this._deviceInfo = deviceInfo;
        }

        public ImageFile Scan(string imageFormat)
        {
            // Connect to the device
            var device = this._deviceInfo.Connect();

            // Start the scan
            var item = device.Items[1];

            // SetScannerSettings
            string wiaFormat = "{B96B3CAE-0728-11D3-9D7B-0000F81EF32E}";
            switch(imageFormat)
            {
                case ".jpeg":
                    wiaFormat = "{B96B3CAE-0728-11D3-9D7B-0000F81EF32E}";
                    break;
                case ".png":
                    wiaFormat = "{B96B3CAF-0728-11D3-9D7B-0000F81EF32E}";
                    break;
                case ".tiff":
                    wiaFormat = "{B96B3CB1-0728-11D3-9D7B-0000F81EF32E}";
                    break;
                case ".bmp":
                    wiaFormat = "{B96B3CAB-0728-11D3-9D7B-0000F81EF32E}";
                    break;
            }
            var imageFile = (ImageFile)item.Transfer(wiaFormat);

            // Return the imageFile
            return imageFile;
        }

        public override string ToString()
        {
            return this._deviceInfo.Properties["Name"].get_Value();
        }

        private static void SetScanProperty(WIA.IProperties properties, string propertyType, int propertyValue)
        {
            WIA.Property prop = properties.get_Item(propertyType);
            prop.set_Value(propertyValue);
        }

        private static void SetScannerSettings(IItem scanner, int dpi, int brightness, int contrast, int color)
        {
            SetScanProperty(scanner.Properties, WIA_SCAN_BRIGHTNESS_PERCENTS, brightness);
        }
    }
}
