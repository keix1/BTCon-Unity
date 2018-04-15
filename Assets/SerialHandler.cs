using UnityEngine;
using System.Collections;
using System.IO.Ports;
using System.Threading;

public class SerialHandler : MonoBehaviour
{
	public delegate void SerialDataReceivedEventHandler(string message);
	public event SerialDataReceivedEventHandler OnDataReceived;
	
	public string portName = "/dev/tty.Bluetooth-Incoming-Port";
	// public string portName = "/dev/tty.MALS";
	public int baudRate    = 9600;
	
	private SerialPort serialPort_;
	private Thread thread_;
	private bool isRunning_ = false;
	
	private string message_="";
	private string message_buf1="";
	private string message_buf2="";
	private bool isNewMessageReceived_ = false;

	private bool firstFlag = true;
	private bool secondFlag = true;
	
	void Awake()
	{
		Open();
	}
	
	void Update()
	{
		if (isNewMessageReceived_) {
			isNewMessageReceived_ = false;
			OnDataReceived(message_); 
		}
	}
	
	void OnDestroy()
	{
		Close();
	}
	
	private void Open()
	{
		// serialPort_ = new SerialPort(portName, baudRate, Parity.None, 1024, StopBits.One);
		serialPort_ = new SerialPort (portName, 9600);
		serialPort_.Open();
		
		isRunning_ = true;
		
		thread_ = new Thread(Read);
		thread_.Start();
	}
	
	private void Close()
	{
		isRunning_ = false;
		
		if (thread_ != null && thread_.IsAlive) {
			thread_.Join();
		}
		
		if (serialPort_ != null && serialPort_.IsOpen) {
			serialPort_.Close();
			serialPort_.Dispose();
		}
	}
	
	private void Read()
	{
		while (isRunning_ && serialPort_ != null && serialPort_.IsOpen) {
			try {
				if (serialPort_.BytesToRead > 0) {
					message_buf1 = serialPort_.ReadLine();
					string someString = message_buf1.Replace("\r", "").Replace ("\n","");
					 

					if(someString == "q") {
						message_ = message_buf2;
						Debug.Log ("message_");
						Debug.Log (message_);
						message_buf2 = "";
						isNewMessageReceived_ = true;
					}
					else if(firstFlag) {
						firstFlag = false;
					}
					else  {
						Debug.Log ("someString");
						Debug.Log (someString); 
						 message_buf2 = message_buf2  + someString;
					}

					Debug.Log ("message_");


//					message_buf1 = serialPort_.ReadLine(); 
//					string one = message_buf1.Replace("\r", "").Replace("\n", "").Replace(" ","");
//					if( one == "q") { 
//						message_ = message_buf2;
//						message_buf2 = "";
//						isNewMessageReceived_ = true;
//					} else {
//						message_buf2 = message_buf2 + message_buf1;
//						Debug.Log (message_buf2);
//					}

				}
			} catch (System.Exception e) {
				Debug.LogWarning(e.Message);
			}
		}
	}
	
	public void Write(string message)
	{
		try {
			serialPort_.Write(message);
		} catch (System.Exception e) {
			Debug.LogWarning(e.Message);
		}
	}
}