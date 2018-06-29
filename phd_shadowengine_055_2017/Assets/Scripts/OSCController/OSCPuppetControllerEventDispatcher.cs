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
	public class OSCPuppetControllerEventDispatcher: UniOSCEventDispatcher {


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

		public float controllerXPosition;
		public float controllerYPosition;
		public float puppetScale;
		public float controllerZRotation;
		public int isDoubleTapped;
		public bool isFlipped;

		public float doubleTapCancelSignalTiming = 0.2f;

		private int isDragging; 
		private int isTwisting;
		private int isPinching;
		private float _currentControllerXPosition;
		private float _currentControllerYPosition;
		private float _currentControllerScale;
		private float _currentControllerZRotation;

		public GameObject controllerToTrack;
		public GameObject puppetRoot;

		private int doubleTapCount;


		//public OSCPuppetControllerEventDispatcher(string __oscOutAddress, string __oscOutIPAddress, int __oscPort): base( __oscOutAddress, __oscOutIPAddress, __oscPort)
		//{
		//}
		//public OSCPuppetControllerEventDispatcher(string _oscOutAddress, UniOSCConnection _explicitConnection): base(_oscOutAddress, _explicitConnection)
		//{
		//}

		public override void Awake ()
		{
			base.Awake ();
			//here your custom code
			//oscTarget1 = new UniOSCEventTargetCBImplementation(OSCPort);
			//oscTarget1.OSCMessageReceived+=OnOSCMessageReceived1;
			//

		}
		public override void OnEnable ()
		{
			//Don't forget this!!!!
			base.OnEnable ();

			if (controllerToTrack == null) {

				controllerToTrack = this.gameObject;

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

			controllerXPosition = controllerToTrack.transform.position.x;  		// drag
			controllerYPosition	= controllerToTrack.transform.position.y; 		// drag
			puppetScale 	= controllerToTrack.transform.localScale.x; 	// pinch
			controllerZRotation = controllerToTrack.transform.rotation.z;	// twist
			isDragging	 	= 0; 
			isDoubleTapped 	= 0;
			isTwisting 		= 0;
			isPinching 		= 0;
			isFlipped 		= false;


			AppendData(isDragging);				// data at index [0] int isDragging 
			AppendData(controllerXPosition);	// data at index [1] float x
			AppendData(controllerYPosition);	// data at index [2] float y 
			AppendData(isPinching); 			// data at index [3] int isPinching 
			AppendData(puppetScale);		// data at index [4] float z scale
			AppendData(isTwisting); 			// data at index [5] int isTwisting 
			AppendData(controllerZRotation);	// data at index [6] float z rotation (euler)
			AppendData(isDoubleTapped);			// data at index [7] int IsDoubleTapped	
			AppendData(Convert.ToInt32(isFlipped));				// data at index [8] int IsFlipped	
			////.......


            ////This is the way to handle bundle mode
			//SetBundleMode(true);
			//OscMessage controllerPositionMsg = new OscMessage("/ControllerPosition");
			//controllerPositionMsg.Append(controllerXPosition);
			//controllerPositionMsg.Append(controllerYPosition);
			//AppendData(controllerPositionMsg);//Append message to bundle
			//
			//
			//OscMessage controllerScaleMsg = new OscMessage("/ControllerScale");
			//controllerScaleMsg.Append(controllerScale);
			//AppendData(controllerScaleMsg);//Append message to bundle
			//
			//OscMessage controllerRotationMsg = new OscMessage("/ControllerRotation");
			//controllerRotationMsg.Append(controllerZRotation);
			//AppendData(controllerRotationMsg);//Append message to bundle
			//
			//OscMessage controllerDoubleTappedMsg = new OscMessage("/ControllerDoubleTapped");
			//controllerDoubleTappedMsg.Append(controllerZRotation);
			//AppendData(controllerDoubleTappedMsg);//Append message to bundle

		}
		public override void OnDisable ()
		{
			//Don't forget this!!!!
			base.OnDisable ();
			//here your custom code

		}


		/// <summary>
		/// Just a dummy method that shows how you trigger the OSC sending and how you could change the data of the OSC Message 
		/// </summary>
		/// 
		/// 
		/// 
		public void SendOSCMessageTriggerMethod(){
			//Here we update the data with a new value
			//OscMessage msg = null;
			if(_OSCeArg.Packet is OscMessage)
			{
				//message
				OscMessage msg = ((OscMessage)_OSCeArg.Packet);
				_updateOscMessageData(msg);

			}
			//else if(_OSCeArg.Packet is OscBundle)
			//{
			//	//bundle 
			//	foreach (OscMessage msg2 in ((OscBundle)_OSCeArg.Packet).Messages)
			//	{
			//		_updateOscMessageData(msg2);
			//	}	
			//}

			//Here we trigger the sending
			_SendOSCMessage(_OSCeArg);


		}

		/// <summary>
		/// Just a dummy method that shows how you update the data of the OSC Message 
		/// </summary>
		private void _updateOscMessageData(OscMessage msg)
		{


			msg.UpdateDataAt(0, isDragging);
			msg.UpdateDataAt(1, controllerXPosition);
			msg.UpdateDataAt(2, controllerYPosition);
			msg.UpdateDataAt(3, isPinching);
			msg.UpdateDataAt(4, puppetScale);
			msg.UpdateDataAt(5, isTwisting);
			msg.UpdateDataAt(6, controllerZRotation);
			msg.UpdateDataAt(7, isDoubleTapped);
			msg.UpdateDataAt(8, Convert.ToInt32(isFlipped));

		}




		public void OSCSendTheDragStarted(Gesture gesture) {

			Debug.Log("We've started the drag");
			isDragging = 1;
			SendOSCMessageTriggerMethod();
		}

		public void OSCSendDragging(Gesture gesture) {
			Debug.Log("In drag, sending OSC");
			controllerXPosition = controllerToTrack.transform.position.x;  		// drag
			controllerYPosition	= controllerToTrack.transform.position.y; 		// drag
			SendOSCMessageTriggerMethod();

		}
		public void OSCSendTheDragEnded(Gesture gesture) {

			Debug.Log("We've stopped the drag");

			isDragging = 0;
			SendOSCMessageTriggerMethod();
		}

		public void OSCSendTwisting(Gesture gesture) { // this is working
			//Debug.Log("We're twisting");

			if (gesture !=null) { 
				isTwisting = 1; 

				controllerZRotation = controllerToTrack.transform.eulerAngles.z;
				SendOSCMessageTriggerMethod();
			} 
			//else { 
			//	isTwisting = 0; 
			//	SendOSCMessageTriggerMethod();
			//} 
		}

		public void OSCSendPinching(Gesture gesture) {
			//Debug.Log("We're pinching");
			if (gesture !=null) { 
				isPinching = 1; 

				puppetScale = puppetRoot.transform.localScale.x; // we always do uniform scaling so this should be fine
				SendOSCMessageTriggerMethod();
			}  
			//else { 
			//	isPinching = 0; 
			//	SendOSCMessageTriggerMethod();
			//}
		}

		public void OSCSendPinchEnded() {
			//Debug.Log("We're not pinching");
			isPinching = 0; 
			isTwisting = 0; 
			SendOSCMessageTriggerMethod();


		}

		public void TwistEnded() {
			//Debug.Log("We're not twisting");
			isTwisting = 0; 
			isPinching = 0; // this is a hack to stop pinching and twisting as PinchEnded is not called. This is because
							// the twist and pinch gesture alternate and are similar. The EasyTouch settings allow a min twist angle
							// and a min pinch length to be set to discern between gestures. I've set the twist angle to 5 which
							// helps but may not be desirable
			SendOSCMessageTriggerMethod();


		}

		public void OSCSendUpdateIsFlipped(int value){
			if (value % 2 == 0) {

				isFlipped = false;

			} else {

				isFlipped = true;
			}

		}

		public void OSCSendDoubleTapping(Gesture gesture) {
			//gesture.touchType
			if (gesture !=null) {
				isDoubleTapped = 1;
				//Debug.Log("Double Tapped!");
				doubleTapCount = doubleTapCount +1;
				OSCSendUpdateIsFlipped(doubleTapCount);
				// wait a bit and set to false
				SendOSCMessageTriggerMethod();
				StartCoroutine(WaitAfterDoubleClickToResetSignal(doubleTapCancelSignalTiming));
			} 
		}


		private IEnumerator WaitAfterDoubleClickToResetSignal(float waitTime) {
			yield return new WaitForSeconds(waitTime);
			isDoubleTapped = 0; 
			SendOSCMessageTriggerMethod();

		}


		//void OnOSCMessageReceived1(object sender, UniOSCEventArgs args)
		//{
		//	Debug.Log("UniOSCCodeBasedDemo.OnOSCMessageReceived1:"+ _GetAddressFromOscPacket(args));
		//	//if(Light1 != null) Light1.enabled = !  Light1.enabled ;
		//}
		//
		//private string _GetAddressFromOscPacket(UniOSCEventArgs args){
		//	return (args.Packet is OscMessage) ? ((OscMessage)args.Packet).Address : ((OscBundle)args.Packet).Address ;
		//}

	} // end of class
} // end of namespace