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
        private string imageFormat;
        private int resolution;
        // balans bieli
        private int colorTemperature;

        public Skaner()
        {
            InitializeComponent();
        }

        private void Skaner_Load(object sender, EventArgs e)
        {

        }

        private void btnSkan_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Hello World!";

            // Scanner selected?
            var device = Devices.SelectedItem as Scanner;
            if (device == null)
            {
                MessageBox.Show("Wybierz skaner.", "Ostrzeżenie",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Scan
            var image = device.Scan(imageFormat);

            // Save the image
            var path = @"c:\scan";
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxImageFormats_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch((string)comboBoxImageFormats.SelectedItem)
            {
                case "JPEG":
                    imageFormat = ".jpeg";
                    break;
                case "PNG":
                    imageFormat = ".png";
                    break;
                case "TIFF":
                    imageFormat = ".tiff";
                    break;
                case "BMP":
                    imageFormat = ".bmp";
                    break;
            };
            textBox1.Text = imageFormat;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void buttonShowScanners_Click(object sender, EventArgs e)
        {
            // Clear the ListBox.
            Devices.Items.Clear();

            // Create a DeviceManager instance
            var deviceManager = new DeviceManager();

            // Loop through the list of devices and add the name to the listbox
            for (int i = 1; i <= deviceManager.DeviceInfos.Count; i++)
            {
                //Add the device to the list if it is a scanner
                if (deviceManager.DeviceInfos[i].Type != WiaDeviceType.ScannerDeviceType)
                {
                    continue;
                }

                Devices.Items.Add(new Scanner(deviceManager.DeviceInfos[i]));
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
