using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using System.IO.Ports;
using System.Management;
using System.Threading;
using System.IO;

namespace GetPortnamesExample
{
    public partial class Form1 : Form
    {
        const String MAIN_VER = "0";
        const String SUB_VER = "9";

        bool listHasUpgrade = false;
        bool autoUpdrade = false;
        List<String> existComPortList = new List<String>();
        List<String> existArduinoComPortList = new List<String>();
        SerialPort comport;

        public Form1()
        {
            InitializeComponent();
            GetComPortInformation();
        }

        private void GetComPortInformation()
        {
            //listBoxComports.Items.Clear();
            List<ManagementObject> listObj = new List<ManagementObject>();//using System.Management;
            try
            {
                // get only devices that are working properly."
                string query = "SELECT * FROM Win32_PnPEntity WHERE ConfigManagerErrorCode = 0";// get only devices that are working properly."
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
                listObj = searcher.Get().Cast<ManagementObject>().ToList();
                searcher.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            List<String> temp = new List<string>();
            int comPortNumber = 0;
            listHasUpgrade = false;
            foreach (ManagementObject obj in listObj)
            {
                object captionObj = obj["Caption"]; //This will get you the friendly name.
                if (captionObj != null)
                {
                    string caption = captionObj.ToString();
                    if (caption.Contains("(COM")) //This is where I filter on COM-ports.
                    {
                        //listBoxComports.Items.Add(caption);
                        comPortNumber++;
                        temp.Add(caption);
                        if (false ==existComPortList.Exists(x => x == caption))
                        {
                            listHasUpgrade = true;
                        }                   
                    }
                }
            }
            if (comPortNumber != existComPortList.Count)
            {
                listHasUpgrade = true;
                existComPortList.Clear();
            }
            
            if(true == listHasUpgrade)
            {                
                foreach (String item in temp)
                {
                    if (false ==existComPortList.Exists(x => x == item))
                    {
                        existComPortList.Add(item);
                    } 
                }   
            }
        }

        private bool checkArduinoExist(String comPort, int waitTimeToReceivd)
        {
            comport = new SerialPort(comPort, 115200, Parity.None, 8, StopBits.One);
            try
            {
                comport.Open();
                //comport.DiscardInBuffer();
                if (false == comport.IsOpen) 
                {
                    return false;
                }

                Thread.Sleep(waitTimeToReceivd);
                int byteToRead = comport.BytesToRead;
                comport.Close();
                
                if (byteToRead < 21)
                    return false;
                else
                    return true;                
            }             
            catch (Exception ex)            
            {                
                //MessageBox.Show(ex.Message);
            }
            return false;
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            GetComPortInformation();
        }

        private void chkAutoUpgrade_CheckedChanged(object sender, EventArgs e)
        {
            autoUpdrade = chkAutoUpgrade.Checked;
            updradeTimer.Enabled = chkAutoUpgrade.Checked; ;               
        }
        private void upgradeArduinoComPortList()
        {
            existArduinoComPortList.Clear();
            foreach (String comPort in existComPortList)
            {
                int start = comPort.IndexOf("COM");
                int end = comPort.IndexOf(")");
                int num = int.Parse(comPort.Substring(start + 3, (end - start) - "COM".Length));
                String portName = String.Format("COM{0}", num);

                if (true == checkArduinoExist(portName, 8000))
                {
                    existArduinoComPortList.Add(portName);
                }
            }        
        }
        private void chkOnlyShowArduino_CheckedChanged(object sender, EventArgs e)
        {
            if(chkOnlyShowArduino.Checked == true)
            {
                upgradeArduinoComPortList();
            }
            listHasUpgrade = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = String.Format("COM PORT 顯示器   v{0}.{1}" ,MAIN_VER ,SUB_VER);
            autoUpdrade = chkAutoUpgrade.Checked;
            uiTimer.Enabled = true;
            updradeTimer.Enabled = chkAutoUpgrade.Checked;
            checkArduinoTimer.Enabled = false;
        }

        private void uiTimer_Tick(object sender, EventArgs e)
        {
            if (true == autoUpdrade)
            {
                btnManualUpgrade.Visible = false;
            }
            else
            {
                btnManualUpgrade.Visible = true;
            }

            if(true == listHasUpgrade)
            {
                listBoxComports.Items.Clear();

                if (true == chkOnlyShowArduino.Checked)
                {
                    foreach (String comPort in existArduinoComPortList)
                    {
                        listBoxComports.Items.Add(comPort);
                    }
                }
                else
                {
                    foreach (String comPort in existComPortList)
                    {
                        listBoxComports.Items.Add(comPort);
                    }
                }
            }
            if (existComPortList.Count > 0)
                chkOnlyShowArduino.Visible = true;
            else
            {
                chkOnlyShowArduino.Visible = false;
                chkOnlyShowArduino.Checked = false;
            }
        }

        private void updradeTimer_Tick(object sender, EventArgs e)
        {
            GetComPortInformation();
        }

        private void checkArduinoTimer_Tick(object sender, EventArgs e)
        {

        }
    }

}
