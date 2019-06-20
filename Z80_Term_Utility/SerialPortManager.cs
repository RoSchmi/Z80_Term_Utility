// from "Basic serial port listening application" by Amund Gjersoe
//
// remove the x before http to get a working link
// Xhttp://www.codeproject.com/Articles/75770/Basic-serial-port-listening-application?msg=4305010#xx4305010xx



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Reflection;
using System.ComponentModel;
using System.Threading;
using System.IO;
using System.Windows.Forms;

namespace SerialPortListener.Serial
{
    /// <summary>
    /// Manager for serial port data
    /// </summary>
    public class SerialPortManager : IDisposable
    {
        Thread SendThread;

        private static readonly object LockProgram = new object();
        public bool portCouldBeOpened = false;

        public bool SendHardwareFlowControl = false;

        public int SerialBaudRate
        {
            get{ return _serialPort.BaudRate; }
        }

        public SerialPortManager()
        {
            // Finding installed serial ports on hardware

            string[] ComPorts = System.IO.Ports.SerialPort.GetPortNames();


            

            _currentSerialSettings.PortNameCollection = SerialPort.GetPortNames();

            string[] PortNameArrray = _currentSerialSettings.PortNameCollection;


            for (int i = 0; i < PortNameArrray.Length; i++ )
            {
                if (PortNameArrray[i].Length > 5)
                    PortNameArrray[i] = PortNameArrray[i].Substring(0, 5);
            }

            _currentSerialSettings.PortNameCollection = PortNameArrray;
                
            
            _currentSerialSettings.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(_currentSerialSettings_PropertyChanged);

            // If serial ports is found, we select the first found
            if (_currentSerialSettings.PortNameCollection.Length > 0)
                _currentSerialSettings.PortName = _currentSerialSettings.PortNameCollection[0];

            SendThread = new Thread(new ThreadStart(runSendThread));
            SendThread.Start();
           
        }

        private void runSendThread()
        {
            while (true)
            {
                if (DataToSendAvailable)
                {
                    if (SendHardwareFlowControl)
                    {
                        // doesn't work, so it is outcommented

                        //_serialPort.Handshake = Handshake.RequestToSend;
                        //_serialPort.DtrEnable = true;
                        //_serialPort.RtsEnable = true;
                    }
                    

                    lock (LockProgram)
                    {
                        for (int i = 0; i < DataToSend.Length; i++)
                        {
                            byte[] theByte = new byte[1] { DataToSend[i] };                                                           
                            _serialPort.Write(theByte, 0, 1);                                                                           
                            Thread.Sleep(1);
                        }                                              
                        DataToSendAvailable = false;
                    }                  
                    _serialPort.Handshake = Handshake.None;
                    SendHardwareFlowControl = false;

                }
                Thread.Sleep(50);
            }
        }

        ~SerialPortManager()
        {
            Dispose(false);
        }


        #region Fields
        private SerialPort _serialPort;
        private SerialSettings _currentSerialSettings = new SerialSettings();
        private string _latestRecieved = String.Empty;
        public event EventHandler<SerialDataEventArgs> NewSerialDataRecieved;


        private byte[] DataToSend = new byte[0];
        public bool DataToSendAvailable = false;

        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the current serial port settings
        /// </summary>
        public SerialSettings CurrentSerialSettings
        {
            get { return _currentSerialSettings; }
            set { _currentSerialSettings = value; }
        }

      

        #endregion

        #region Event handlers

        void  _currentSerialSettings_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
             // if serial port is changed, a new baud query is issued
            if (e.PropertyName.Equals("PortName"))
                UpdateBaudRateCollection();
        }

        void _serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int nbrDataRead = 0;
            byte[] data;
            lock (LockProgram)
            {
                int dataLength = _serialPort.BytesToRead;
                data = new byte[dataLength];
                nbrDataRead = _serialPort.Read(data, 0, dataLength);
            }
            if (nbrDataRead == 0)
                return;
            
            // Send data to whom ever interested
            if (NewSerialDataRecieved != null)
                NewSerialDataRecieved(this, new SerialDataEventArgs(data));
        }

        #endregion

        #region Methods

        public void WriteDataToSend(byte[] arrayToSend)
        {
            lock (LockProgram)
            {
                DataToSend = new byte[arrayToSend.Length];
                Array.Copy(arrayToSend, DataToSend, arrayToSend.Length);
                DataToSendAvailable = true;
            }
        }


        /// <summary>
        /// Connects to a serial port defined through the current settings
        /// </summary>
        public void StartListening()
        {
            if (portCouldBeOpened)
            {
                // Closing serial port if it is open
                if (_serialPort != null && _serialPort.IsOpen)
                    _serialPort.Close();

                if (_currentSerialSettings.PortName.Length > 5)
                    _currentSerialSettings.PortName = _currentSerialSettings.PortName.Substring(0, 5);
                // Setting serial port settings

                _serialPort = new SerialPort(
                    _currentSerialSettings.PortName,
                    _currentSerialSettings.BaudRate,
                    _currentSerialSettings.Parity,
                    _currentSerialSettings.DataBits,
                    _currentSerialSettings.StopBits);

                //_serialPort = new SerialPort("COM1", 9600, Parity.None, 8, StopBits.One);
                
                _serialPort.ReceivedBytesThreshold = 1;
                //_serialPort.DtrEnable = true;
                //_serialPort.Handshake = Handshake.RequestToSend;

                // Subscribe to event and open serial port for data
                _serialPort.DataReceived += new SerialDataReceivedEventHandler(_serialPort_DataReceived);
                _serialPort.Open();
                //_serialPort.DiscardOutBuffer();
                //_serialPort.DiscardInBuffer();
            }
            else
            {
                MessageBox.Show("Port could not be opened");
            }
        }

        /// <summary>
        /// Closes the serial port
        /// </summary>
        public void StopListening()
        {
            _serialPort.Close();
        }


        /// <summary>
        /// Retrieves the current selected device's COMMPROP structure, and extracts the dwSettableBaud property
        /// </summary>
        private void UpdateBaudRateCollection()
        {
            if (_currentSerialSettings.PortName.Length > 5)
                _currentSerialSettings.PortName = _currentSerialSettings.PortName.Substring(0, 5);

            _serialPort = new SerialPort(_currentSerialSettings.PortName);
            //_serialPort = new SerialPort("COM1");

            portCouldBeOpened = false;
            try
            {
                _serialPort.Open();
                portCouldBeOpened = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Port could not be opened!\r\n Make sure it is not used by another application");
                var mess = ex.Message;
            }
            Int32 dwSettableBaud = 9600;
            if (portCouldBeOpened)
            {
                object p = _serialPort.BaseStream.GetType().GetField("commProp", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(_serialPort.BaseStream);
                dwSettableBaud = (Int32)p.GetType().GetField("dwSettableBaud", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public).GetValue(p);

                _serialPort.Close();
            }
            
            _currentSerialSettings.UpdateBaudRateCollection(dwSettableBaud);
        }

        // Call to release serial port
        public void Dispose()
        {
            Dispose(true);
        }

        // Part of basic design pattern for implementing Dispose
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _serialPort.DataReceived -= new SerialDataReceivedEventHandler(_serialPort_DataReceived);
            }
            // Releasing serial port (and other unmanaged objects)
            if (_serialPort != null)
            {
                if (_serialPort.IsOpen)
                    _serialPort.Close();

                _serialPort.Dispose();
            }
        }

        #endregion

    }

    /// <summary>
    /// EventArgs used to send bytes recieved on serial port
    /// </summary>
    public class SerialDataEventArgs : EventArgs
    {
        public SerialDataEventArgs(byte[] dataInByteArray)
        {
            Data = dataInByteArray;
        }

        /// <summary>
        /// Byte array containing data from serial port
        /// </summary>
        public byte[] Data;
    }
}
