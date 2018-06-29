/*
* UniOSC
* Copyright © 2014-2015 Stefan Schlupek
* All rights reserved
* info@monoflow.org
*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using OSCsharp.Data;
using HedgehogTeam.EasyTouch;


namespace UniOSC{

	/// <summary>
	/// Moves a GameObject in normalized coordinates (ScreenToWorldPoint)
	/// </summary>
	[AddComponentMenu("UniOSC/OSCScrollWheelReceiver")]
	public class OSCScrollWheelReceiver :  UniOSCEventTarget {


		public Transform mouseScrollableObject1;
		public Transform mouseScrollableObject2;
		public Transform mouseScrollableObject3;

		private float controllerZRotation;
		private bool isFlipped;
		private int isRotating; 
		private Transform objectToRotate;
		private Vector3 storeRotation; 		// stores the rotation of the attached gameObject
		private int objectToRotateID;

		void Awake(){

		}


		public override void OnEnable()
		{
			base.OnEnable();




		}

		// data at index [0] int objectToRotateID 
		// data at index [1] int isRotating
		// data at index [2] float controllerZRotation 


		public override void OnOSCMessageReceived(UniOSCEventArgs args)
		{
			OscMessage msg = (OscMessage)args.Packet;

			if(msg.Data.Count <1)return;


			int isRotating = (int)msg.Data[1];

			if (isRotating == 1) {

				//Debug.Log("Scroll wheel is rotating");
				objectToRotateID = (int)msg.Data[0];
				if (objectToRotateID == 0) {
					objectToRotate = mouseScrollableObject1;
				}
				if (objectToRotateID == 1) {
					objectToRotate = mouseScrollableObject2;
				}
				if (objectToRotateID == 2) {
					objectToRotate = mouseScrollableObject3;
				}

				controllerZRotation  = (float)msg.Data[2];
				//Debug.Log("isTwisting = true;"+rotation);
				storeRotation = objectToRotate.eulerAngles;
				objectToRotate.eulerAngles = new Vector3(storeRotation.x, storeRotation.y, controllerZRotation); 
			}



		}
	}
}

