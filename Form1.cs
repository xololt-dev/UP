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
    // https://github.com/emancipatedMind/XmodemProtocol

    public partial class Modem : Form
    {
        SerialPort serialPort = new SerialPort();
        XModemCommunicator xmodem = new XModemCommunicator();
        public Modem()
        {
            InitializeComponent();
        }

        private void Karta_Dzwiekowa_Load(object sender, EventArgs e)
        {
            findPorts();
            addBaudValues();
            addDataBits();
            addStopBits();
            addHandshakeValues();
            addParzytosc();
        }

        private void addBaudValues()
        {
            comboBoxBaud.Items.Clear();

            comboBoxBaud.Items.Add(300);
            comboBoxBaud.Items.Add(600);
            comboBoxBaud.Items.Add(1200);
            comboBoxBaud.Items.Add(2400);
            comboBoxBaud.Items.Add(9600);
            comboBoxBaud.Items.Add(14400);
            comboBoxBaud.Items.Add(19200);
            comboBoxBaud.Items.Add(38400);
            comboBoxBaud.Items.Add(57600);
            comboBoxBaud.Items.Add(115200);
            comboBoxBaud.Items.Add(230400);
            comboBoxBaud.Items.Add(460800);
            comboBoxBaud.Items.Add(921600);
            comboBoxBaud.Items.ToString();

            //get first item print in text
            comboBoxBaud.Text = comboBoxBaud.Items[0].ToString();
        }

        private void addHandshakeValues()
        {
            comboBoxHandshake.Items.Clear();

            comboBoxHandshake.Items.Add("None");
            comboBoxHandshake.Items.Add("XOnXOff");
            comboBoxHandshake.Items.Add("RequestToSend");
            comboBoxHandshake.Items.Add("RequestToSendXOnXOff");

            comboBoxHandshake.Text = comboBoxHandshake.Items[0].ToString();
        }

        private void addDataBits()
        {
            comboBoxDataBits.Items.Clear();

            if (buttonCommsType.Text == "RS232") 
                comboBoxDataBits.Items.Add(7);
            comboBoxDataBits.Items.Add(8);

            comboBoxDataBits.Text = comboBoxDataBits.Items[0].ToString();
        }

        private void addStopBits()
        {
            comboBoxStopBits.Items.Clear();

            comboBoxStopBits.Items.Add("One");
            comboBoxStopBits.Items.Add("OnePointFive");
            comboBoxStopBits.Items.Add("Two");

            comboBoxStopBits.Text = comboBoxStopBits.Items[0].ToString();
        }

        private void addParzytosc()
        {
            comboBoxParzystosc.Items.Clear();

            comboBoxParzystosc.Items.Add("None");
            comboBoxParzystosc.Items.Add("Even");
            comboBoxParzystosc.Items.Add("Mark");
            comboBoxParzystosc.Items.Add("Odd");
            comboBoxParzystosc.Items.Add("Space");

            comboBoxParzystosc.Text = comboBoxParzystosc.Items[0].ToString();
        }

        private void textBoxHistory_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void buttonCommsType_Click(object sender, EventArgs e)
        {
            if (buttonCommsType.Text == "RS232")
            {
                buttonCommsType.Text = "XMODEM";
            }
            else if (buttonCommsType.Text == "XMODEM")
            {
                buttonCommsType.Text = "RS232";
            }
        }

        private void buttonPorty_Click(object sender, EventArgs e)
        {
            if (!findPorts())
            {
                MessageBox.Show("Komputer nie ma portów!", "Brak portów", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            if (buttonOpen.Text == "Zamknięty")
            {
                if (setPortProperties())
                {
                    buttonOpen.Text = "Otwarty";
                    xmodem.Port = serialPort;
                    serialPort.Open();
                }
            }
            else if (buttonOpen.Text == "Otwarty")
            {
                buttonOpen.Text = "Zamknięty";
                serialPort.Close();
            }
        }

        private bool findPorts()
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

        private bool setPortProperties()
        {
            if (comboBoxPort.Text.ToString() == "") return false;

            serialPort.PortName = comboBoxPort.Text.ToString();
            serialPort.BaudRate = Convert.ToInt32(comboBoxBaud.Text);
            serialPort.DataBits = Convert.ToInt16(comboBoxDataBits.Text);
            serialPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), comboBoxStopBits.Text);
            serialPort.Handshake =
               (Handshake)Enum.Parse(typeof(Handshake), comboBoxHandshake.Text);
            serialPort.Parity = (Parity)Enum.Parse(typeof(Parity), comboBoxParzystosc.Text);

            return true;
        }
    }
}
