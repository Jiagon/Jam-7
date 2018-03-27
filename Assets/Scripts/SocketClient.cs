using UnityEngine;
using System;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

public class SocketClient : MonoBehaviour {

	// Use this for initialization

	public GameObject hero;
	private float xPos = 10.0f;
	private float yPos = 10.0f;

	Thread receiveThread1;
	Thread receiveThread2;
	UdpClient client;
	public int port1;
	public int port2;

	//info

	public string lastReceivedUDPPacket1 = "";
	public string lastReceivedUDPPacket2 = "";
	public string allReceivedUDPPackets = "";

	void Start () {
		init();
	}

	void OnGUI(){
		Rect  rectObj=new Rect (40,10,200,400);
		Rect rectObj2 = new Rect(40, 50, 200, 400);

		GUIStyle  style  = new GUIStyle ();
		
		style .alignment  = TextAnchor.UpperLeft;
		
		GUI .Box (rectObj,"# UDPReceive\n127.0.0.1 "+ port1 + " #\n"
		          
		          //+ "shell> nc -u 127.0.0.1 : "+port +" \n"
		          
		          + "\nLast Packet: \n"+ lastReceivedUDPPacket1
		          
		          //+ "\n\nAll Messages: \n"+allReceivedUDPPackets
		          
		          ,style );

	}

	private void init(){
		print ("UPDSend.init()");

		port1 = 5065;
		port2 = 5060;

		print ("Sending to 127.0.0.1 : " + port1);

		receiveThread1 = new Thread (new ThreadStart(ReceiveData1));
		receiveThread1.IsBackground = true;
		receiveThread1.Start ();

	}

	private void ReceiveData1(){
		client = new UdpClient (port1);
		while (true) {
			try{
				print("sad");
				IPEndPoint anyIP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port1);
				byte[] data = client.Receive(ref anyIP);

				string text = Encoding.UTF8.GetString(data);
				string[] pos = text.Split('-');
				print ("x >> " + pos[0]);
				print("y >> " + pos[1]);
				lastReceivedUDPPacket1 =text;
				allReceivedUDPPackets=allReceivedUDPPackets+text;
				xPos = float.Parse(pos[0]);
				xPos *= 0.021818f;
				yPos = float.Parse(pos[1]);
				yPos *= 0.021818f;
			}
			catch (Exception e){
				print (e.ToString());
			}
		}
	}

	// Update is called once per frame
	void Update () {
		hero.transform.position = new Vector3(xPos-6.0f,yPos-6.0f, 0);
	}

	void OnApplicationQuit(){
		if (receiveThread1 != null) {
			receiveThread1.Abort();
			Debug.Log(receiveThread1.IsAlive); //must be false
		}
	}
}
