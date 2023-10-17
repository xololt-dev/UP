namespace UP___Skaner
{
    partial class Skaner
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
            this.btnSkan = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.comboBoxImageFormats = new System.Windows.Forms.ComboBox();
            this.Devices = new System.Windows.Forms.ListBox();
            this.buttonShowScanners = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSkan
            // 
            this.btnSkan.Location = new System.Drawing.Point(505, 207);
            this.btnSkan.Name = "btnSkan";
            this.btnSkan.Size = new System.Drawing.Size(75, 41);
            this.btnSkan.TabIndex = 0;
            this.btnSkan.Text = "Użyj skanera";
            this.btnSkan.UseVisualStyleBackColor = true;
            this.btnSkan.Click += new System.EventHandler(this.btnSkan_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.ImageLocation = "C:\\Users\\kubal\\Desktop\\IMG_20220519_153251.jpg";
            this.pictureBox1.Location = new System.Drawing.Point(49, 34);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(238, 130);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(505, 358);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 3;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // comboBoxImageFormats
            // 
            this.comboBoxImageFormats.FormattingEnabled = true;
            this.comboBoxImageFormats.Items.AddRange(new object[] {
            "JPG",
            "PNG",
            "TIFF",
            "BMP"});
            this.comboBoxImageFormats.Location = new System.Drawing.Point(458, 121);
            this.comboBoxImageFormats.Name = "comboBoxImageFormats";
            this.comboBoxImageFormats.Size = new System.Drawing.Size(121, 21);
            this.comboBoxImageFormats.TabIndex = 4;
            this.comboBoxImageFormats.SelectedIndexChanged += new System.EventHandler(this.comboBoxImageFormats_SelectedIndexChanged);
            // 
            // Devices
            // 
            this.Devices.FormattingEnabled = true;
            this.Devices.Location = new System.Drawing.Point(299, 207);
            this.Devices.Name = "Devices";
            this.Devices.Size = new System.Drawing.Size(120, 95);
            this.Devices.TabIndex = 5;
            // 
            // buttonShowScanners
            // 
            this.buttonShowScanners.Location = new System.Drawing.Point(505, 255);
            this.buttonShowScanners.Name = "buttonShowScanners";
            this.buttonShowScanners.Size = new System.Drawing.Size(75, 23);
            this.buttonShowScanners.TabIndex = 6;
            this.buttonShowScanners.Text = "button1";
            this.buttonShowScanners.UseVisualStyleBackColor = true;
            this.buttonShowScanners.Click += new System.EventHandler(this.buttonShowScanners_Click);
            // 
            // Skaner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonShowScanners);
            this.Controls.Add(this.Devices);
            this.Controls.Add(this.comboBoxImageFormats);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnSkan);
            this.Name = "Skaner";
            this.Text = "Skaner";
            this.Load += new System.EventHandler(this.Skaner_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSkan;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox comboBoxImageFormats;
        private System.Windows.Forms.ListBox Devices;
        private System.Windows.Forms.Button buttonShowScanners;
    }
}

