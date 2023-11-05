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
            this.labelFormat = new System.Windows.Forms.Label();
            this.comboBoxColor = new System.Windows.Forms.ComboBox();
            this.labelColor = new System.Windows.Forms.Label();
            this.textBoxBrightness = new System.Windows.Forms.TextBox();
            this.textBoxContrast = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxDPI = new System.Windows.Forms.TextBox();
            this.labelDPI = new System.Windows.Forms.Label();
            this.textBoxPixelX = new System.Windows.Forms.TextBox();
            this.labelPixels = new System.Windows.Forms.Label();
            this.buttonDefault = new System.Windows.Forms.Button();
            this.textBoxPixelY = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSkan
            // 
            this.btnSkan.Location = new System.Drawing.Point(142, 684);
            this.btnSkan.Margin = new System.Windows.Forms.Padding(6);
            this.btnSkan.Name = "btnSkan";
            this.btnSkan.Size = new System.Drawing.Size(286, 76);
            this.btnSkan.TabIndex = 0;
            this.btnSkan.Text = "Użyj skanera";
            this.btnSkan.UseVisualStyleBackColor = true;
            this.btnSkan.Click += new System.EventHandler(this.btnSkan_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.ImageLocation = "C:\\Users\\kubal\\Desktop\\IMG_20220519_153251.jpg";
            this.pictureBox1.Location = new System.Drawing.Point(496, 3);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1089, 847);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(142, 772);
            this.textBox1.Margin = new System.Windows.Forms.Padding(6);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(286, 31);
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
            this.comboBoxImageFormats.Location = new System.Drawing.Point(142, 422);
            this.comboBoxImageFormats.Margin = new System.Windows.Forms.Padding(6);
            this.comboBoxImageFormats.Name = "comboBoxImageFormats";
            this.comboBoxImageFormats.Size = new System.Drawing.Size(286, 33);
            this.comboBoxImageFormats.TabIndex = 4;
            this.comboBoxImageFormats.SelectedIndexChanged += new System.EventHandler(this.comboBoxImageFormats_SelectedIndexChanged);
            // 
            // Devices
            // 
            this.Devices.FormattingEnabled = true;
            this.Devices.ItemHeight = 25;
            this.Devices.Location = new System.Drawing.Point(142, 148);
            this.Devices.Margin = new System.Windows.Forms.Padding(6);
            this.Devices.Name = "Devices";
            this.Devices.Size = new System.Drawing.Size(286, 179);
            this.Devices.TabIndex = 5;
            // 
            // buttonShowScanners
            // 
            this.buttonShowScanners.Location = new System.Drawing.Point(142, 339);
            this.buttonShowScanners.Margin = new System.Windows.Forms.Padding(6);
            this.buttonShowScanners.Name = "buttonShowScanners";
            this.buttonShowScanners.Size = new System.Drawing.Size(286, 71);
            this.buttonShowScanners.TabIndex = 6;
            this.buttonShowScanners.Text = "Wyszukaj skanery";
            this.buttonShowScanners.UseVisualStyleBackColor = true;
            this.buttonShowScanners.Click += new System.EventHandler(this.buttonShowScanners_Click);
            // 
            // labelFormat
            // 
            this.labelFormat.AutoSize = true;
            this.labelFormat.Location = new System.Drawing.Point(41, 422);
            this.labelFormat.Name = "labelFormat";
            this.labelFormat.Size = new System.Drawing.Size(79, 25);
            this.labelFormat.TabIndex = 7;
            this.labelFormat.Text = "Format";
            this.labelFormat.Click += new System.EventHandler(this.label1_Click);
            // 
            // comboBoxColor
            // 
            this.comboBoxColor.FormattingEnabled = true;
            this.comboBoxColor.Items.AddRange(new object[] {
            "Czarno-białe",
            "Kolorowe"});
            this.comboBoxColor.Location = new System.Drawing.Point(142, 467);
            this.comboBoxColor.Margin = new System.Windows.Forms.Padding(6);
            this.comboBoxColor.Name = "comboBoxColor";
            this.comboBoxColor.Size = new System.Drawing.Size(286, 33);
            this.comboBoxColor.TabIndex = 8;
            this.comboBoxColor.SelectedIndexChanged += new System.EventHandler(this.comboBoxColor_SelectedIndexChanged);
            // 
            // labelColor
            // 
            this.labelColor.AutoSize = true;
            this.labelColor.Location = new System.Drawing.Point(41, 464);
            this.labelColor.Name = "labelColor";
            this.labelColor.Size = new System.Drawing.Size(62, 25);
            this.labelColor.TabIndex = 9;
            this.labelColor.Text = "Kolor";
            this.labelColor.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // textBoxBrightness
            // 
            this.textBoxBrightness.Location = new System.Drawing.Point(142, 512);
            this.textBoxBrightness.Margin = new System.Windows.Forms.Padding(6);
            this.textBoxBrightness.Name = "textBoxBrightness";
            this.textBoxBrightness.Size = new System.Drawing.Size(286, 31);
            this.textBoxBrightness.TabIndex = 10;
            this.textBoxBrightness.TextChanged += new System.EventHandler(this.textBoxBrightness_TextChanged);
            // 
            // textBoxContrast
            // 
            this.textBoxContrast.Location = new System.Drawing.Point(142, 555);
            this.textBoxContrast.Margin = new System.Windows.Forms.Padding(6);
            this.textBoxContrast.Name = "textBoxContrast";
            this.textBoxContrast.Size = new System.Drawing.Size(286, 31);
            this.textBoxContrast.TabIndex = 11;
            this.textBoxContrast.TextChanged += new System.EventHandler(this.textBoxContrast_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 509);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 25);
            this.label1.TabIndex = 12;
            this.label1.Text = "Jasność";
            this.label1.Click += new System.EventHandler(this.label1_Click_2);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 552);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 25);
            this.label2.TabIndex = 13;
            this.label2.Text = "Kontrast";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // textBoxDPI
            // 
            this.textBoxDPI.Location = new System.Drawing.Point(142, 598);
            this.textBoxDPI.Margin = new System.Windows.Forms.Padding(6);
            this.textBoxDPI.Name = "textBoxDPI";
            this.textBoxDPI.Size = new System.Drawing.Size(286, 31);
            this.textBoxDPI.TabIndex = 14;
            this.textBoxDPI.TextChanged += new System.EventHandler(this.textBoxDPI_TextChanged);
            // 
            // labelDPI
            // 
            this.labelDPI.AutoSize = true;
            this.labelDPI.Location = new System.Drawing.Point(41, 595);
            this.labelDPI.Name = "labelDPI";
            this.labelDPI.Size = new System.Drawing.Size(46, 25);
            this.labelDPI.TabIndex = 15;
            this.labelDPI.Text = "DPI";
            this.labelDPI.Click += new System.EventHandler(this.label3_Click);
            // 
            // textBoxPixelX
            // 
            this.textBoxPixelX.Location = new System.Drawing.Point(142, 641);
            this.textBoxPixelX.Margin = new System.Windows.Forms.Padding(6);
            this.textBoxPixelX.Name = "textBoxPixelX";
            this.textBoxPixelX.Size = new System.Drawing.Size(137, 31);
            this.textBoxPixelX.TabIndex = 16;
            this.textBoxPixelX.TextChanged += new System.EventHandler(this.textBoxPixelX_TextChanged);
            // 
            // labelPixels
            // 
            this.labelPixels.Location = new System.Drawing.Point(41, 638);
            this.labelPixels.Name = "labelPixels";
            this.labelPixels.Size = new System.Drawing.Size(100, 50);
            this.labelPixels.TabIndex = 17;
            this.labelPixels.Text = "Wielkość pixeli";
            // 
            // buttonDefault
            // 
            this.buttonDefault.Location = new System.Drawing.Point(142, 60);
            this.buttonDefault.Margin = new System.Windows.Forms.Padding(6);
            this.buttonDefault.Name = "buttonDefault";
            this.buttonDefault.Size = new System.Drawing.Size(286, 76);
            this.buttonDefault.TabIndex = 18;
            this.buttonDefault.Text = "Zeskanuj domyślnie";
            this.buttonDefault.UseVisualStyleBackColor = true;
            this.buttonDefault.Click += new System.EventHandler(this.buttonDefault_Click);
            // 
            // textBoxPixelY
            // 
            this.textBoxPixelY.Location = new System.Drawing.Point(291, 641);
            this.textBoxPixelY.Margin = new System.Windows.Forms.Padding(6);
            this.textBoxPixelY.Name = "textBoxPixelY";
            this.textBoxPixelY.Size = new System.Drawing.Size(137, 31);
            this.textBoxPixelY.TabIndex = 19;
            this.textBoxPixelY.TextChanged += new System.EventHandler(this.textBoxPixelY_TextChanged);
            // 
            // Skaner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1600, 865);
            this.Controls.Add(this.textBoxPixelY);
            this.Controls.Add(this.buttonDefault);
            this.Controls.Add(this.labelPixels);
            this.Controls.Add(this.textBoxPixelX);
            this.Controls.Add(this.labelDPI);
            this.Controls.Add(this.textBoxDPI);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxContrast);
            this.Controls.Add(this.textBoxBrightness);
            this.Controls.Add(this.labelColor);
            this.Controls.Add(this.comboBoxColor);
            this.Controls.Add(this.labelFormat);
            this.Controls.Add(this.buttonShowScanners);
            this.Controls.Add(this.Devices);
            this.Controls.Add(this.comboBoxImageFormats);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnSkan);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(6);
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
        private System.Windows.Forms.Label labelFormat;
        private System.Windows.Forms.ComboBox comboBoxColor;
        private System.Windows.Forms.Label labelColor;
        private System.Windows.Forms.TextBox textBoxBrightness;
        private System.Windows.Forms.TextBox textBoxContrast;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxDPI;
        private System.Windows.Forms.Label labelDPI;
        private System.Windows.Forms.TextBox textBoxPixelX;
        private System.Windows.Forms.Label labelPixels;
        private System.Windows.Forms.Button buttonDefault;
        private System.Windows.Forms.TextBox textBoxPixelY;
    }
}

