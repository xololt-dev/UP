using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WIA;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;



namespace UP___Skaner
{
    public partial class Skaner : Form
    {
        private string lastScanPath;
        private string imageFormat = @".jpeg";
        private int rotation = 0;
        private int dpi = 200;
        private int pixelSizeX = 1700;
        private int pixelSizeY = 1700;
        private int cmXSize = 10;
        private int cmYSize = 15;
        private int color = 1;
        private int brightness = 0;
        private int contrast = 0;
        private int startX = 0;
        private int startY = 0;

        public Skaner()
        {
            InitializeComponent();
        }

        private void defaultScan() {
            try
            {
                var deviceManager = new DeviceManager();

                for (int i = 1; i <= deviceManager.DeviceInfos.Count; i++)
                {
                    if (deviceManager.DeviceInfos[i].Type != WiaDeviceType.ScannerDeviceType)
                    {
                        continue;
                    }

                    Devices.Items.Add(new Scanner(deviceManager.DeviceInfos[i]));
                }

                WIA.CommonDialog dialog;

                var device = Devices.Items[0] as Device;

                dialog = new WIA.CommonDialog();

                device = dialog.ShowSelectDevice(AlwaysSelectDevice: true);

                Items items;

                items = dialog.ShowSelectItems(device, SingleSelect: false);

                ImageFile image;

                image = dialog.ShowTransfer(device.Items[1]);

                var path = @"C:\Users\lab\Desktop\UP-master\scan";

                path += imageFormat;

                for (int i = 1; ; i++)
                {
                    if (!File.Exists(path)) break;
                    path = path.Replace(imageFormat, "");
                    int prev = i - 1;
                    path = path.Replace(prev.ToString(), "");
                    path += i.ToString();
                    path += imageFormat;
                }
                image.SaveFile(path);
                pictureBox1.ImageLocation = path;
                lastScanPath = path;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Skaner_Load(object sender, EventArgs e)
        {
            
        }

        private void btnSkan_Click(object sender, EventArgs e)
        {
            try
            {
          
                var device = Devices.SelectedItem as Scanner;
                if (device == null)
                {
                    MessageBox.Show("Wybierz skaner.", "Ostrzeżenie",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                textBox1.Text = "Skaner w działaniu!";

                var image = device.ScanAdvanced(imageFormat, rotation, dpi, pixelSizeX, pixelSizeY, contrast, brightness, color, startX, startY);

                var path = @"C:\Users\lab\Desktop\UP-master\scan";

                path += imageFormat;

                for (int i = 1; ; i++)
                {
                    if (!File.Exists(path)) break;
                    path = path.Replace(imageFormat, "");
                    int prev = i - 1;
                    path = path.Replace(prev.ToString(), "");
                    path += i.ToString();
                    path += imageFormat;
                }
                image.SaveFile(path);
                pictureBox1.ImageLocation = path;
                lastScanPath = path;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxImageFormats_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                switch ((string)comboBoxImageFormats.SelectedItem)
                {
                    case "JPG":
                        imageFormat = @".jpeg";
                        break;
                    case "PNG":
                        imageFormat = @".png";
                        break;
                    case "TIFF":
                        imageFormat = @".tiff";
                        break;
                    case "BMP":
                        imageFormat = @".bmp";
                        break;
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void buttonShowScanners_Click(object sender, EventArgs e)
        {
            try
            {
                Devices.Items.Clear();

                var deviceManager = new DeviceManager();

                for (int i = 1; i <= deviceManager.DeviceInfos.Count; i++)
                {
                    if (deviceManager.DeviceInfos[i].Type != WiaDeviceType.ScannerDeviceType)
                    {
                        continue;
                    }

                    Devices.Items.Add(new Scanner(deviceManager.DeviceInfos[i]));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label1_Click(object sender, EventArgs e) {

        }

        private void label1_Click_1(object sender, EventArgs e) {

        }

        private void comboBoxColor_SelectedIndexChanged(object sender, EventArgs e) {
            if ((string)comboBoxColor.SelectedItem == "Czarno-białe") color = 2;
            else if ((string)comboBoxColor.SelectedItem == "Kolorowe") color = 1;
        }

        private void label1_Click_2(object sender, EventArgs e) {

        }

        private void label2_Click(object sender, EventArgs e) {

        }

        private void textBoxBrightness_TextChanged(object sender, EventArgs e) {
            try
            {
                brightness = Int32.Parse(textBoxBrightness.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBoxContrast_TextChanged(object sender, EventArgs e) {
            try
            {
               
                if (textBoxContrast.Text != "" & textBoxContrast.Text != "-") contrast = Int32.Parse(textBoxContrast.Text);
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label3_Click(object sender, EventArgs e) {

        }

        private void textBoxDPI_TextChanged(object sender, EventArgs e) {
            try
            {
                dpi = Int32.Parse(textBoxDPI.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static int CentimetersToPixels(double centimeters, int dpi)
        {
            // 1 inch = 2.54 cm
            // 1 inch = 96 pixels at 96 DPI (standard for most screens)
            // 1 centimeter = 0.393701 inches
            return (int)((centimeters / 2.54) * dpi);
        }

        private void textBoxPixelX_TextChanged(object sender, EventArgs e) {
            try
            {

                cmXSize = Int32.Parse(textBoxPixelX.Text);
                pixelSizeX = CentimetersToPixels(cmXSize, dpi);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBoxPixelY_TextChanged(object sender, EventArgs e) {
            try
            {
                cmYSize = Int32.Parse(textBoxPixelY.Text);
                pixelSizeY = CentimetersToPixels(cmYSize, dpi);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonDefault_Click(object sender, EventArgs e) {
            try
            {
                

                defaultScan();
                textBox1.Text = "Skaner w działaniu!";

                textBox1.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            textBoxBrightness.Text = brightnessSlider.Value.ToString();
        }

        private void contrastSlider_ValueChanged(object sender, EventArgs e)
        {
            textBoxContrast.Text = contrastSlider.Value.ToString();
        }

        private void labelPixels_Click(object sender, EventArgs e)
        {

        }

        private void textBoxPositionX_TextChanged(object sender, EventArgs e)
        {
            try
            {
                startX = Int32.Parse(textBoxPositionX.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBoxPositionY_TextChanged(object sender, EventArgs e)
        {
            try
            {
                startY = Int32.Parse(textBoxPositionY.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
     
    }

    public class Scanner
    {
        const string WIA_SCAN_COLOR_MODE = "6146";
        const string WIA_HORIZONTAL_SCAN_RESOLUTION_DPI = "6147";
        const string WIA_VERTICAL_SCAN_RESOLUTION_DPI = "6148";
        const string WIA_HORIZONTAL_SCAN_START_PIXEL = "6149";
        const string WIA_VERTICAL_SCAN_START_PIXEL = "6150";
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
            try
            {
                // Connect to the device
                var device = this._deviceInfo.Connect();

                // Start the scan
                var item = device.Items[1];
                string wiaFormat = "{B96B3CAE-0728-11D3-9D7B-0000F81EF32E}";
                switch (imageFormat)
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
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public ImageFile ScanAdvanced(string imageFormat, int rotation, int dpi, int pixelSizeX, int pixelSizeY, int contrast, int brightness, int color, int startX, int startY) 
        {
            try
            {
                var device = this._deviceInfo.Connect();

                var item = device.Items[1];

                string wiaFormat = "{B96B3CAE-0728-11D3-9D7B-0000F81EF32E}";
                switch (imageFormat)
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

                SetScannerSettings(item, dpi, pixelSizeX, pixelSizeY, brightness, contrast, color, startX, startY);

                var imageFile = (ImageFile)item.Transfer(wiaFormat);

                return imageFile;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }


        private static void SetScanProperty(WIA.IProperties properties, object propertyType, object propertyValue)
        {
            try
            {
                WIA.Property prop = properties.get_Item(ref propertyType);
                prop.set_Value(ref propertyValue);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private static void SetScannerSettings(IItem scanner, int dpi, int pixelSizeX, int pixelSizeY, int brightness, int contrast, int color, int startX, int startY)
        {
            try
            {
                SetScanProperty(scanner.Properties, WIA_HORIZONTAL_SCAN_RESOLUTION_DPI, dpi);
                SetScanProperty(scanner.Properties, WIA_VERTICAL_SCAN_RESOLUTION_DPI, dpi);
                SetScanProperty(scanner.Properties, WIA_HORIZONTAL_SCAN_SIZE_PIXELS, pixelSizeX);
                SetScanProperty(scanner.Properties, WIA_VERTICAL_SCAN_SIZE_PIXELS, pixelSizeY);
                SetScanProperty(scanner.Properties, WIA_SCAN_BRIGHTNESS_PERCENTS, brightness);
                SetScanProperty(scanner.Properties, WIA_SCAN_CONTRAST_PERCENTS, contrast);
                SetScanProperty(scanner.Properties, WIA_SCAN_COLOR_MODE, color);
                SetScanProperty(scanner.Properties, WIA_HORIZONTAL_SCAN_START_PIXEL, startX);
                SetScanProperty(scanner.Properties, WIA_VERTICAL_SCAN_START_PIXEL, startY);

            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
