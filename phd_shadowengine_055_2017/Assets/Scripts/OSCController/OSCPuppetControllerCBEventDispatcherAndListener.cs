using UnityEngine;
using System.Collections;
using UniOSC;
using OSCsharp.Data;
using HedgehogTeam.EasyTouch;

/// <summary>
/// Demo to show how to use the class based scripts.
/// </summary>
public class OSCPuppetControllerCBEventDispatcherAndListener : MonoBehaviour {

	#region public

	public string OSCAddress;
	public int OSCPort;
	public UniOSCConnection OSCConnection;

	[Space(10)]

	public string OSCAddressOUT;
	public string OSCIPAddressOUT = "192.168.178.32";
	public int OSCPortOUT;
	//public UniOSCConnection OSCConnectionOUT;

	[Space(10)]

	//public Light Light1;
	//public Light Light2;
	//public Light Light3;

	[Space(10)]

	public bool sendData;



	[Space(10)]

	public float controllerXPosition;
	public float controllerYPosition;
	public float controllerScale;
	public float controllerZRotation;
	public int 	 isDoubleTapped;

	public float doubleTapCancelSignalTiming = 0.2f;

	private int isDragging; 
	private int isTwisting;
	private int isPinching;
	private float _currentControllerXPosition;
	private float _currentControllerYPosition;
	private float _currentControllerScale;
	private float _currentControllerZRotation;

	public GameObject controllerToTrack;

	#endregion

	#region private
	private  UniOSCEventTargetCBImplementation oscTarget1;
	private  UniOSCEventTargetCBImplementation oscTarget2;
	private  UniOSCEventTargetCBImplementation oscTarget3;
	private  UniOSCEventTargetCBImplementation oscTarget4;
	private  UniOSCEventTargetCBImplementation oscTarget5;

	private UniOSCEventDispatcherCBImplementation oscDispatcher1;
	//private UniOSCEventDispatcherCBImplementation oscDispatcher2;
	#endregion

	#region Timer
	public float sendInterval=1000;
	private System.Timers.Timer _sendIntervalTimer;
	//private bool _isOSCDirty;
	private bool timerToggle;
	private object _mylock = new object();

	/// <summary>
	/// This is a demo timer to show how you can trigger the OSC sending frequently
	/// The main problem is that you have to call you SendOSC method on the main thread so with this technique 
	/// you only set a flag in the timer and in the Update() method you read this flag to decide if you should really send
	/// </summary>
	/// <param name="source">Source.</param>
	/// <param name="e">E.</param>
	private  void _OnTimedEvent(object source, System.Timers.ElapsedEventArgs e)
	{
		//Debug.Log("Timer.Tick");
		//lock(_mylock){
		//	_isOSCDirty = true;
		//}	


	}

	private void StartSendIntervalTimer()
	{
		if(_sendIntervalTimer == null){
			_sendIntervalTimer = new System.Timers.Timer();
		}
		_sendIntervalTimer.Interval = sendInterval;
		_sendIntervalTimer.Elapsed-= _OnTimedEvent;
		_sendIntervalTimer.Elapsed+= _OnTimedEvent;
		_sendIntervalTimer.Enabled = true;
	}

	private void StopSendIntervalTimer()
	{
		if(_sendIntervalTimer == null)return;
		_sendIntervalTimer.Stop();
		_sendIntervalTimer.Elapsed-= _OnTimedEvent;
	}
	#endregion

	void Awake () {

		//Here we show the different possibilities to create a OSCEventTarget from code:

		//When we only specify a port we listen to all OSCMessages on that port (We assume that there is a OSCConnection with that listening port in our scene)
		oscTarget1 = new UniOSCEventTargetCBImplementation(OSCPort);
		oscTarget1.OSCMessageReceived+=OnOSCMessageReceived1;
		//oscTarget1.oscPort = OSCPort;

		//This implies that we use the explicitConnection mode. (With responding to all OSCmessages)
		oscTarget2 = new UniOSCEventTargetCBImplementation(OSCConnection);
		oscTarget2.OSCMessageReceived+=OnOSCMessageReceived2;

		//We listen to a special OSCAddress regardless of the port.
		oscTarget3 = new UniOSCEventTargetCBImplementation(OSCAddress);
		oscTarget3.OSCMessageReceived+=OnOSCMessageReceived3;

		//The standard : respond to a given OSCAddress on a given port
		oscTarget4 = new UniOSCEventTargetCBImplementation(OSCAddress, OSCPort);
		oscTarget4.OSCMessageReceived+=OnOSCMessageReceived4;

		//This version has the advantage that we are not bound to a special port. If the connection changes the port we still respond to the OSCMessage
		//oscTarget5 = new UniOSCEventTargetCBImplementation(OSCAddress, OSCConnection);
		//oscTarget5.OSCMessageReceived+=OnOSCMessageReceived5;


		oscDispatcher1 = new UniOSCEventDispatcherCBImplementation(OSCAddressOUT,OSCIPAddressOUT,OSCPortOUT);

		//oscDispatcher1.AppendData("TEST1");
		oscDispatcher1.AppendData(isDragging);				// data at index [0] int isDragging 
		oscDispatcher1.AppendData(controllerXPosition);	// data at index [1] float x
		oscDispatcher1.AppendData(controllerYPosition);	// data at index [2] float y 
		oscDispatcher1.AppendData(isPinching); 			// data at index [3] int isPinching 
		oscDispatcher1.AppendData(controllerScale);		// data at index [4] float z scale
		oscDispatcher1.AppendData(isTwisting); 			// data at index [5] int isTwisting 
		oscDispatcher1.AppendData(controllerZRotation);	// data at index [6] float z rotation (euler)
		oscDispatcher1.AppendData(isDoubleTapped);			// data at index [7] int IsDoubleTapped		

		//oscDispatcher2 = new UniOSCEventDispatcherCBImplementation(OSCAddressOUT,OSCConnectionOUT);


		//OSCConnection.transmissionTypeIn = OSCsharp.Net.TransmissionType.Multicast;
		//OSCConnection.oscInIPAddress = "224.0.0.1";//Set a valid Multicast address.
	}




	void OnEnable()
	{
		//Debug.Log("UniOSCCodeBasedDemo.OnEnable");

		//Just to create a OSCEventTarget isn't enough. We nedd to enable it:

		oscTarget1.Enable();

		oscTarget2.Enable();

		oscTarget3.Enable();

		oscTarget4.Enable();

		//oscTarget5.Enable();



		if (controllerToTrack == null) {

			controllerToTrack = this.gameObject;

		}

		//here your custom code

		//If you append data  data later you should always call this first otherwise we get more and more data appended if you toggle the enabled state of your component.
		//ClearData();


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
		controllerScale 	= controllerToTrack.transform.localScale.x; 	// pinch
		controllerZRotation = controllerToTrack.transform.eulerAngles.z;	// twist
		isDragging	 	= 0; 
		isDoubleTapped 	= 0;
		isTwisting 		= 0;
		isPinching 		= 0;


		oscDispatcher1.AppendData(isDragging);				// data at index [0] int isDragging 
		oscDispatcher1.AppendData(controllerXPosition);	// data at index [1] float x
		oscDispatcher1.AppendData(controllerYPosition);	// data at index [2] float y 
		oscDispatcher1.AppendData(isPinching); 			// data at index [3] int isPinching 
		oscDispatcher1.AppendData(controllerScale);		// data at index [4] float z scale
		oscDispatcher1.AppendData(isTwisting); 			// data at index [5] int isTwisting 
		oscDispatcher1.AppendData(controllerZRotation);	// data at index [6] float z rotation (euler)
		oscDispatcher1.AppendData(isDoubleTapped);			// data at index [7] int IsDoubleTapped		


		//oscDispatcher1.Enable();

		//oscDispatcher2.Enable();
		////just a test to show that you can clear and add data (is overwritten with 0 and 1 at Update())
		//oscDispatcher2.ClearData();
		//oscDispatcher2.AppendData("TEST2");
		//oscDispatcher2.AppendData("TEST2.1");

		// We want sent continously data so start our timer to set a flag at a given interval
		// The interval is in milliseconds.
		StartSendIntervalTimer();
	}

	void OnDisable()
	{
		//Here we only disable our OSCEventTargets so we can temporary disconnect from the OSCMessage stream. To re-connect we only have to call Enable()
		oscTarget1.Disable();

		oscTarget2.Disable();

		oscTarget3.Disable();

		oscTarget4.Disable();

		//oscTarget5.Disable();

		oscDispatcher1.Disable();

		StopSendIntervalTimer();



	}

	void OnDestroy()
	{
		//Clean up things and release recources!!!!
		//Otherwise our callbacks can still respond even if our GameObject with this script is destroyed/removed from the scene

		oscTarget1.Dispose();
		oscTarget1 = null;

		oscTarget2.Dispose();
		oscTarget2 = null;

		oscTarget3.Dispose();
		oscTarget3 = null;

		oscTarget4.Dispose();
		oscTarget4 = null;

		//oscTarget5.Dispose();
		//oscTarget5 = null;

		oscDispatcher1.Dispose();
	}






	void Update () {

		//only send OSC messages at our specified interval. The _isOSCDirty flag is set at  _OnTimedEvent()
		//lock(_mylock){
		//	if(!_isOSCDirty)return;
		//	_isOSCDirty = false;
		//}


			//Here we change the data of the OSCMessage.
		


			oscDispatcher1.UpdateDataAt(0, isDragging);
			oscDispatcher1.UpdateDataAt(1, controllerXPosition);
			oscDispatcher1.UpdateDataAt(2, controllerYPosition);
			oscDispatcher1.UpdateDataAt(3, isPinching);
			oscDispatcher1.UpdateDataAt(4, controllerScale);
			oscDispatcher1.UpdateDataAt(5, isTwisting);
			oscDispatcher1.UpdateDataAt(6, controllerZRotation);
			oscDispatcher1.UpdateDataAt(7, isDoubleTapped);



			oscDispatcher1.SendOSCMessage();

			//timerToggle = ! timerToggle;


	}


	public void TheDragStarted(Gesture gesture) {

		//Debug.Log("We've started the drag");
		isDragging = 1;
		//SendOSCMessageTriggerMethod();
	}

	public void Dragging(Gesture gesture) {
		Debug.Log("In drag, sending OSC");
		controllerXPosition = controllerToTrack.transform.position.x;  		// drag
		controllerYPosition	= controllerToTrack.transform.position.y; 		// drag
		//SendOSCMessageTriggerMethod();

	}
	public void TheDragEnded(Gesture gesture) {

		//Debug.Log("We've stopped the drag");

		isDragging = 0;
		//SendOSCMessageTriggerMethod();
	}

	public void Twisting(Gesture gesture) {
		Debug.Log("We're twisting");

		if (gesture !=null) { 
			isTwisting = 1; 

			controllerZRotation = controllerToTrack.transform.localRotation.z;
			//SendOSCMessageTriggerMethod();
		} 
		//else { 
		//	isTwisting = 0; 
		//	SendOSCMessageTriggerMethod();
		//} 
	}

	public void Pinching(Gesture gesture) {
		Debug.Log("We're pinching");
		if (gesture !=null) { 
			isPinching = 1; 
			controllerScale = controllerToTrack.transform.localScale.x;
			//SendOSCMessageTriggerMethod();
		}  
		//else { 
		//	isPinching = 0; 
		//	SendOSCMessageTriggerMethod();
		//}
	}

	public void PinchEnded() {
		Debug.Log("We're not pinching");
		isPinching = 0; 
		//SendOSCMessageTriggerMethod();


	}

	public void TwistEnded() {
		Debug.Log("We're not twisting");
		isTwisting = 0; 
		isPinching = 0; // this is a hack to stop pinching and twisting as PinchEnded is not called. This is because
		// the twist and pinch gesture alternate and are similar. The EasyTouch settings allow a min twist angle
		// and a min pinch length to be set to discern between gestures. I've set the twist angle to 5 which
		// helps but may not be desirable
		//SendOSCMessageTriggerMethod();


	}

	public void DoubleTapping(Gesture gesture) {
		//gesture.touchType
		if (gesture !=null) {
			isDoubleTapped = 1;
			Debug.Log("Double Tapped!");
			// wait a bit and set to false
			//SendOSCMessageTriggerMethod();
			StartCoroutine(WaitAfterDoubleClickToResetSignal(doubleTapCancelSignalTiming));
		} 
	}


	private IEnumerator WaitAfterDoubleClickToResetSignal(float waitTime) {
		yield return new WaitForSeconds(waitTime);
		isDoubleTapped = 0; 
		//SendOSCMessageTriggerMethod();

	}









	private void _updateOscMessageData(OscMessage msg)
	{
		msg.UpdateDataAt(0, isDragging);
		msg.UpdateDataAt(1, controllerXPosition);
		msg.UpdateDataAt(2, controllerYPosition);
		msg.UpdateDataAt(3, isPinching);
		msg.UpdateDataAt(4, controllerScale);
		msg.UpdateDataAt(5, isTwisting);
		msg.UpdateDataAt(6, controllerZRotation);
		msg.UpdateDataAt(7, isDoubleTapped);

	}




	#region callbacks

	void OnOSCMessageReceived1(object sender, UniOSCEventArgs args)
	{
		Debug.Log("UniOSCCodeBasedDemo.OnOSCMessageReceived1:"+ _GetAddressFromOscPacket(args));
		//if(Light1 != null) Light1.enabled = !  Light1.enabled ;
	}

	void OnOSCMessageReceived2(object sender, UniOSCEventArgs args)
	{
		Debug.Log("UniOSCCodeBasedDemo.OnOSCMessageReceived2:"+ _GetAddressFromOscPacket(args));
		//if(Light2 != null) Light2.enabled = !  Light2.enabled ;
	}

	void OnOSCMessageReceived3(object sender, UniOSCEventArgs args)
	{
		Debug.Log("UniOSCCodeBasedDemo.OnOSCMessageReceived3:"+ _GetAddressFromOscPacket(args));
		//if(Light3 != null) Light3.enabled = !  Light3.enabled ;
	}

	void OnOSCMessageReceived4(object sender, UniOSCEventArgs args){
		Debug.Log("UniOSCCodeBasedDemo.OnOSCMessageReceived4:"+ _GetAddressFromOscPacket(args));
	}

	void OnOSCMessageReceived5(object sender, UniOSCEventArgs args)
	{
		Debug.Log("UniOSCCodeBasedDemo.OnOSCMessageReceived5:"+ _GetAddressFromOscPacket(args));
	}

	private string _GetAddressFromOscPacket(UniOSCEventArgs args){
		return (args.Packet is OscMessage) ? ((OscMessage)args.Packet).Address : ((OscBundle)args.Packet).Address ;
	}

	#endregion

}
