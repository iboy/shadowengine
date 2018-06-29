/*
* UniOSC
* Copyright © 2014-2015 Stefan Schlupek
* All rights reserved
* info@monoflow.org
*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System;
using OSCsharp.Data;
using HedgehogTeam.EasyTouch;


namespace UniOSC{

	/// <summary>
	/// This class is a blueprint for your own implementations of the abstract class UniOSCEventDispatcher
	/// Dispatcher forces a OSCConnection to send a OSC Message.
	/// //Don't forget the base callings !!!!
	/// </summary>

	/// The data sent is the movement of a single controller in the following index order
	/// data at index [0] int isDragging 
	/// data at index [1] float x
	/// data at index [2] float y 
	/// data at index [3] int isPinching 
	/// data at index [4] float z scale
	/// data at index [5] int isTwisting 
	/// data at index [6] float z rotation (euler)
	/// data at index [7] int IsDoubleTapped			

	[ExecuteInEditMode]
	public class OSCScrollWheelRotate: UniOSCEventDispatcher {


		//public string OSCAddress;
		//public int OSCPort;
		//public UniOSCConnection OSCConnection;
		//
		//[Space(10)]
		//
		//public string OSCAddressOUT;
		//public string OSCIPAddressOUT = "192.168.178.32";
		//public int OSCPortOUT;
		//public UniOSCConnection OSCConnectionOUT;
		//
		//[Space(10)]

		//private  UniOSCEventTargetCBImplementation oscTarget1;

		// public varibles
		public GameObject objectToRotate1;   	// object to rotate around
		public GameObject objectToRotate2;   	// alternative object to rotate around
		public GameObject objectToRotate3;   	// alternative object to rotate around   
		public Vector3 axisOfRotation;			// e.g. set this to 0 0 1 for Z
		public float speed = 100.0f;      		//multiplier for the mouse wheel input

		public bool scrollWheelRotatable  = true; // this gets over-ridden / toggled by the Dropdowns (if possible)

		private GameObject objectToRotate;
		private float rotation;        			//stores the rotation of the mouse wheel
		private Vector3 storeRotation; 			//stores the rotation of the attached gameObject

		private Ray2D ray;
		private RaycastHit2D hit;
		private int objectToRotateID;
		private string objectName;

		private float controllerZRotation;
		private bool isFlipped;
		private int isRotating; 
		private float _currentControllerXPosition;
		private float _currentControllerYPosition;
		private float _currentControllerScale;
		private float _currentControllerZRotation;

		//public GameObject controllerToTrack;
		//public GameObject puppetRoot;


		public override void Awake ()
		{
			base.Awake ();

		}
		public override void OnEnable ()
		{
			//Don't forget this!!!!
			base.OnEnable ();

			if (objectToRotate1 == null && objectToRotate2 == null && objectToRotate3 == null) {

				// if no object is set default object to rotate is this ...
				objectToRotate = this.gameObject;
				objectToRotateID = 3;
				//player = ReInput.players.GetPlayer(playerId);	
			}

			//here your custom code

			//If you append data  data later you should always call this first otherwise we get more and more data appended if you toggle the enabled state of your component.
			ClearData();


			//We append our data that we want to send with a message
			//The best place to do this step is on Enable().This approach is more flexible through the internal way UniOSC works.
			//later in the your "MySendOSCMessageTriggerMethod" you change this data with :
			//Message mode: ((OscMessage)_OSCeArg.Packet).UpdateDataAt(index,yourValue); 
			//Bundle mode Mode: ((OscBundle)_OSCeArg.Packet).Messages[i]).UpdateDataAt(index,yourValue);
			//We only can append data types that are supported by the OSC specification:
			//(Int32,Int64,Single,Double,String,Byte[],OscTimeTag,Char,Color,Boolean)

			//Message mode

			controllerZRotation = 0.0f;	// twist
			isRotating	 		= 0; 
			//isFlipped 			= false;
			//objectName 			= objectToRotate.name;

			AppendData(objectToRotateID);				// data at index [0] int  objectToRotateID
			//AppendData(objectName);						// data at index [1] string objectName
			AppendData(isRotating);						// data at index [2] int isRotating 
			AppendData(controllerZRotation);			// data at index [3] float rotation z
			//AppendData(Convert.ToInt32(isFlipped));		// data at index [4] int IsFlipped	
		}

		public override void OnDisable ()
		{
			
			base.OnDisable (); // OSC stuff

		}


		public void SendOSCMessageTriggerMethod(){

			if(_OSCeArg.Packet is OscMessage)
			{
				//message
				OscMessage msg = ((OscMessage)_OSCeArg.Packet);
				_updateOscMessageData(msg);

			}

			_SendOSCMessage(_OSCeArg);

		}

		private void _updateOscMessageData(OscMessage msg)
		{
			//Debug.Log("objectToRotateID: "+objectToRotateID);
			//Debug.Log("isRotating: "+isRotating);
			//Debug.Log("controllerZRotation: "+controllerZRotation);
			msg.UpdateDataAt(0, objectToRotateID);
			//msg.UpdateDataAt(1, objectName);
			msg.UpdateDataAt(1, isRotating);
			msg.UpdateDataAt(2, controllerZRotation);
			//msg.UpdateDataAt(4, Convert.ToInt32(isFlipped));

		}


		void  Update () {


			if (scrollWheelRotatable == true) { // you can disable the scrolling behaviour - might be needed if there are other scroll views etc.
				
				rotation = Input.GetAxis("Mouse ScrollWheel") * speed * Time.deltaTime; 

				if (rotation != 0 ) { // the wheel has rotated

					// fire a ray to see what collider, if any, is under the mouse
					Vector2 ray = Camera.main.ScreenToWorldPoint(Input.mousePosition);
					hit = Physics2D.Raycast(ray, -Vector2.zero);

					if (hit.collider !=null) {

						if (hit.collider.gameObject == objectToRotate1 || hit.collider.gameObject == objectToRotate2 || hit.collider.gameObject == objectToRotate3) { // test if the object is the desired one to rotate

							// these are hard coded and mouse wheel scrollable objects are limited to 3 per puppet! 
							// TODO Increase number of mousescrollable objects per puppet
							// 
							if (hit.collider.gameObject == objectToRotate1) {
								objectToRotateID = 0; // zero indexed
								//objectName = objectToRotate1.name;

							}

							if (hit.collider.gameObject == objectToRotate2) {
								objectToRotateID = 1;
								//objectName = objectToRotate2.name;
							}
							if (hit.collider.gameObject == objectToRotate3) {
								objectToRotateID = 2;
								//objectName = objectToRotate3.name;
							}
							//Debug.Log("You are scrolling over obj"+hit.collider.name);

							// this rotates the object the mouse is over
							// comment this line out if you only wish one object to work the rotation

							objectToRotate = hit.collider.gameObject;
							storeRotation = objectToRotate.transform.eulerAngles;  // keeps storeRotation up to date 
							storeRotation= new Vector3(storeRotation.x+(rotation*axisOfRotation.x), storeRotation.y+(rotation*axisOfRotation.y), storeRotation.z+(rotation*axisOfRotation.z));
				
							isRotating = 1;
							controllerZRotation = storeRotation.z;
							//
						}

					}

					if (objectToRotate != null) { // null check then do the rotation
						objectToRotate.transform.eulerAngles = storeRotation;

						SendOSCMessageTriggerMethod();

						// send the object ID and



					}


				}




			}

		}
	

		public void scrollWheelRotatableToggle(bool isRotatable) {

			if (isRotatable == false) {

				scrollWheelRotatable = false; 
			} else {

				scrollWheelRotatable = true;
			}

		}

	} // end of class
} // end of namespace