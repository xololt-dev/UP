namespace UP___Modem
{
    partial class Modem
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBoxRecording = new System.Windows.Forms.TextBox();
            this.comboBoxPort = new System.Windows.Forms.ComboBox();
            this.comboBoxBaud = new System.Windows.Forms.ComboBox();
            this.comboBoxDataBits = new System.Windows.Forms.ComboBox();
            this.comboBoxStopBits = new System.Windows.Forms.ComboBox();
            this.comboBoxHandshake = new System.Windows.Forms.ComboBox();
            this.comboBoxParzystosc = new System.Windows.Forms.ComboBox();
            this.buttonPorty = new System.Windows.Forms.Button();
            this.buttonOpen = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(60, 385);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(441, 20);
            this.textBox1.TabIndex = 3;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
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
            // comboBoxPort
            // 
            this.comboBoxPort.FormattingEnabled = true;
            this.comboBoxPort.Location = new System.Drawing.Point(60, 25);
            this.comboBoxPort.Name = "comboBoxPort";
            this.comboBoxPort.Size = new System.Drawing.Size(121, 21);
            this.comboBoxPort.TabIndex = 22;
            // 
            // comboBoxBaud
            // 
            this.comboBoxBaud.FormattingEnabled = true;
            this.comboBoxBaud.Location = new System.Drawing.Point(60, 52);
            this.comboBoxBaud.Name = "comboBoxBaud";
            this.comboBoxBaud.Size = new System.Drawing.Size(121, 21);
            this.comboBoxBaud.TabIndex = 23;
            // 
            // comboBoxDataBits
            // 
            this.comboBoxDataBits.FormattingEnabled = true;
            this.comboBoxDataBits.Location = new System.Drawing.Point(60, 79);
            this.comboBoxDataBits.Name = "comboBoxDataBits";
            this.comboBoxDataBits.Size = new System.Drawing.Size(121, 21);
            this.comboBoxDataBits.TabIndex = 24;
            // 
            // comboBoxStopBits
            // 
            this.comboBoxStopBits.FormattingEnabled = true;
            this.comboBoxStopBits.Location = new System.Drawing.Point(60, 106);
            this.comboBoxStopBits.Name = "comboBoxStopBits";
            this.comboBoxStopBits.Size = new System.Drawing.Size(121, 21);
            this.comboBoxStopBits.TabIndex = 25;
            // 
            // comboBoxHandshake
            // 
            this.comboBoxHandshake.FormattingEnabled = true;
            this.comboBoxHandshake.Location = new System.Drawing.Point(60, 133);
            this.comboBoxHandshake.Name = "comboBoxHandshake";
            this.comboBoxHandshake.Size = new System.Drawing.Size(121, 21);
            this.comboBoxHandshake.TabIndex = 26;
            // 
            // comboBoxParzystosc
            // 
            this.comboBoxParzystosc.FormattingEnabled = true;
            this.comboBoxParzystosc.Location = new System.Drawing.Point(60, 160);
            this.comboBoxParzystosc.Name = "comboBoxParzystosc";
            this.comboBoxParzystosc.Size = new System.Drawing.Size(121, 21);
            this.comboBoxParzystosc.TabIndex = 27;
            // 
            // buttonPorty
            // 
            this.buttonPorty.Location = new System.Drawing.Point(221, 23);
            this.buttonPorty.Name = "buttonPorty";
            this.buttonPorty.Size = new System.Drawing.Size(75, 23);
            this.buttonPorty.TabIndex = 28;
            this.buttonPorty.Text = "Znajdź porty";
            this.buttonPorty.UseVisualStyleBackColor = true;
            this.buttonPorty.Click += new System.EventHandler(this.buttonPorty_Click);
            // 
            // buttonOpen
            // 
            this.buttonOpen.Location = new System.Drawing.Point(221, 52);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(75, 23);
            this.buttonOpen.TabIndex = 29;
            this.buttonOpen.Text = "Otwarty";
            this.buttonOpen.UseVisualStyleBackColor = true;
            this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);
            // 
            // Modem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 450);
            this.Controls.Add(this.buttonOpen);
            this.Controls.Add(this.buttonPorty);
            this.Controls.Add(this.comboBoxParzystosc);
            this.Controls.Add(this.comboBoxHandshake);
            this.Controls.Add(this.comboBoxStopBits);
            this.Controls.Add(this.comboBoxDataBits);
            this.Controls.Add(this.comboBoxBaud);
            this.Controls.Add(this.comboBoxPort);
            this.Controls.Add(this.textBoxRecording);
            this.Controls.Add(this.textBox1);
            this.Name = "Modem";
            this.Text = "Modem";
            this.Load += new System.EventHandler(this.Karta_Dzwiekowa_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBoxRecording;
        private System.Windows.Forms.ComboBox comboBoxPort;
        private System.Windows.Forms.ComboBox comboBoxBaud;
        private System.Windows.Forms.ComboBox comboBoxDataBits;
        private System.Windows.Forms.ComboBox comboBoxStopBits;
        private System.Windows.Forms.ComboBox comboBoxHandshake;
        private System.Windows.Forms.ComboBox comboBoxParzystosc;
        private System.Windows.Forms.Button buttonPorty;
        private System.Windows.Forms.Button buttonOpen;
    }
}

