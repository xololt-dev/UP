using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XModemProtocol;
using System.IO.Ports;

namespace UP___Modem
{
    // https://github.com/emancipatedMind/XmodemProtocol

    public partial class Modem : Form
    {
        SerialPort serialPort = new SerialPort();
        XModemCommunicator xmodem = new XModemCommunicator();

        internal delegate void SerialDataReceivedEventHandlerDelegate(
                 object sender, SerialDataReceivedEventArgs e);

        delegate void SetTextCallback(string text);
        string InputData = String.Empty;
        string outputData = String.Empty;

        public Modem()
        {
            InitializeComponent();
        }

        private void Karta_Dzwiekowa_Load(object sender, EventArgs e)
        {
            serialPort.DataReceived +=
              new System.IO.Ports.SerialDataReceivedEventHandler(port_DataReceived_1);

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
            comboBoxBaud.Text = comboBoxBaud.Items[4].ToString();
        }

        private void addHandshakeValues()
        {
            comboBoxHandshake.Items.Clear();

            comboBoxHandshake.Items.Add("None");
            comboBoxHandshake.Items.Add("XOnXOff");
            comboBoxHandshake.Items.Add("RequestToSend");
            comboBoxHandshake.Items.Add("RequestToSendXOnXOff");

            comboBoxHandshake.Text = comboBoxHandshake.Items[1].ToString();
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
                addDataBits();
            }
            else if (buttonCommsType.Text == "XMODEM")
            {
                buttonCommsType.Text = "RS232";
                addDataBits();
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
            comboBoxPort.Items.Clear();

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
                    comboBoxPort.Items.Add(ArrayComPortsNames[index]);
                }
                while (!((ArrayComPortsNames[index] == ComPortName) ||
                                (index == ArrayComPortsNames.GetUpperBound(0))));
            }

            if (found)
                comboBoxPort.Text = comboBoxPort.Items[0].ToString();

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

        private void port_DataReceived_1(object sender, SerialDataReceivedEventArgs e)
        {
            InputData = serialPort.ReadExisting();
            if (InputData != String.Empty)
            {
                this.BeginInvoke(new SetTextCallback(SetText), new object[] { InputData });
            }
        }

        private void SetText(string text)
        {
            this.textBoxHistory.Text += text;
        }

        private void textBoxInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13) // enter key  
            {
                if (buttonCommsType.Text == "RS232")
                {
                    serialPort.Write(outputData);
                    serialPort.Write("\r\n");
                }
                else if (buttonCommsType.Text == "XMODEM")
                {
                    xmodem.Data = Encoding.ASCII.GetBytes(outputData);
                    xmodem.Completed += (s, d) => {
                        Console.WriteLine($"Operation completed.\nPress enter to exit.");
                    };
                    xmodem.Aborted += (s, d) => {
                        Console.WriteLine("Operation Aborted.\nPress enter to exit.");
                    };

                    xmodem.Send();

                    if (xmodem.State != XModemStates.Idle)
                    {
                        xmodem.CancelOperation();
                        InputData = Console.ReadLine();

                        if (InputData != String.Empty)
                        {
                            this.BeginInvoke(new SetTextCallback(SetText), new object[] { InputData });
                        }
                    }
                }
                textBoxInput.Text = "";
                outputData = string.Empty;
            }
            else if (e.KeyChar == (char)8)
            {
                if (textBoxInput.Text.Length != 0)
                {
                    outputData.Remove(outputData.Length - 1);
                    textBoxInput.Text.Remove(textBoxInput.Text.Length - 1);
                }
            }
            else if (e.KeyChar < 32 || e.KeyChar > 126)
            {
                e.Handled = true; // ignores anything else outside printable ASCII range
            }
            else
            {
                outputData += e.KeyChar.ToString();
            }
        }
    }
}
