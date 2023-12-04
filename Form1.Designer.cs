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
            this.textBoxHistory = new System.Windows.Forms.TextBox();
            this.comboBoxPort = new System.Windows.Forms.ComboBox();
            this.comboBoxBaud = new System.Windows.Forms.ComboBox();
            this.comboBoxDataBits = new System.Windows.Forms.ComboBox();
            this.comboBoxStopBits = new System.Windows.Forms.ComboBox();
            this.comboBoxHandshake = new System.Windows.Forms.ComboBox();
            this.comboBoxParzystosc = new System.Windows.Forms.ComboBox();
            this.buttonPorty = new System.Windows.Forms.Button();
            this.buttonOpen = new System.Windows.Forms.Button();
            this.textBoxInput = new System.Windows.Forms.TextBox();
            this.buttonCommsType = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxHistory
            // 
            this.textBoxHistory.Location = new System.Drawing.Point(60, 238);
            this.textBoxHistory.Multiline = true;
            this.textBoxHistory.Name = "textBoxHistory";
            this.textBoxHistory.Size = new System.Drawing.Size(441, 200);
            this.textBoxHistory.TabIndex = 3;
            this.textBoxHistory.TextChanged += new System.EventHandler(this.textBoxHistory_TextChanged);
            // 
            // comboBoxPort
            // 
            this.comboBoxPort.FormattingEnabled = true;
            this.comboBoxPort.Location = new System.Drawing.Point(60, 25);
            this.comboBoxPort.Name = "comboBoxPort";
            this.comboBoxPort.Size = new System.Drawing.Size(155, 21);
            this.comboBoxPort.TabIndex = 22;
            // 
            // comboBoxBaud
            // 
            this.comboBoxBaud.FormattingEnabled = true;
            this.comboBoxBaud.Location = new System.Drawing.Point(60, 52);
            this.comboBoxBaud.Name = "comboBoxBaud";
            this.comboBoxBaud.Size = new System.Drawing.Size(155, 21);
            this.comboBoxBaud.TabIndex = 23;
            // 
            // comboBoxDataBits
            // 
            this.comboBoxDataBits.FormattingEnabled = true;
            this.comboBoxDataBits.Location = new System.Drawing.Point(60, 79);
            this.comboBoxDataBits.Name = "comboBoxDataBits";
            this.comboBoxDataBits.Size = new System.Drawing.Size(155, 21);
            this.comboBoxDataBits.TabIndex = 24;
            // 
            // comboBoxStopBits
            // 
            this.comboBoxStopBits.FormattingEnabled = true;
            this.comboBoxStopBits.Location = new System.Drawing.Point(60, 106);
            this.comboBoxStopBits.Name = "comboBoxStopBits";
            this.comboBoxStopBits.Size = new System.Drawing.Size(155, 21);
            this.comboBoxStopBits.TabIndex = 25;
            // 
            // comboBoxHandshake
            // 
            this.comboBoxHandshake.FormattingEnabled = true;
            this.comboBoxHandshake.Location = new System.Drawing.Point(60, 133);
            this.comboBoxHandshake.Name = "comboBoxHandshake";
            this.comboBoxHandshake.Size = new System.Drawing.Size(155, 21);
            this.comboBoxHandshake.TabIndex = 26;
            // 
            // comboBoxParzystosc
            // 
            this.comboBoxParzystosc.FormattingEnabled = true;
            this.comboBoxParzystosc.Location = new System.Drawing.Point(60, 160);
            this.comboBoxParzystosc.Name = "comboBoxParzystosc";
            this.comboBoxParzystosc.Size = new System.Drawing.Size(155, 21);
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
            // textBoxInput
            // 
            this.textBoxInput.Location = new System.Drawing.Point(60, 187);
            this.textBoxInput.Name = "textBoxInput";
            this.textBoxInput.Size = new System.Drawing.Size(441, 20);
            this.textBoxInput.TabIndex = 30;
            // 
            // buttonCommsType
            // 
            this.buttonCommsType.Location = new System.Drawing.Point(426, 25);
            this.buttonCommsType.Name = "buttonCommsType";
            this.buttonCommsType.Size = new System.Drawing.Size(75, 23);
            this.buttonCommsType.TabIndex = 31;
            this.buttonCommsType.Text = "RS232";
            this.buttonCommsType.UseVisualStyleBackColor = true;
            this.buttonCommsType.Click += new System.EventHandler(this.buttonCommsType_Click);
            // 
            // Modem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 450);
            this.Controls.Add(this.buttonCommsType);
            this.Controls.Add(this.textBoxInput);
            this.Controls.Add(this.buttonOpen);
            this.Controls.Add(this.buttonPorty);
            this.Controls.Add(this.comboBoxParzystosc);
            this.Controls.Add(this.comboBoxHandshake);
            this.Controls.Add(this.comboBoxStopBits);
            this.Controls.Add(this.comboBoxDataBits);
            this.Controls.Add(this.comboBoxBaud);
            this.Controls.Add(this.comboBoxPort);
            this.Controls.Add(this.textBoxHistory);
            this.Name = "Modem";
            this.Text = "Modem";
            this.Load += new System.EventHandler(this.Karta_Dzwiekowa_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxHistory;
        private System.Windows.Forms.ComboBox comboBoxPort;
        private System.Windows.Forms.ComboBox comboBoxBaud;
        private System.Windows.Forms.ComboBox comboBoxDataBits;
        private System.Windows.Forms.ComboBox comboBoxStopBits;
        private System.Windows.Forms.ComboBox comboBoxHandshake;
        private System.Windows.Forms.ComboBox comboBoxParzystosc;
        private System.Windows.Forms.Button buttonPorty;
        private System.Windows.Forms.Button buttonOpen;
        private System.Windows.Forms.TextBox textBoxInput;
        private System.Windows.Forms.Button buttonCommsType;
    }
}

