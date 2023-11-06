﻿using System;
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
using SharpDX.Multimedia;
using SharpDX.X3DAudio;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Media;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace UP___Karta
{
    public partial class Karta_Dzwiekowa : Form
    {
        private Player player = new Player();
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

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
                // PlaySound(dialog1.FileName, new System.IntPtr(), PlaySoundFlags.SND_SYNC);
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

        DirectSound directSound;// = new DirectSound();


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
                    // playMethod = "WaveOutWrite";
                    break;
                case "MCI":
                    PlayMCI();
                    // playMethod = "MCI";
                    break;
                case "DirectSound":
                    // playMethod = "DirectSound";
                    break;
            }
        }
        public void Stop()
        {
            switch (playMethod)
            {
                case "PlaySound":
                    PlaySound(null, new IntPtr(), PlaySoundFlags.SND_SYNC);
                    break;
                case "Windows Media Player":
                    PlayerWMP.controls.stop();
                    // playMethod = "Windows Media Player";
                    break;
                case "WaveOutWrite":
                    // playMethod = "WaveOutWrite";
                    break;
                case "MCI":
                    StopMCI();
                    break;
                case "DirectSound":
                    // playMethod = "DirectSound";
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
                    // playMethod = "DirectSound";
                    break;
            }
        }

        public void SetPlayMethod(string playMethod)
        {
            this.playMethod = playMethod;
        }

        public void SetFilePath(string filePath)
        {
            this.filePath = filePath;
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
            if (OpenMCI(this.filePath))//playlist.Items[track].SubItems[1].Text))
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

        public void StopMCI()
        {
            mci_data.Pcommand = "stop MediaFile";
            mci_data.error = mciSendString(mci_data.Pcommand, null, 0, IntPtr.Zero);
            mci_data.Paused = false;
            CloseMCI();
        }

        public void ResumeMCI()
        {
            mci_data.Pcommand = "resume MediaFile";
            mci_data.error = mciSendString(mci_data.Pcommand, null, 0, IntPtr.Zero);
        }

        public bool IsPlayingMCI()
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
                    break;
                case WMPLib.WMPPlayState.wmppsPaused:
                    break;
            }
            /*
            if ((WMPLib.WMPPlayState)NewState == WMPLib.WMPPlayState.wmppsStopped)
            {
                // this.Close();
            }
            */
        }

        private void Player_MediaError(object pMediaObject)
        {
            MessageBox.Show("Cannot play media file.");
            // this.Close();
        }
    }
}
