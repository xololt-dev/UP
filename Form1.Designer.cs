namespace UP___Kamera
{
    partial class Kamera
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
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.buttonRecord = new System.Windows.Forms.Button();
            this.textBoxRecording = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(505, 207);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 41);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(219, 388);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(441, 20);
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
            this.comboBoxPlayMethod.Location = new System.Drawing.Point(458, 121);
            this.comboBoxPlayMethod.Name = "comboBoxPlayMethod";
            this.comboBoxPlayMethod.Size = new System.Drawing.Size(121, 21);
            this.comboBoxPlayMethod.TabIndex = 4;
            this.comboBoxPlayMethod.SelectedIndexChanged += new System.EventHandler(this.comboBoxPlayMethod_SelectedIndexChanged);
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.Location = new System.Drawing.Point(505, 255);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(75, 41);
            this.btnSelectFile.TabIndex = 6;
            this.btnSelectFile.Text = "Wybierz plik";
            this.btnSelectFile.UseVisualStyleBackColor = true;
            this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // btnPause
            // 
            this.btnPause.Location = new System.Drawing.Point(585, 207);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(75, 41);
            this.btnPause.TabIndex = 7;
            this.btnPause.Text = "Pause";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(665, 207);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 41);
            this.btnStop.TabIndex = 8;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "Flanger",
            "Chorus",
            "Compressor",
            "I3DL2 Reverb",
            "Waves Reverb",
            "Gargle",
            "Echo",
            "Param EQ",
            "Distortion"});
            this.checkedListBox1.Location = new System.Drawing.Point(12, 12);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(120, 139);
            this.checkedListBox1.TabIndex = 19;
            this.checkedListBox1.SelectedIndexChanged += new System.EventHandler(this.checkedListBox1_SelectedIndexChanged);
            // 
            // buttonRecord
            // 
            this.buttonRecord.Location = new System.Drawing.Point(587, 255);
            this.buttonRecord.Name = "buttonRecord";
            this.buttonRecord.Size = new System.Drawing.Size(153, 41);
            this.buttonRecord.TabIndex = 20;
            this.buttonRecord.Text = "Nagrywaj";
            this.buttonRecord.UseVisualStyleBackColor = true;
            this.buttonRecord.Click += new System.EventHandler(this.buttonRecord_Click);
            // 
            // textBoxRecording
            // 
            this.textBoxRecording.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxRecording.Enabled = false;
            this.textBoxRecording.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxRecording.ForeColor = System.Drawing.Color.LightGreen;
            this.textBoxRecording.Location = new System.Drawing.Point(219, 313);
            this.textBoxRecording.Name = "textBoxRecording";
            this.textBoxRecording.ReadOnly = true;
            this.textBoxRecording.Size = new System.Drawing.Size(521, 37);
            this.textBoxRecording.TabIndex = 21;
            // 
            // Karta_Dzwiekowa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBoxRecording);
            this.Controls.Add(this.buttonRecord);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.btnSelectFile);
            this.Controls.Add(this.comboBoxPlayMethod);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnStart);
            this.Name = "Karta_Dzwiekowa";
            this.Text = "Karta Dzwiekowa";
            this.Load += new System.EventHandler(this.Kamera_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox comboBoxPlayMethod;
        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Button buttonRecord;
        private System.Windows.Forms.TextBox textBoxRecording;
    }
}

