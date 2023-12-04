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
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Media;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Windows.Forms.VisualStyles;
using System.Runtime.InteropServices.ComTypes;
using System.Threading;
using static System.Windows.Forms.CheckedListBox;
using XModemProtocol;
using System.IO.Ports;

namespace UP___Modem
{
    public partial class Modem : Form
    {
        SerialPort SerialPort = new SerialPort();
        XModemProtocol.XModemCommunicator xmodem = new XModemProtocol.XModemCommunicator();
        public Modem()
        {
            InitializeComponent();
        }

        private void Karta_Dzwiekowa_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void buttonPorty_Click(object sender, EventArgs e)
        {
            if(!findPorty())
            {
                MessageBox.Show("Komputer nie ma portów!", "Brak portów", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            if (buttonOpen.Text == "Zamknięty" && comboBoxPort.Text.ToString() != "")
            {
                buttonOpen.Text = "Otwarty";
                SerialPort.PortName = comboBoxPort.Text.ToString();
                SerialPort.BaudRate = Convert.ToInt32(comboBoxBaud.Text);
                SerialPort.DataBits = Convert.ToInt16(comboBoxDataBits.Text);
                SerialPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), comboBoxStopBits.Text);
                SerialPort.Handshake =
                   (Handshake)Enum.Parse(typeof(Handshake), comboBoxHandshake.Text);
                SerialPort.Parity = (Parity)Enum.Parse(typeof(Parity), comboBoxParzystosc.Text);
                SerialPort.Open();
            }
            else if (buttonOpen.Text == "Otwarty")
            {
                buttonOpen.Text = "Zamknięty";
                SerialPort.Close();
            }
        }

        private bool findPorty()
        {
            bool found = false;
            string[] ArrayComPortsNames = null;

            ArrayComPortsNames = SerialPort.GetPortNames();
            int arrayLength = ArrayComPortsNames.Length;

            if (arrayLength > 0)
            {
                found = true;
                int index = -1;
                string ComPortName = null;

                do
                {
                    index += 1;
                    comboBoxPort.Text += ArrayComPortsNames[index] + "\n";
                }
                while (!((ArrayComPortsNames[index] == ComPortName) ||
                                (index == ArrayComPortsNames.GetUpperBound(0))));
            }

            return found;
        }
    }
}
