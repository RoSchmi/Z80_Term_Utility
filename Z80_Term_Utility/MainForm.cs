// Dieses Programm dient dazu Programme auf den Z80 Rechner: mc-Grafi-Terminal (Term1) oder das Z80 Super EMUF Board zu übertragen und zu starten
// Das Programm wurde aus einer früheren anderen Anwendung abgeleitet, von der noch Funktionen vorhanden sind, die hier nicht genutzt werden.
// Es handelt sich um eine schnell und ohne Überarbeitung zusammenprogrammierte Anwendung, die keinerlei Anspruch auf Freiheit von Fehlern
// oder optimierten, schönen Code erhebt.
//
// Copyright RoSchmi Mai 2019, License Apache 2.0
// Parts of this application ar taken from
// "Basic serial port listening application" by Amund Gjersoe
//
// remove the x before http to get a working link
// Xhttp://www.codeproject.com/Articles/75770/Basic-serial-port-listening-application?msg=4305010#xx4305010xx
// License: CPOL xhttps://www.codeproject.com/info/cpol10.aspx

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
using System.IO;
using System.Xml;
using SerialAccept;

using SerialPortListener.Serial;



namespace Z80_Term_Utility
{
    public partial class MainForm : Form
    {

        //#######  Fields specify the Folder Names and File Names (can be modified) #####
        const string prmSubfolderName = @"RoSchmi\PortParameter";
        const string prmDatName = "PortParameter.xml";

        string SerialDatName = "SerialDats.xml";

        string SelectedFile = "";

        string SelectedWriteFile = "";

        string StartAddress = "4700";

        byte[] fileContentBinary;

        //AutoResetEvent WaitAcknowledge = new AutoResetEvent(false);

        List<byte> ReceivedBytes = new List<byte>();
        List<char> ReceivedChars = new List<char>();

        //###############################################################################




        //###### Fields for processing of serial bytes to strings #######
        bool TakeOverPrepared = false;
        int ByteToSet = 0;
        byte FirstByte = 0x00;
        byte SecondByte = 0x00;
        string DisplayString = "";

        //################################################################



        // Time interval to store incoming data to file
        enum StoreInterval
        {
            minute_05 = 05,   // 30 Sekunden
            minute_1 = 1,     // 1 Minute
            minute_2 = 2,
            minute_4 = 4,
            minute_6 = 6,
            minute_10 = 10,
            minute_15 = 15,
            minute_30 = 30,
            minute_60 = 60,
            minute_120 = 120,  // 2 Std.
            minute_240 = 240,  // 4 Std.
            minute_480 = 480   // 8 Std.
        }

        //Setting the actual used Store-Interval
        // Take your choice

        StoreInterval actStoreInterval = StoreInterval.minute_1;
        // StoreInterval actStoreInterval = StoreInterval.minute_2;
        // StoreInterval actStoreInterval = StoreInterval.minute_60;


        bool DataReceived = false;

        DateTime LastSavedTime = new DateTime(2012, 3, 18, 1, 1, 1);




        string SerialDatsFolderName = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);


        string akt_Path = "";
        string prm_Path = "";



        DataSet SerialDataSet = new DataSet("SerialDataSet");
        DataTable T = new DataTable("T");
        DataColumn B = new DataColumn("B", typeof(string));
        DataTable M = new DataTable("M");
        DataColumn S = new DataColumn("S", typeof(string));

        DataSet ParameterDataSet = new DataSet();


        string Form_PortName = "COM15";
        int Form_BaudRate = 9600;
        int Form_DataBits = 8;
        string Form_Parity = "None";
        string Form_StopBits = "One";

        SerialPortManager _spManager;


        public MainForm()
        {
            InitializeComponent();


            akt_Path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            prm_Path = Path.Combine(akt_Path, @prmSubfolderName);

            textBoxSerialDatsFolderName.Text = SerialDatsFolderName;

            textBoxSerialDatName.Text = SerialDatName;


            #region  Create directory and write / read parameter file for the serial port

            if (!Directory.Exists(prm_Path))
            {
                try
                {
                    Directory.CreateDirectory(prm_Path);
                }
                catch
                {
                    MessageBox.Show(@"Directory could not be created.");
                }
            }
            if (!File.Exists(Path.Combine(prm_Path, prmDatName)))
            {


                DialogResult key =
                   MessageBox.Show("File " + Path.Combine(prm_Path, prmDatName) + " does not exist. \n\n"
                                     + "The file will be created\n"
                                     + "Click >Abbrechen< if you do not want to create the file",
                   "Bestätigung",
                   MessageBoxButtons.OKCancel,
                   MessageBoxIcon.Question);
                if (key == DialogResult.OK)
                {
                    MessageBox.Show("The file will be created");
                    XmlTextWriter writer1 = new XmlTextWriter(Path.Combine(prm_Path, prmDatName), null);
                    writer1.Formatting = Formatting.Indented;
                    writer1.WriteStartDocument();
                    writer1.WriteStartElement("Params");
                    writer1.WriteStartElement("Port");
                    writer1.WriteString("COM3");
                    writer1.WriteEndElement();
                    writer1.WriteStartElement("BaudRate");
                    writer1.WriteString("9600");
                    writer1.WriteEndElement();
                    writer1.WriteStartElement("DataBits");
                    writer1.WriteString("8");
                    writer1.WriteEndElement();
                    writer1.WriteStartElement("Parity");
                    writer1.WriteString("None");
                    writer1.WriteEndElement();
                    writer1.WriteStartElement("StopBits");
                    writer1.WriteString("One");
                    writer1.WriteEndElement();
                    writer1.WriteStartElement("FolderName");
                    writer1.WriteString(SerialDatsFolderName);
                    writer1.WriteEndElement();
                    writer1.WriteStartElement("FileName");
                    writer1.WriteString(SerialDatName);
                    writer1.WriteEndElement();
                    writer1.WriteEndElement();
                    writer1.WriteEndDocument();
                    writer1.Close();
                }
            }
            try
            {
                ParameterDataSet.ReadXml(Path.Combine(prm_Path, prmDatName));
            }
            catch
            {
                MessageBox.Show("File with stored Serial Port Parameters could not be read.");
                return;
            }



            Form_PortName = ParameterDataSet.Tables[0].Rows[0]["Port"].ToString();
            if (Form_PortName.Length > 5)
                Form_PortName = Form_PortName.Substring(0, 5);



            try
            {
                Form_BaudRate = int.Parse(ParameterDataSet.Tables[0].Rows[0]["BaudRate"].ToString());
            }
            catch
            {
            }

            try
            {
                Form_DataBits = int.Parse(ParameterDataSet.Tables[0].Rows[0]["DataBits"].ToString());
            }
            catch
            {
            }
            Form_Parity = ParameterDataSet.Tables[0].Rows[0]["Parity"].ToString();
            Form_StopBits = ParameterDataSet.Tables[0].Rows[0]["StopBits"].ToString();
            SerialDatsFolderName = ParameterDataSet.Tables[0].Rows[0]["FolderName"].ToString();
            textBoxSerialDatsFolderName.Text = SerialDatsFolderName;
            SerialDatName = ParameterDataSet.Tables[0].Rows[0]["FileName"].ToString();
            textBoxSerialDatName.Text = SerialDatName;
            #endregion

            //Get Dataset in which the serial data are stored
            Create_Or_Read_SerialDataSet();

            //dataGridViewData.DataSource = SerialDataSet.Tables["T"];
            dataGridViewData.DataSource = SerialDataSet.Tables["M"];
            dataGridViewData.Columns["S"].Width = 400;

            // Does not work
            //  dataGridViewData.Sort(dataGridViewData.Columns["S"], ListSortDirection.Descending);

            //Initialize 
            UserInitialization();

            SetSerialPortToSavedSettings(Form_PortName, Form_BaudRate, Form_DataBits, Form_Parity, Form_StopBits);

            //Initialize the timer interval used for saving data to file (do not modify)
            
            timer01.Interval = 1000;
            timer01.Tick += new EventHandler(timer01_Tick);
            timer01.Stop();
            

            // timer determines how long the Message "Saving Data" is shown on the form
            timerSaveMessage.Interval = 5000;
            timerSaveMessage.Tick += new EventHandler(timerSaveMessage_Tick);
            timerSaveMessage.Stop();

            timerRestoreColor.Tick += TimerRestoreColor_Tick;
            timerRestoreColor.Stop();


            //Start Listening on Serial Port
            buttonStart_Click_Do();

        }

        private void TimerRestoreColor_Tick(object sender, EventArgs e)
        {
            buttonWriteToDevice.BackColor = Color.LightGray;
            timerRestoreColor.Stop();
        }






        //########## Methods  ##############################################

        #region Method - Create or read DataSet for the incoming Data
        private void Create_Or_Read_SerialDataSet()
        {
            string YearPath = Path.Combine(SerialDatsFolderName, DateTime.Today.Year.ToString());
            //MessageBox.Show(YearPath);
            string MonthPath = Path.Combine(@YearPath, X_Stellig.Zahl(DateTime.Today.Month.ToString(), 2));
            //MessageBox.Show(MonthPath);

            if (!Directory.Exists(@MonthPath))
            {
                try
                {
                    Directory.CreateDirectory(@MonthPath);
                }
                catch
                {
                    MessageBox.Show(@"Directory could not be created.");
                }
            }
            string ActFileName = Path.Combine(@MonthPath, Path.GetFileNameWithoutExtension(SerialDatName) + "_" + DateTime.Today.Year.ToString() + "_" + X_Stellig.Zahl(DateTime.Today.Month.ToString(), 2) + "_" + X_Stellig.Zahl(DateTime.Today.Day.ToString(), 2) + ".xml");
            //MessageBox.Show(ActFileName);


            if (!File.Exists(@ActFileName))
            {
                XmlTextWriter writer1 = new XmlTextWriter(ActFileName, null);
                writer1.Formatting = Formatting.Indented;
                writer1.WriteStartDocument();
                writer1.WriteStartElement("SerialDataSet");
                writer1.WriteStartElement("T");
                writer1.WriteStartElement("B");
                writer1.WriteString("00");
                writer1.WriteEndElement();
                writer1.WriteEndElement();

                writer1.WriteStartElement("M");
                writer1.WriteStartElement("I");
                writer1.WriteString("*");
                writer1.WriteEndElement();
                writer1.WriteStartElement("S");
                writer1.WriteString("*");
                writer1.WriteEndElement();
                writer1.WriteEndElement();

                writer1.WriteEndElement();
                writer1.WriteEndDocument();
                writer1.Close();


            }
            try
            {
                SerialDataSet.ReadXml(ActFileName);
            }
            catch
            {
                MessageBox.Show("File with stored SerialDats could not be read.");
                return;
            }
        }
        #endregion

        #region Method - UserInitialization of Serial Port Settings
        private void UserInitialization()
        {
            _spManager = new SerialPortManager();
            SerialSettings mySerialSettings = _spManager.CurrentSerialSettings;
            serialSettingsBindingSource.DataSource = mySerialSettings;
            portNameComboBox.DataSource = mySerialSettings.PortNameCollection;
            baudRateComboBox.DataSource = mySerialSettings.BaudRateCollection;

            dataBitsComboBox.DataSource = mySerialSettings.DataBitsCollection;
            parityComboBox.DataSource = Enum.GetValues(typeof(System.IO.Ports.Parity));
            stopBitsComboBox.DataSource = Enum.GetValues(typeof(System.IO.Ports.StopBits));


            _spManager.NewSerialDataRecieved += new EventHandler<SerialDataEventArgs>(_spManager_NewSerialDataRecieved);

           // this.FormClosing += new FormClosingEventHandler(MainForm_FormClosing);
        }
        #endregion

        #region Method - SetSerialPortToSavedSettings

        void SetSerialPortToSavedSettings(string pPortName, int pBaudRate, int pDataBits, string pParity, string pStopBits)
        {
            SerialSettings mySerialSettings = _spManager.CurrentSerialSettings;

            if (mySerialSettings.PortNameCollection.Contains(pPortName))
            {
                mySerialSettings.PortName = pPortName;
                portNameComboBox.Text = pPortName;
            }

            if (mySerialSettings.BaudRateCollection.Contains(pBaudRate))
            {
                mySerialSettings.BaudRate = pBaudRate;
                baudRateComboBox.Text = pBaudRate.ToString();
            }

            if (mySerialSettings.DataBitsCollection.Contains(pDataBits))
            {
                mySerialSettings.DataBits = pDataBits;
                dataBitsComboBox.Text = pDataBits.ToString();
            }
            if (Enum.GetNames(typeof(System.IO.Ports.Parity)).Contains(pParity))
            {
                mySerialSettings.Parity = (Parity)Enum.Parse(typeof(System.IO.Ports.Parity), pParity);
                parityComboBox.Text = pParity;
            }
            if (Enum.GetNames(typeof(System.IO.Ports.StopBits)).Contains(pStopBits))
            {
                mySerialSettings.StopBits = (StopBits)Enum.Parse(typeof(System.IO.Ports.StopBits), pStopBits);
                stopBitsComboBox.Text = pStopBits;
            }


        }

        #endregion

        #region Method - Start Listening on Serial Port
        void buttonStart_Click_Do()
        {
          // timer01.Start();
            _spManager.StartListening();
        }
        #endregion

        #region Method - Stop Listening on Serial Port
        // Stop Listening on Serial Port
        void btnStop_Click_Do()
        {
            timer01.Stop();
            _spManager.StopListening();
            Save_DataSet_To_XmlFile(DateTime.Now);


        }
        #endregion

        #region Method - Save_DataSet_To_XmlFile
        void Save_DataSet_To_XmlFile(DateTime SaveTime)
        {
            if (DataReceived)
            {
                textBoxSaveMessage.Text = "Saving Data to File  " + SaveTime.ToLongTimeString();
                textBoxSaveMessage.BackColor = Color.LightSkyBlue;

                SerialDataSet.AcceptChanges();
                string YearPath = Path.Combine(SerialDatsFolderName, DateTime.Today.Year.ToString());
                //MessageBox.Show(YearPath);
                string MonthPath = Path.Combine(@YearPath, X_Stellig.Zahl(DateTime.Today.Month.ToString(), 2));
                //MessageBox.Show(MonthPath);

                if (!Directory.Exists(@MonthPath))
                {
                    try
                    {
                        Directory.CreateDirectory(@MonthPath);
                    }
                    catch
                    {
                        MessageBox.Show(@"Directory could not be created.");
                    }
                }
                string ActFileName = Path.Combine(@MonthPath, Path.GetFileNameWithoutExtension(SerialDatName) + "_" + DateTime.Today.Year.ToString() + "_" + X_Stellig.Zahl(DateTime.Today.Month.ToString(), 2) + "_" + X_Stellig.Zahl(DateTime.Today.Day.ToString(), 2) + ".xml");
                //MessageBox.Show(ActFileName);
                SerialDataSet.WriteXml(ActFileName);

                //This has to be tested wether change of date is processed exactly at the right time
                //For Data of the new day the Dataset has to be cleared
                if (SaveTime.Hour == 0 && SaveTime.Minute == 0)
                {
                    SerialDataSet.Clear();
                }
                timerSaveMessage.Start();
            }
        }
        #endregion

        #region Method ProcessByte to get Characters
        byte ProcessByte(byte actByte)
        {
            const byte CharBitSet = 0x40;
            const byte TakeBitSet = 0x10;


            if ((actByte & CharBitSet) > 0)
            {
                if ((actByte & TakeBitSet) > 0)
                {
                    TakeOverPrepared = true;
                    return 0x00;
                }
                else
                {
                    if (TakeOverPrepared)
                    {
                        if (ByteToSet == 0)
                        {
                            ByteToSet = 1;
                            FirstByte = (byte)(actByte & 0x0F);
                            TakeOverPrepared = false;
                            return 0x00;
                        }
                        else
                        {
                            ByteToSet = 0;
                            SecondByte = (byte)(actByte & 0x0F);
                            TakeOverPrepared = false;
                            byte ReturnByte = 0x00;
                            ReturnByte = GetChar.MyChar(FirstByte, SecondByte);
                            return ReturnByte;
                            //  return GetChar.MyChar(FirstByte, SecondByte);
                        }

                    }
                    else
                    {
                        TakeOverPrepared = true;
                        return 0x00;
                    }
                }

                // MessageBox.Show("CharBitSet");
            }
            else
            {
                return 0x01;
                // MessageBox.Show("CharBitSet not set");
            }

        }
        #endregion

        //########## Events  ###############################################

        #region Event - MainForm Closing
        void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult key =
                   MessageBox.Show("Really want to Close the SerialAccept Program",

                   "Confirm",
                   MessageBoxButtons.YesNo,
                   MessageBoxIcon.Question);
            e.Cancel = (key == DialogResult.No);
            if (key == DialogResult.Yes)
            {
                timer01.Stop();
                _spManager.StopListening();
                Save_DataSet_To_XmlFile(DateTime.Now);
                _spManager.Dispose();
            }

        }
        #endregion

        void writeToDisplay(string pStartAddress, byte[] pFileContentBinary)
        {
            int maxTextLength = 10000; // maximum text length in text box
            tbData2.Text = "";
            int startAddress = int.Parse(pStartAddress, System.Globalization.NumberStyles.HexNumber);

            StringBuilder stringBuilder = new StringBuilder("");
            for (int i = 0; i < fileContentBinary.Length; i++)
            {
                stringBuilder.Clear();
                stringBuilder.Append((startAddress + i).ToString("X4"));
                stringBuilder.Append("   ");
                stringBuilder.Append(fileContentBinary[i].ToString("X2"));
                //stringBuilder.Append("    " + Encoding.ASCII.GetChars(new byte[1] { fileContentBinary[i] })[0]);
                stringBuilder.Append("\r\n");
                tbData2.AppendText(stringBuilder.ToString());
            }

            
            tbData2.ScrollToCaret();

        }


        #region Event - New serial Data received

        void _spManager_NewSerialDataRecieved(object sender, SerialDataEventArgs e)
        {
            if (this.InvokeRequired)
            {

                // Using this.Invoke causes deadlock when closing serial port, and BeginInvoke is good practice anyway.
                this.BeginInvoke(new EventHandler<SerialDataEventArgs>(_spManager_NewSerialDataRecieved), new object[] { sender, e });
                return;
            }


            int maxTextLength = 50000; // maximum text length in text box
            if (tbData1.TextLength > maxTextLength)
                tbData1.Text = tbData1.Text.Remove(0, tbData1.TextLength - maxTextLength);
            //maxTextLength = 500;
            if (tbData3.TextLength > maxTextLength)
                tbData3.Text = tbData3.Text.Remove(0, tbData3.TextLength - maxTextLength);

            StringBuilder stringBuilder = new StringBuilder("");
            StringBuilder stringBuilderChar = new StringBuilder("");
            for (int i = 0; i < e.Data.Length; i++)
            {
                stringBuilder.Append(e.Data[i].ToString("X2"));
                ReceivedBytes.Add(e.Data[i]);
                Char theChar = '.';
                try
                {
                    theChar = Encoding.ASCII.GetChars(new byte[1] { e.Data[i] })[0];
                    ReceivedChars.Add(theChar);
                    
                }
                catch (Exception ex)
                {
                    ReceivedChars.Add(theChar);
                   
                }

                stringBuilderChar.Append(theChar);
                stringBuilder.Append("\r\n");
            }
            
            string str = stringBuilder.ToString();
            string strChars = stringBuilderChar.ToString();


           
            tbData1.AppendText(str);
            tbData1.ScrollToCaret();
            tbData3.AppendText(strChars);
            tbData3.ScrollToCaret();
           

            byte[] TestByteArray = new byte[107] {
                0x00, 0x10, 0x00,
                0x43, 0x53, 0x43, 0x4A, 0x5A, 0x4A,  // :
                0x43, 0x53, 0x43, 0x42, 0x52, 0x42,  // 2
                0x52, 0x42, 0x40, 0x50, 0x40,        // Space
                0x44, 0x54, 0x44, 0x45, 0x55, 0x45,  // E
                0x46, 0x56, 0x46, 0x4E, 0x5E, 0x4E,  // n
                0x46, 0x56, 0x46, 0x44, 0x54, 0x44,  // d
                0x46, 0x56, 0x46, 0x4F, 0x5F, 0x4F,  // o
                0x42, 0x52, 0x42, 0x40, 0x50, 0x40,  // Space
                0x44, 0x54, 0x44, 0x4E, 0x5E, 0x4E,  // N
                0x46, 0x56, 0x46, 0x4F, 0x5F, 0x4F,  // o
                0x47, 0x57, 0x47, 0x42, 0x52, 0x42,  // r
                0x46, 0x56, 0x46, 0x4D, 0x5D, 0x4D,  // m
                0x46, 0x56, 0x46, 0x41, 0x51, 0x41,  // a
                0x46, 0x56, 0x46, 0x4C, 0x5C, 0x4C,  // l
                0x42, 0x52, 0x42, 0x40, 0x50, 0x40,  // Space
                0x42, 0x52, 0x42, 0x40, 0x50, 0x40,  // Space
                0x42, 0x52, 0x42, 0x40, 0x50, 0x40,  // Space
                
                0x08, 0x18, 0x08 };
            /*
            string str = Encoding.ASCII.GetString(TestByteArray);
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] < 0x20 | str[i] > 0x7E)
                {
                    str.Insert(i,".");
                    str.Remove(i+1,1); 
                }
            }

            tbData.AppendText(str);
            tbData.ScrollToCaret();
             */


            /*
            for (int i = 0; i < e.Data.Length; i++)
            {
                row = SerialDataSet.Tables["T"].NewRow();
                myByte[0] = e.Data[i];
                row["b"] = SerialAccept.ByteExtensions.ToHexString(myByte, "-");
                SerialDataSet.Tables["T"].Rows.Add(row);
            }
            */
            DataRow T_row;
            DataRow M_row;
            byte[] myByte = new byte[1];

            for (int i = 0; i < TestByteArray.Length; i++)
            {
                T_row = SerialDataSet.Tables["T"].NewRow();
                myByte[0] = TestByteArray[i];

                T_row["b"] = SerialAccept.ByteExtensions.ToHexString(myByte, "-");
                SerialDataSet.Tables["T"].Rows.Add(T_row);

                byte ReturnByte = ProcessByte(myByte[0]);
                if ((ReturnByte != 0x00) && (ReturnByte != 0x01))  // The byte belongs to a character
                {
                    char c = Encoding.ASCII.GetChars(new byte[] { ReturnByte })[0];
                    DisplayString += c;
                }
                else
                {
                    if (ReturnByte == 0x01)  // The Byte does not belong to a character
                    {

                        if (DisplayString.Length > 0)
                        {


                            M_row = SerialDataSet.Tables["M"].NewRow();
                            M_row["I"] = X_Stellig.Zahl(DateTime.Now.Hour.ToString(), 2) + ":" + X_Stellig.Zahl(DateTime.Now.Minute.ToString(), 2) + ":" + X_Stellig.Zahl(DateTime.Now.Second.ToString(), 2) + ":" + X_Stellig.Zahl(DateTime.Now.Millisecond.ToString(), 3);

                            M_row["S"] = DisplayString;
                            SerialDataSet.Tables["M"].Rows.Add(M_row);
                            DisplayString = "";
                        }

                    }

                }

            }


            DataReceived = true;

        }

        #endregion

        #region Event - timer_01_Tick (Store data in file)

        void timer01_Tick(object sender, EventArgs e)
        {

            if ((DateTime.Now.Second == 30) & (LastSavedTime.Second != 30))
            {
                if (actStoreInterval == StoreInterval.minute_05)
                {
                    Save_DataSet_To_XmlFile(DateTime.Now);
                    LastSavedTime = DateTime.Now;
                }
            }

            int MyMinuteInterval = (int)actStoreInterval;
            //  int MyHourInterval = (int)actStoreInterval / 60;

            if (actStoreInterval == StoreInterval.minute_05)
            {
                MyMinuteInterval = 1;
            }

            if ((DateTime.Now.Second == 00) & (LastSavedTime.Second != 00))
            {

                //Der Modulo-Operator % berechnet den Rest nach der Division seines ersten Operanden durch seinen zweiten.

                //if ((MyHourInterval * 60 + DT.Minute) % MyMinuteInterval == 0)
                if ((DateTime.Now.Hour * 60 + DateTime.Now.Minute) % MyMinuteInterval == 0)
                {
                    // Debug.Print("Stunde: " + DT.Hour.ToString() + " Minute: " + DT.Minute.ToString() + " " + ((DT.Hour * 60 + DT.Minute) % MyMinuteInterval).ToString());

                    Save_DataSet_To_XmlFile(DateTime.Now);

                    LastSavedTime = DateTime.Now;
                }


            }
            else
            {
                LastSavedTime = DateTime.Now;
            }
        }

        #endregion

        #region Event - timerSaveMessage_Tick
        //This timer clears the Message that Data are saved to file after timer interval
        void timerSaveMessage_Tick(object sender, EventArgs e)
        {
            textBoxSaveMessage.Text = "";
            textBoxSaveMessage.BackColor = Color.WhiteSmoke;
            timerSaveMessage.Stop();
        }
        #endregion


        //######## Button Click Events  ####################################

        #region Button Click - Start Listening on Serial port
        // Handles the "Start Listening"-buttom click event

        private void buttonStart_Click(object sender, EventArgs e)
        {

           buttonStart_Click_Do();


            // Create a new SerialPort object with default settings.


            // Allow the user to set the appropriate properties.
            /*
            serialPort1.PortName = SetPortName(_serialPort.PortName);
            serialPort1.BaudRate = SetPortBaudRate(_serialPort.BaudRate);
            serialPort1.Parity = SetPortParity(_serialPort.Parity);
            serialPort1.DataBits = SetPortDataBits(_serialPort.DataBits);
            serialPort1.StopBits = SetPortStopBits(_serialPort.StopBits);
            serialPort1.Handshake = SetPortHandshake(_serialPort.Handshake);
            */
            /*
            serialPort2.PortName = "COM24";
            serialPort2.BaudRate = 38400;
            serialPort2.Parity = Parity.None;
            serialPort2.DataBits = 8;
            serialPort2.StopBits = System.IO.Ports.StopBits.One;
            serialPort2.Handshake = System.IO.Ports.Handshake.None;
            serialPort2.ReadTimeout = 5000;
            serialPort2.WriteTimeout = 5000;


            serialPort2.Open();
            _continue = true;
            readThread.Start();
             */
        }


        #endregion


        #region Button Click - Stop Listening on serial port
        // Handles the "Stop Listening"-buttom click event
        private void btnStop_Click(object sender, EventArgs e)
        {
            btnStop_Click_Do();
        }



        #endregion


        #region Button Click - Write modified serial port Parameters to file
        //Write modified serial port Parameters to file
        private void buttonSaveParameters_Click(object sender, EventArgs e)
        {
            //Char[] Invalid;
            //Invalid = Path.GetInvalidFileNameChars();
            //MessageBox.Show(Invalid[0].ToString() + " " + Invalid[1].ToString());
            try
            {
                Path.GetFileName(Path.Combine(@textBoxSerialDatsFolderName.Text, @textBoxSerialDatName.Text));
            }
            catch
            {
                MessageBox.Show("Invalid Filename!");
                return;
            }

            ParameterDataSet.Tables[0].Rows[0]["Port"] = portNameComboBox.Text;
            ParameterDataSet.Tables[0].Rows[0]["BaudRate"] = baudRateComboBox.Text;
            ParameterDataSet.Tables[0].Rows[0]["DataBits"] = dataBitsComboBox.Text;
            ParameterDataSet.Tables[0].Rows[0]["Parity"] = parityComboBox.Text;
            ParameterDataSet.Tables[0].Rows[0]["StopBits"] = stopBitsComboBox.Text;
            ParameterDataSet.Tables[0].Rows[0]["FolderName"] = textBoxSerialDatsFolderName.Text;
            ParameterDataSet.Tables[0].Rows[0]["FileName"] = textBoxSerialDatName.Text;
            ParameterDataSet.AcceptChanges();
            ParameterDataSet.WriteXml(Path.Combine(prm_Path, prmDatName));
            ParameterDataSet.Clear();
            ParameterDataSet.AcceptChanges();
            ParameterDataSet.ReadXml(Path.Combine(prm_Path, prmDatName));
            ParameterDataSet.AcceptChanges();
        }
        #endregion


        #region Button Click - Browse for new directory to save the incoming serial data
        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = textBoxSerialDatsFolderName.Text;
            folderBrowserDialog1.ShowDialog();
            SerialDatsFolderName = folderBrowserDialog1.SelectedPath;
            textBoxSerialDatsFolderName.Text = folderBrowserDialog1.SelectedPath;
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void buttonCRLF_Click(object sender, EventArgs e)
        {

            byte[] arrayToSend = Encoding.UTF8.GetBytes(textBoxSendSerial.Text + "\r\n");
            textBoxSendSerial.Text = "";
            _spManager.WriteDataToSend(arrayToSend);
            _spManager.DataToSendAvailable = true;
        }

        private void buttonSetGraphMode_Click(object sender, EventArgs e)
        {
            byte[] arrayToSend = new byte[3] { 0x1B, 0x1B, 0x47 };
            _spManager.WriteDataToSend(arrayToSend);
            _spManager.DataToSendAvailable = true;
        }

        private void buttonSetTextMode_Click(object sender, EventArgs e)
        {
            byte[] arrayToSend = new byte[3] { 0x1B, 0x1B, 0x41 };
            _spManager.WriteDataToSend(arrayToSend);
            _spManager.DataToSendAvailable = true;
        }

        private void buttonClearScreen_Click(object sender, EventArgs e)
        {
            byte[] arrayToSend = new byte[1] { 0x5A };
            _spManager.WriteDataToSend(arrayToSend);
            _spManager.DataToSendAvailable = true;
            Thread.Sleep(200);
            arrayToSend = new byte[1] { 0x1A };
            _spManager.WriteDataToSend(arrayToSend);
            _spManager.DataToSendAvailable = true;
        }





        private void buttonCR_Click(object sender, EventArgs e)
        {
            byte[] arrayToSend = Encoding.UTF8.GetBytes(textBoxSendSerial.Text + "\r");
            textBoxSendSerial.Text = "";
            _spManager.WriteDataToSend(arrayToSend);
            _spManager.DataToSendAvailable = true;
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            byte[] arrayToSend = Encoding.UTF8.GetBytes(textBoxSendSerial.Text);
            textBoxSendSerial.Text = "";
            if (arrayToSend.Length > 0)
            {
                _spManager.WriteDataToSend(arrayToSend);

                _spManager.DataToSendAvailable = true;
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_spManager.portCouldBeOpened)
            {
                MessageBox.Show("Port could not be opened");
            }
        }

        private void tabPage1_SizeChanged(object sender, EventArgs e)
        {
           buttonStart_Click_Do();
        }

        private void buttonSelectReadFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = null;
            openFileDialog1.FileName = textBoxSelectedFile.Text;
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            textBoxSelectedFile.Text = openFileDialog1.SafeFileName;
            SelectedFile = openFileDialog1.FileName;
        }

        private void buttonGetData_Click(object sender, EventArgs e)
        {
            if ((SelectedFile != "") && (new FileInfo(SelectedFile).Length < 10000) && (new FileInfo(SelectedFile).Exists))
            {

                fileContentBinary = File.ReadAllBytes(SelectedFile);

                writeToDisplay(textBoxStartAddress.Text, fileContentBinary);
            }
            else
            {
                MessageBox.Show("File doesn't exist or is to long");
            }

        }

        private void textBoxStartAddress_TextChanged(object sender, EventArgs e)
        {
            if (textBoxStartAddress.Text.Length > 4)
            {
                textBoxStartAddress.Text = textBoxStartAddress.Text.Substring(0, 4);
            }
            textBoxStartAddress_Validating(sender, new CancelEventArgs(true));
        }

        private void textBoxStartAddress_Validating(object sender, CancelEventArgs e)
        {
            char[] allowedChars = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };

            char[] charArray = textBoxStartAddress.Text.ToCharArray();


            for (int i = 0; i < charArray.Length; i++)
            {
                if (!allowedChars.Contains(charArray[i]))
                {
                    System.Windows.Forms.MessageBox.Show(string.Format("'{0}' is not a hexadecimal character", charArray[i]));
                    charArray[i] = '0';
                    textBoxStartAddress.Text = new string(charArray);
                    e.Cancel = false;
                }
            }
        }

        private void textBoxStartAddressRead_TextChanged(object sender, EventArgs e)
        {
            if (textBoxStartAddressRead.Text.Length > 4)
            {
                textBoxStartAddressRead.Text = textBoxStartAddressRead.Text.Substring(0, 4);
            }
            textBoxStartAddressRead_Validating(sender, new CancelEventArgs(true));
        }

        private void textBoxStartAddressRead_Validating(object sender, CancelEventArgs e)
        {
            char[] allowedChars = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };

            char[] charArray = textBoxStartAddressRead.Text.ToCharArray();


            for (int i = 0; i < charArray.Length; i++)
            {
                if (!allowedChars.Contains(charArray[i]))
                {
                    System.Windows.Forms.MessageBox.Show(string.Format("'{0}' is not a hexadecimal character", charArray[i]));
                    charArray[i] = '0';
                    textBoxStartAddressRead.Text = new string(charArray);
                    e.Cancel = false;
                }
            }
        }

        private void textBoxEndAddressRead_TextChanged(object sender, EventArgs e)
        {
            if (textBoxEndAddressRead.Text.Length > 4)
            {
                textBoxEndAddressRead.Text = textBoxEndAddressRead.Text.Substring(0, 4);
            }
            textBoxEndAddressRead_Validating(sender, new CancelEventArgs(true));
        }

        private void textBoxEndAddressRead_Validating(object sender, CancelEventArgs e)
        {
            char[] allowedChars = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };

            char[] charArray = textBoxEndAddressRead.Text.ToCharArray();


            for (int i = 0; i < charArray.Length; i++)
            {
                if (!allowedChars.Contains(charArray[i]))
                {
                    System.Windows.Forms.MessageBox.Show(string.Format("'{0}' is not a hexadecimal character", charArray[i]));
                    charArray[i] = '0';
                    textBoxEndAddressRead.Text = new string(charArray);
                    e.Cancel = false;
                }
            }
        }




        private void buttonWriteToDevice_Click(object sender, EventArgs e)
        {
            if ((fileContentBinary != null) && (fileContentBinary.Length > 0))
            {
                int startAddress = int.Parse(textBoxStartAddressRead.Text, System.Globalization.NumberStyles.HexNumber);
                textBoxEndAddressRead.Text = (fileContentBinary.Length + startAddress - 1).ToString("X4");
                buttonWriteToDevice.BackColor = Color.LightGreen;
                WriteFileToDevice_Do(textBoxStartAddress.Text, fileContentBinary);
                timerRestoreColor.Start();
            }
        }

        void WriteFileToDevice_Do(string pStartAddress, byte[] pFileContentBinary)
        {
            int startAddress = int.Parse(pStartAddress, System.Globalization.NumberStyles.HexNumber);

            byte[] arrayToSend = new byte[0];
            StringBuilder stringBuilder = new StringBuilder("");
            if (radioButton_Term_1.Checked)
            {
                _spManager.SendHardwareFlowControl = false;
                arrayToSend = new byte[3] { 0x1B, 0x1B, 0x47 };
                _spManager.WriteDataToSend(arrayToSend);
                _spManager.DataToSendAvailable = true;
                while (_spManager.DataToSendAvailable == true)
                {
                    Thread.Sleep(1);
                }

                _spManager.WriteDataToSend(arrayToSend);
                _spManager.DataToSendAvailable = true;
                while (_spManager.DataToSendAvailable == true)
                {
                    Thread.Sleep(1);
                }
                stringBuilder = new StringBuilder("");
                stringBuilder.Append("WD $");
                stringBuilder.Append(startAddress.ToString("X4"));
                stringBuilder.Append(" ");
                stringBuilder.Append(pFileContentBinary[0].ToString("X2"));

                arrayToSend = Encoding.UTF8.GetBytes(stringBuilder.ToString());
                _spManager.WriteDataToSend(arrayToSend);
                _spManager.DataToSendAvailable = true;
                while (_spManager.DataToSendAvailable == true)
                {
                    Thread.Sleep(1);
                }
                //for (int i = 0; i < pFileContentBinary.Length; i++)
                for (int i = 1; i < pFileContentBinary.Length; i++)
                {
                    stringBuilder.Clear();
                    stringBuilder.Append(" $");
                    stringBuilder.Append(pFileContentBinary[i].ToString("X2"));
                    //stringBuilder.Append(" ");
                    arrayToSend = Encoding.UTF8.GetBytes(stringBuilder.ToString());
                    _spManager.WriteDataToSend(arrayToSend);
                    _spManager.DataToSendAvailable = true;
                    while (_spManager.DataToSendAvailable == true)
                    {
                        Thread.Sleep(1);
                    }
                }
                stringBuilder.Clear();
                stringBuilder.Append("\r");
                arrayToSend = Encoding.UTF8.GetBytes(stringBuilder.ToString());
                _spManager.WriteDataToSend(arrayToSend);
                _spManager.DataToSendAvailable = true;
                {
                    Thread.Sleep(1);
                }
            }

            if (radioButton_S_EMUF.Checked)
            {
                _spManager.SendHardwareFlowControl = false;
                int length = pFileContentBinary.Length - 1;
                int first = length / 256;
                int second = length < 65535 ? length % 256 : 256;
                arrayToSend = new byte[1] { (byte)first }; 
                _spManager.WriteDataToSend(arrayToSend);
                _spManager.DataToSendAvailable = true;
                while (_spManager.DataToSendAvailable == true)
                {
                    Thread.Sleep(1);
                }
                Thread.Sleep(1);
                arrayToSend = new byte[1] { (byte)second };
                _spManager.WriteDataToSend(arrayToSend);
                _spManager.DataToSendAvailable = true;
                while (_spManager.DataToSendAvailable == true)
                {
                    Thread.Sleep(1);
                }
                Thread.Sleep(1);

                for (int i = 0; i < pFileContentBinary.Length; i++)
                {
                    arrayToSend = new byte[1] { pFileContentBinary[i] };
                    _spManager.WriteDataToSend(arrayToSend);
                    _spManager.DataToSendAvailable = true;
                    while (_spManager.DataToSendAvailable == true)
                    {
                        Thread.Sleep(1);
                    }
                    Thread.Sleep(1);
                }


            }
           
            if (radioButtonSC_MP.Checked)
            {
                if (_spManager.SerialBaudRate != 600)
                {
                    MessageBox.Show("For SC/MP the Baudrate must be set to 600");
                }
                else
                {
                    //_spManager.SendHardwareFlowControl = true;
                    for (int i = 0; i < pFileContentBinary.Length; i++)
                    {
                        arrayToSend = new byte[1] { pFileContentBinary[i] };
                        _spManager.WriteDataToSend(arrayToSend);
                        _spManager.DataToSendAvailable = true;
                        while (_spManager.DataToSendAvailable == true)
                        {
                            Thread.Sleep(1);
                        }
                        Thread.Sleep(1);
                    }
                   // _spManager.SendHardwareFlowControl = false;
                }
            }           
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            textBoxStartAddress.Text = StartAddress;
            textBoxStartAt.Text = StartAddress;
            textBoxStartAddressRead.Text = StartAddress;
            textBoxEndAddressRead.Text = StartAddress;
            radioButton_S_EMUF.Checked = true;
            radioButtonCR.Checked = true;
        }

        private void buttonReadFromDevice_Click(object sender, EventArgs e)
        {
            ReceivedBytes = new List<byte>();
            ReadFromDevice_Do(textBoxStartAddressRead.Text, textBoxEndAddressRead.Text);
        }

        void ReadFromDevice_Do(string pStartAddress, string pEndAddress)
        {
            tbData1.Text = "";
            Application.DoEvents();
            Thread.Sleep(100);
            int startAddress = int.Parse(pStartAddress, System.Globalization.NumberStyles.HexNumber);
            int endAddress = int.Parse(pEndAddress, System.Globalization.NumberStyles.HexNumber);
            textBoxFirstCommand.Text = "WD $" + startAddress.ToString("X4") + " $" + fileContentBinary[0].ToString("X2");
            StringBuilder stringBuilder = new StringBuilder("");
            //for (int i = 0; i < ((endAddress - startAddress) + 2); i++)

            byte[] arrayToSend = new byte[3] { 0x1B, 0x1B, 0x47 };
            _spManager.WriteDataToSend(arrayToSend);
            _spManager.DataToSendAvailable = true;
            while (_spManager.DataToSendAvailable == true)
            {
                Thread.Sleep(1);
            }
            Thread.Sleep(1);

            _spManager.WriteDataToSend(arrayToSend);
            _spManager.DataToSendAvailable = true;
            while (_spManager.DataToSendAvailable == true)
            {
                Thread.Sleep(1);
            }
            Thread.Sleep(1);

            for (int i = 0; i < ((endAddress - startAddress) + 1); i++)
                {
                stringBuilder.Clear();
                stringBuilder.Append("WF $");
                stringBuilder.Append((startAddress + i).ToString("X4"));
                
                stringBuilder.Append("\r\n");
                arrayToSend = Encoding.UTF8.GetBytes(stringBuilder.ToString());
                _spManager.WriteDataToSend(arrayToSend);
                _spManager.DataToSendAvailable = true;
                              
                while (_spManager.DataToSendAvailable == true)
                {
                    Thread.Sleep(1);
                }               
            }
            Thread.Sleep(1);
        }
        /*
        private void buttonDoFirstCommand_Click(object sender, EventArgs e)
        {
            byte[] arrayToSend = Encoding.UTF8.GetBytes(textBoxFirstCommand.Text + "\r");
            if (textBoxFirstCommand.Text.Length > 9)
            {
                textBoxFirstCommand.Text = "WF $" + textBoxFirstCommand.Text.Substring(4, 5);
            }
            
            _spManager.WriteDataToSend(arrayToSend);
            _spManager.DataToSendAvailable = true;
        }
        */
        private void buttonCompareWriteAndRead_Click(object sender, EventArgs e)
        {
            textBoxCompareResult.Text = "";
            Thread.Sleep(200);
            byte[] ReadBytes = ReceivedBytes.ToArray<byte>();
            int endAddress = int.Parse(textBoxEndAddressRead.Text, System.Globalization.NumberStyles.HexNumber);
            int startAddress = int.Parse(textBoxStartAddressRead.Text, System.Globalization.NumberStyles.HexNumber);
            int firstMismatch = -1;
            for (int i = 0; i < endAddress - startAddress + 1; i++)
            {
                if (ReadBytes[i] != fileContentBinary[i])
                {
                    firstMismatch = i;
                    break;
                }
            }
            if (firstMismatch != -1)
            {
                textBoxCompareResult.Text = "Comp-Error at " + firstMismatch.ToString("X4");
            }
            else
            {
                textBoxCompareResult.Text = "Result: Euqal";
            }
            
        }

        private void buttonStartOnDevice_Click(object sender, EventArgs e)
        {
            if (textBoxCompareResult.Text == "Result: Euqal")
            {
                byte[] arrayToSend = Encoding.UTF8.GetBytes("WE $" + textBoxStartAddressRead.Text + "\r");
                _spManager.WriteDataToSend(arrayToSend);
                _spManager.DataToSendAvailable = true;
            }
            else
            {
                MessageBox.Show("Not started, Compare Result is not equal");
            }
        }

        

        private void buttonEsc_Click(object sender, EventArgs e)
        {
            byte[] arrayToSend = new byte[1] { 0x1B };            
            textBoxSendSerial.Text = "";
            _spManager.WriteDataToSend(arrayToSend);
            _spManager.DataToSendAvailable = true;
        }

        private void textBoxStartAt_TextChanged(object sender, EventArgs e)
        {
            if (textBoxStartAt.Text.Length > 4)
            {
                textBoxStartAt.Text = textBoxStartAt.Text.Substring(0, 4);
            }
            textBoxStartAt_Validating(sender, new CancelEventArgs(true));
        }

        private void textBoxStartAt_Validating(object sender, CancelEventArgs e)
        {
            char[] allowedChars = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };

            char[] charArray = textBoxStartAt.Text.ToCharArray();


            for (int i = 0; i < charArray.Length; i++)
            {
                if (!allowedChars.Contains(charArray[i]))
                {
                    System.Windows.Forms.MessageBox.Show(string.Format("'{0}' is not a hexadecimal character", charArray[i]));
                    charArray[i] = '0';
                    textBoxStartAt.Text = new string(charArray);
                    e.Cancel = false;
                }
            }
        }

        private void buttonStartAt_Click(object sender, EventArgs e)
        {
            byte[] arrayToSend = Encoding.UTF8.GetBytes("WE $" + textBoxStartAt.Text + "\r");           
            _spManager.WriteDataToSend(arrayToSend);
            _spManager.DataToSendAvailable = true;
        }

        private void textBoxSendSerial_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
               byte[] arrayToSend = Encoding.UTF8.GetBytes(textBoxSendSerial.Text + "\r");
               textBoxSendSerial.Text = "";
               _spManager.WriteDataToSend(arrayToSend);
               _spManager.DataToSendAvailable = true;
           }
        }

        private void textBoxImmediateSend_KeyUp(object sender, KeyEventArgs e)
        {
            var theData = e.KeyData;
            int theValue = e.KeyValue;
            var theCode = e.KeyCode;
            

           

            switch (e.KeyData)
            {
                case Keys.Enter:
                    {                  
                        theValue = 0x0D;                      
                    }
                    break;
                case Keys.Control:
                case Keys.ControlKey:
                    {
                        theValue = 0;
                        break;
                    }
                case Keys.Shift:
                case Keys.ShiftKey:
                    {
                        theValue = 0;
                        break;
                    }
                case Keys.Alt:
                case Keys.Menu:
                    {
                        theValue = 0;
                    }
                    break;
                    default:
                    {
                        if (!e.Shift)
                        {
                            theValue = theValue | 0x20;                            
                        }

                        if (e.Control)
                        {
                            theValue = theValue & (int)0x9F;                           
                        }
                    }
                    break;
            }

            if (theValue != 0)
            {
                byte[] arrayToSend = new byte[1] { (byte)theValue };

                _spManager.WriteDataToSend(arrayToSend);
                _spManager.DataToSendAvailable = true;
                while (_spManager.DataToSendAvailable == true)
                {
                    Thread.Sleep(1);
                }
                Thread.Sleep(1);
                if (radioButtonCRLF.Checked && arrayToSend[0] == 0x0D)
                {
                    arrayToSend = new byte[1] { 0x0A };
                    
                    _spManager.WriteDataToSend(arrayToSend);
                    _spManager.DataToSendAvailable = true;
                    while (_spManager.DataToSendAvailable == true)
                    {
                        Thread.Sleep(1);
                    }
                    Thread.Sleep(1);
                }

            }
        }

        private void radioButton_S_EMUF_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_S_EMUF.Checked)
            {
                textBoxStartAddress.Text = "8000";
            }
        }

        private void radioButton_Term_1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_Term_1.Checked)
            {
                textBoxStartAddress.Text = "4700";
            }
        }

        private void radioButtonSC_MP_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonSC_MP.Checked)
            {
                textBoxStartAddress.Text = "2000";
            }
        }

       

        private void buttonDoFirstCommand_Click(object sender, EventArgs e)
        {
            byte[] arrayToSend = Encoding.UTF8.GetBytes(textBoxFirstCommand.Text + "\r");

            if (textBoxFirstCommand.Text.Length > 9)

            {
                textBoxFirstCommand.Text = "WF $" + textBoxFirstCommand.Text.Substring(4, 5);
            }
            _spManager.WriteDataToSend(arrayToSend);

            _spManager.DataToSendAvailable = true;
        }

        private void buttonSelectWriteFile_Click(object sender, EventArgs e)
        {
            saveFileDialog1.InitialDirectory = null;
            saveFileDialog1.FileName = textBoxSelectWriteFile.Text;
            saveFileDialog1.ShowDialog();
            
        }

        private void buttonWriteToFile_Click(object sender, EventArgs e)
        {
            if (SelectedWriteFile != "")
            {
                byte[] WriteBytes = ReceivedBytes.ToArray<byte>();

                File.WriteAllBytes(SelectedWriteFile, WriteBytes);           
            }
            else
            {
                MessageBox.Show("No Filename selected");
            }
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            textBoxSelectWriteFile.Text = Path.GetFileName(saveFileDialog1.FileName);
            SelectedWriteFile = saveFileDialog1.FileName;
        }

        private void buttonClearWrite_Click(object sender, EventArgs e)
        {
            ReceivedBytes = new List<byte>();
            tbData1.Text = "";
        }
    }
}
   


        /*
        public static string SetPortName(string defaultPortName)
        {
            string portName;

            Console.WriteLine("Available Ports:");
            foreach (string s in SerialPort.GetPortNames())
            {
                Console.WriteLine("   {0}", s);
            }

            Console.Write("COM port({0}): ", defaultPortName);
            portName = Console.ReadLine();

            if (portName == "")
            {
                portName = defaultPortName;
            }
            return portName;
        }
        */



        /*
        public static void Read()
        {
           // Form1 myform1 = new Form1();
            string message = "";

            MessageBox.Show("Bin in Read");
            serialPort2.DiscardInBuffer();
            if (serialPort2.IsOpen)
            {
                MessageBox.Show("Serialport is open");
            }

            while (_continue)
            {
                    try
                    {
                        message = serialPort2.ReadLine();
                        //myform1.textBox1.Text = message;

                       MessageBox.Show(message);
                       // Console.WriteLine(message);
                    }
                    catch (TimeoutException) { }
                

               
            
                //MessageBox.Show("Bin in While");
                //try
                //{
                //    message = "";
                //
                //    if (serialPort2.BytesToRead > 0)
                //    {
                //        MessageBox.Show("Daten vorhanden");
                //    }
                //    else
                //    {
                //        MessageBox.Show("Bytes to read: " + serialPort2.BytesToRead.ToString());
                //    }
                //   //message = serialPort2.ReadChar().ToString();
                //    byte[] b = new byte[10];
                //    b = Encoding.UTF8.GetBytes(serialPort2.ReadChar().ToString());
                //    message = b[0].ToString();

                    //(byte)serialPort2.ReadChar();
                    //message = serialPort2.ReadLine();

                //    if (message != "")
                //    {
                 //       MessageBox.Show("Message =: " + message);
                 //   }

                //}
               // catch (TimeoutException) { }
               

            }
            MessageBox.Show("Verlasse Read");
        }
        */


        /*
        public static string SetPortName(string defaultPortName)
        {
            string portName;

            Console.WriteLine("Available Ports:");
            foreach (string s in SerialPort.GetPortNames())
            {
                Console.WriteLine("   {0}", s);
            }

            Console.Write("COM port({0}): ", defaultPortName);
            portName = Console.ReadLine();

            if (portName == "")
            {
                portName = defaultPortName;
            }
            return portName;
        }
        */
        /*
        public static int SetPortBaudRate(int defaultPortBaudRate)
        {
            string baudRate;

            Console.Write("Baud Rate({0}): ", defaultPortBaudRate);
            baudRate = Console.ReadLine();

            if (baudRate == "")
            {
                baudRate = defaultPortBaudRate.ToString();
            }

            return int.Parse(baudRate);
        }
        */
        /*
        public static Parity SetPortParity(Parity defaultPortParity)
        {
            string parity;

            Console.WriteLine("Available Parity options:");
            foreach (string s in Enum.GetNames(typeof(Parity)))
            {
                Console.WriteLine("   {0}", s);
            }

            Console.Write("Parity({0}):", defaultPortParity.ToString());
            parity = Console.ReadLine();

            if (parity == "")
            {
                parity = defaultPortParity.ToString();
            }

            return (Parity)Enum.Parse(typeof(Parity), parity);
        }
         */
        /*
        public static int SetPortDataBits(int defaultPortDataBits)
        {
            string dataBits;

            Console.Write("Data Bits({0}): ", defaultPortDataBits);
            dataBits = Console.ReadLine();

            if (dataBits == "")
            {
                dataBits = defaultPortDataBits.ToString();
            }

            return int.Parse(dataBits);
        }
        */
        /*
        public static StopBits SetPortStopBits(StopBits defaultPortStopBits)
        {
            string stopBits;

            Console.WriteLine("Available Stop Bits options:");
            foreach (string s in Enum.GetNames(typeof(StopBits)))
            {
                Console.WriteLine("   {0}", s);
            }

            Console.Write("Stop Bits({0}):", defaultPortStopBits.ToString());
            stopBits = Console.ReadLine();

            if (stopBits == "")
            {
                stopBits = defaultPortStopBits.ToString();
            }

            return (StopBits)Enum.Parse(typeof(StopBits), stopBits);
        }
        */
        /*
        public static Handshake SetPortHandshake(Handshake defaultPortHandshake)
        {
            string handshake;

            Console.WriteLine("Available Handshake options:");
            foreach (string s in Enum.GetNames(typeof(Handshake)))
            {
                Console.WriteLine("   {0}", s);
            }

            Console.Write("Stop Bits({0}):", defaultPortHandshake.ToString());
            handshake = Console.ReadLine();

            if (handshake == "")
            {
                handshake = defaultPortHandshake.ToString();
            }

            return (Handshake)Enum.Parse(typeof(Handshake), handshake);
        }
         */






        //  private void buttonStop_Click(object sender, EventArgs e)
        //  {
        /*
        while (_continue)
        {
            message = Console.ReadLine();

            if (stringComparer.Equals("quit", message))
            {
                _continue = false;
            }
            else
            {
                _serialPort.WriteLine(
                    String.Format("<{0}>: {1}", name, message));
            }
        }
        */
        //  _continue = false;
        //  readThread.Join();
        //  serialPort2.Close();
        // }
    






/*
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Z80_Term_Utility
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
*/
