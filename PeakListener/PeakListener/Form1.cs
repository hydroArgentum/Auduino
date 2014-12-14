using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PeakListener
{
    public partial class Form1 : Form
    {
        //Serial device.
        SerialPort serial_device;
        bool port_found = false;

        //Information.
        byte number_led = 0;
        public Form1()
        {
            InitializeComponent();
            NAudio.CoreAudioApi.MMDeviceEnumerator enumerator = new NAudio.CoreAudioApi.MMDeviceEnumerator();
            var devices = enumerator.EnumerateAudioEndPoints(NAudio.CoreAudioApi.DataFlow.All, NAudio.CoreAudioApi.DeviceState.Active);
            comboBox1.Items.AddRange(devices.ToArray());
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null && port_found)
            {
                var device = (NAudio.CoreAudioApi.MMDevice)comboBox1.SelectedItem;
                uint raw_value = (uint)(device.AudioMeterInformation.MasterPeakValue * 4294967295);
                if (raw_value < (4294967295 - 134217728))
                {
                    number_led = 1;
                }
                else if (raw_value < (4294967295 - 16777216))
                {
                    number_led = 2;
                }
                else if (raw_value < (4294967295 - 2097152))
                {
                    number_led = 3;
                }
                else if (raw_value < (4294967295 - 262144))
                {
                    number_led = 4;
                }
                else if (raw_value < (4294967295 - 32768))
                {
                    number_led = 5;
                }
                else if (raw_value < (4294967295 - 4096))
                {
                    number_led = 6;
                }
                else if (raw_value < (4294967295 - 512))
                {
                    number_led = 7;
                }
                else if (raw_value < (4294967295 - 64))
                {
                    number_led = 8;
                }
                else if (raw_value < (4294967295 - 8))
                {
                    number_led = 9;
                }
                else
                {
                    number_led = 10;
                }
                try
                {
                    //Sent message.
                    byte[] buffer = new byte[1];
                    buffer[0] = number_led;
                    serial_device.Open();
                    serial_device.Write(buffer, 0, 1);
                    Thread.Sleep(10);
                    serial_device.Close();
                }
                catch (Exception ex) { }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //Enumerate all the ports.
                string[] port_names = SerialPort.GetPortNames();
                //Check the ports.
                foreach (string port in port_names)
                {
                    //Connect to the serial device.
                    serial_device = new SerialPort(port, 9600);
                    if (DetectArduino())
                    {
                        port_found = true;
                        button1.Enabled = false;
                        break;
                    }
                    else
                    {
                        port_found = false;
                    }
                }
            }
            catch (Exception ex) { }
        }
        //Detect Arduino.
        private bool DetectArduino()
        {
            try
            {
                //Sent message.
                byte[] buffer = new byte[1];
                //The string allows us to piece the individual ASCII characters together.
                string return_message = "";
                //Allows us to receive data.
                int read_int;
                //Go through the data.
                int byte_count;
                buffer[0] = Convert.ToByte(0);
                serial_device.Open();
                serial_device.Write(buffer, 0, 1);
                Thread.Sleep(1000);
                byte_count = serial_device.BytesToRead;
                while (byte_count > 0)
                {
                    read_int = serial_device.ReadByte();
                    return_message = return_message + Convert.ToChar(read_int);
                    byte_count--;
                }
                serial_device.Close();
                if (return_message.Contains("THIS IS ARDUINO!"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
