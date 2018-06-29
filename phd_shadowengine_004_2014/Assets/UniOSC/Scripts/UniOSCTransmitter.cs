/*
* UniOSC
* Copyright © 2014 Stefan Schlupek
* All rights reserved
* info@monoflow.org
*/
using UnityEngine;
using System.Collections;

using System;
using System.Collections.Generic;

using System.Net;
using System.Net.Sockets;

using OSCsharp.Data;
using OSCsharp.Net;

using OSCsharp.Utils;

namespace UniOSC{

	//based on: https://github.com/valyard/TUIOsharp/blob/master/TUIOsharp/TuioServer.cs
	//https://github.com/valyard/OSCsharp

	public class UniOSCTransmitter  {

		#region Private vars

		private UDPTransmitter udpTransmitter ;
		
		#endregion
		
		
		#region Public properties
		
		public IPAddress IPAddress { get; private set; }
		public int Port { get; private set; }
		
		#endregion

		#region Events
		
		//public event EventHandler<OSCEventArgs> OSCMessageSend;
		public event EventHandler<ExceptionEventArgs> OSCErrorOccured;
		
		
		#endregion

		#region Constructors
		
		public UniOSCTransmitter() : this("127.0.0.1",3333)
		{

		}

		public UniOSCTransmitter(string ipAddress, int port ):this(IPAddress.Parse(ipAddress), port){

		}

		public UniOSCTransmitter(IPAddress ipAddress, int port)
		{
			IPAddress = ipAddress;
			Port = port;
		}


		#endregion


		public void Connect()
		{
			if(udpTransmitter != null) Close ();
			udpTransmitter = new UDPTransmitter(IPAddress,Port);
			udpTransmitter.Connect();

		}


		public void Close(){
			if(udpTransmitter != null){
			udpTransmitter.Close();
			udpTransmitter = null;
			}
		}


		public bool SendOSCMessage(object sender,UniOSCEventArgs args){

			if(udpTransmitter != null){
				try{
					udpTransmitter.Send(args.Message);
					return true;
				}catch(Exception e){
					Debug.LogWarning(e.ToString());
					return false;
				}
			}
			return false;
		}

	}
}