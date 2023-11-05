namespace UP___Karta
{
    partial class Karta_Dzwiekowa
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnStart = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.comboBoxPlayMethod = new System.Windows.Forms.ComboBox();
            this.Devices = new System.Windows.Forms.ListBox();
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(758, 318);
            this.btnStart.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(112, 63);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(758, 551);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(148, 26);
            this.textBox1.TabIndex = 3;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // comboBoxPlayMethod
            // 
            this.comboBoxPlayMethod.FormattingEnabled = true;
            this.comboBoxPlayMethod.Items.AddRange(new object[] {
            "PlaySound",
            "Windows Media Player",
            "WaveOutWrite",
            "MCI",
            "DirectSound"});
            this.comboBoxPlayMethod.Location = new System.Drawing.Point(687, 186);
            this.comboBoxPlayMethod.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxPlayMethod.Name = "comboBoxPlayMethod";
            this.comboBoxPlayMethod.Size = new System.Drawing.Size(180, 28);
            this.comboBoxPlayMethod.TabIndex = 4;
            this.comboBoxPlayMethod.SelectedIndexChanged += new System.EventHandler(this.comboBoxImageFormats_SelectedIndexChanged);
            // 
            // Devices
            // 
            this.Devices.FormattingEnabled = true;
            this.Devices.ItemHeight = 20;
            this.Devices.Location = new System.Drawing.Point(448, 318);
            this.Devices.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Devices.Name = "Devices";
            this.Devices.Size = new System.Drawing.Size(178, 144);
            this.Devices.TabIndex = 5;
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.Location = new System.Drawing.Point(758, 392);
            this.btnSelectFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(112, 35);
            this.btnSelectFile.TabIndex = 6;
            this.btnSelectFile.Text = "Wybierz plik";
            this.btnSelectFile.UseVisualStyleBackColor = true;
            this.btnSelectFile.Click += new System.EventHandler(this.buttonShowScanners_Click);
            // 
            // btnPause
            // 
            this.btnPause.Location = new System.Drawing.Point(878, 318);
            this.btnPause.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(112, 63);
            this.btnPause.TabIndex = 7;
            this.btnPause.Text = "Pause";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(998, 318);
            this.btnStop.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(112, 63);
            this.btnStop.TabIndex = 8;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // Karta_Dzwiekowa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 692);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.btnSelectFile);
            this.Controls.Add(this.Devices);
            this.Controls.Add(this.comboBoxPlayMethod);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnStart);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Karta_Dzwiekowa";
            this.Text = "Karta Dzwiekowa";
            this.Load += new System.EventHandler(this.Skaner_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox comboBoxPlayMethod;
        private System.Windows.Forms.ListBox Devices;
        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnStop;
    }
}

