#pragma strict
//////////////////////////////////////////////////////////////
// inputControl.js
// iphone touch input management by jzaun / unity forums
//////////////////////////////////////////////////////////////

// touch tracking states
enum TouchState {
	Reset,
	Waiting,
	Tracking,
	Analyize,
};

// Multi touch initialization
static var _multiTouchInit : boolean = false;

// Touch Tracking variables
private var _fltTouchDelta : float = 0.10;
private var _state : TouchState = TouchState.Reset;
private var _bolFingerDown = new boolean[5];					// Was this finger used
private var _vecFingerDownPosition = new Vector2[5];			// Position when the finder went down
private var _vecFingerCurrentPosition = new Vector2[5];			// the current position the finger was seen
private var _vecFingerLastPosition = new Vector2[5];			// the last position the finger was seen
private var _fltFingerLastTouchTime = new float[5];				// The last time the finger was seen
private var _intFingerTracking = new Array[5];					// History of the fingers movement
private var _fltLastTouchTime : float;							// Last time the screen was touched
private var _bolZoomRot : boolean;								// True if we are zooming or rotating

private var _intLongPressInterval : int = 30;					// duration in frames to detect a long press
private var _fltDoubleTapInterval : float = 0.5;				// max interval in seconds to detect a double tap
private var _fltDoubleTapTime : float;							// current time to test double tap
private var _bolDoubleTapOccuring : boolean = false;			// currently testing for double tap ?

//
// Initialize the object
//
function Start ()
{
	// Turnon multi touch
	if (_multiTouchInit == false) {
		Input.multiTouchEnabled = true;
		_multiTouchInit = true;
	}
		
	for (var index : int = 0; index < 5; index++) {
		_intFingerTracking[index] = new Array();
	}
}

//
// Update each frame
//
function Update ()
{
		var touchCount : int = Input.touchCount;
		var touchesJS : Array = Input.touches;
		var touches : Touch[] = touchesJS.ToBuiltin(Touch);
		var touch : Touch;
		
		var index : int;
		var pos : Vector2;
		var fingerAngle : float;
		var fingerDir : int;
		
		// Deal with touching
		switch(_state)
		{
	        case TouchState.Reset:
    	        this.ResetTouchState();
        	    break;
        	    
        	case TouchState.Waiting: //// Waiting for the user to start touching tha screen
				// If we have touches 
        		for (index = 0; index < touchCount; index++)
        		{
        			this.OnTouch();
        			// Grat the touch informaiton
        			touch = touches[index];
        			
        			// this is the not the last touch, start keeping track
					if (touch.phase != TouchPhase.Canceled &&
					    touch.phase != TouchPhase.Ended)
					{
						if (!_bolFingerDown[touch.fingerId])
						{
							// If we got a new finger
							_bolFingerDown[touch.fingerId] = true;
							_vecFingerDownPosition[touch.fingerId] = touch.position;
							_vecFingerCurrentPosition[touch.fingerId] = touch.position;
							_vecFingerLastPosition[touch.fingerId] = touch.position;
							_fltFingerLastTouchTime[touch.fingerId] = Time.time;
							_fltLastTouchTime = Time.time;
						}
					}
					
					// If we get a end here, it was really quick, cature it and
					// go straight to analyizing it
					else if (touch.phase == TouchPhase.Ended)
					{

						_vecFingerLastPosition[touch.fingerId] = _vecFingerCurrentPosition[touch.fingerId];
						_vecFingerCurrentPosition[touch.fingerId] = touch.position;
						_fltFingerLastTouchTime[touch.fingerId] = Time.time;
						
						pos = touch.position;
						if (pos != _vecFingerLastPosition[touch.fingerId])
						{
							// Figure out the angle the finger moved
							fingerAngle = GetAngle(touch.position, _vecFingerLastPosition[touch.fingerId]);					
									
							// We only want to deal with 8 directions (0-8, 0 = East)
							fingerDir = GetDirection(fingerAngle);

							_intFingerTracking[touch.fingerId].Add(fingerDir);
						}
						else
						{
							// Stationary
							_intFingerTracking[touch.fingerId].Add(0);
						}
							
						// Analize the finger(s)
						_state = TouchState.Analyize;
						break;        		
					}

					// This isnt a tap or swipe, start tracking for
					// other motions
					if (Time.time - _fltLastTouchTime > _fltTouchDelta)
					{
						_state = TouchState.Tracking;
						break;        		
					}
        		} // - FOR touchCount
				break;        		
        		
        	case TouchState.Tracking:	//// We got all the fingers we are going to, trak them
        		for (index = 0; index < touchCount; index++)
        		{
        			this.OnTouch();

        			// Grab the touch info
        			touch = touches[index];
        			
        			// See if this was all canceled
					if (touch.phase == TouchPhase.Canceled)
					{
						_state = TouchState.Reset;
						break;
					}
					
					// Update finger information
					if (touch.phase != TouchPhase.Canceled)
					{
						if (_bolFingerDown[touch.fingerId])
						{
							pos = touch.position;
							if (pos != _vecFingerLastPosition[touch.fingerId])
							{
								// Figure out the angle the finger moved
								fingerAngle = GetAngle(touch.position, _vecFingerLastPosition[touch.fingerId]);					
									
								// We only want to deal with 8 directions (1-8, 8 = East)
								fingerDir = GetDirection(fingerAngle);
								
								// Record tracking information, might use it
								// in the future for gestures
								//_intFingerTracking[touch.fingerId].Add(fingerDir);
								//_vecFingerLastPosition[touch.fingerId] = _vecFingerCurrentPosition[touch.fingerId];
								//_vecFingerCurrentPosition[touch.fingerId] = pos;
							}
							else
							{
								// Stationary
								_intFingerTracking[touch.fingerId].Add(0);
							}
								
							// Record tracking information, might use it
							// in the future for gestures
							_intFingerTracking[touch.fingerId].Add(fingerDir);
							_vecFingerLastPosition[touch.fingerId] = _vecFingerCurrentPosition[touch.fingerId];
							_vecFingerCurrentPosition[touch.fingerId] = pos;
							
							// test for long press
							if (_intFingerTracking[touch.fingerId].length > 30) {
								if (Vector2.Distance(_vecFingerDownPosition[index], _vecFingerLastPosition[index]) < 5) {
									// long press
									OnLongPress(1, _vecFingerLastPosition[index]);
								}
							}

							_fltFingerLastTouchTime[touch.fingerId] = Time.time;
						}
					}
        		}
        		
        		// See if we have a zoom or rotate going on
        		// and drag
        		if (_bolFingerDown[0]) {
        			if (_bolFingerDown[1]) {
						// 2 finger stuff
						var vecOriginal : Vector2 = _vecFingerLastPosition[1] - _vecFingerLastPosition[0];
						var vecCurrent : Vector2 = _vecFingerCurrentPosition[1] - _vecFingerCurrentPosition[0];
						var vecOrigDir : Vector2 = vecOriginal / vecOriginal.magnitude;
						var vecCurrDir : Vector2 = vecCurrent / vecCurrent.magnitude;
						var fltDeltaDist : float = vecOriginal.magnitude - vecCurrent.magnitude;
						var fltRotCos : float = Vector2.Dot(vecOrigDir, vecCurrDir);
						var vecDelta : Vector2 = _vecFingerCurrentPosition[0] - _vecFingerLastPosition[0];
	
						Debug.Log("a" + fltRotCos.ToString());
						if (fltRotCos < 0.9998) { // if it is 1, then we have no rotation
							var rotationRad : float = Mathf.Acos(fltRotCos);
							Debug.Log("b" + rotationRad.ToString());
							if (rotationRad > .0009 * Mathf.Deg2Rad) {
								// Enough rotation was applied with the two-finger movement,
								// so let's switch to rotate the camera
								var vecOriginal3 : Vector3 = new Vector3(vecOriginal.x, vecOriginal.y, 0.0);
								var vecCurrent3 : Vector3 = new Vector3( vecCurrent.x, vecCurrent.y, 0.0);				
								var fltRotDir : float = Vector3.Cross( vecOriginal3, vecCurrent3 ).normalized.z;
								if (fltRotDir == -1) {
									OnRotate(true);
								} else {
									OnRotate(false);
								}
								_bolZoomRot = true;
							}
						} else if (Mathf.Abs(fltDeltaDist) > 5.0) {
							// The distance between fingers has changed enough
							// to count this as a pinch
							if (fltDeltaDist > 0.0) {
								OnZoom(false);
							} else {
								OnZoom(true);
							}
							_bolZoomRot = true;
						} else if (vecDelta.magnitude > 0) {
							// 2 finger drag
							OnDrag(2, (_vecFingerCurrentPosition[0] + _vecFingerCurrentPosition[1]) / 2, vecDelta);
						}
        			} else if (vecDelta.magnitude > 0) {
        				// 1 finger drag
        				OnDrag(1, _vecFingerCurrentPosition[0], vecDelta);
        			}
        		}
        		
        		// If any fingers were lifted, rest things
        		for (index = 0; index < 5; index++)
        		{
        			if (_bolFingerDown[index])
        			{
        				if (Time.time - _fltFingerLastTouchTime[index] > _fltTouchDelta)
        				{
        					if (_bolZoomRot) {
	        					_state = TouchState.Reset;
        					} else {
	        					_state = TouchState.Analyize;
        					}
        				}
        			}
        		}
        		break;

        	case TouchState.Analyize: //// we had a quick touch, look for tap/swipe
        		// Counter how many fingers were used
        		var intFingersUsed : int = 0;
        		for (index = 0; index < 5; index++)
        		{
        			if (_bolFingerDown[index])
        			{
		        		this.CleanFinger(index);
        				intFingersUsed++;
        			}
				}
        		
        		// Get the average numbers for overall movement
        		var intAvgHistPoints : int = -1;
        		var intAvgMagnitude : int = 0;
        		var intAvgDirection : int = 0;
        		var vecAvgStartPos : Vector2 = new Vector2(-1, 0);
        		var vecAvgEndPos : Vector2 = new Vector2(-1, 0);
        		for (index = 0; index < 5; index++)
        		{
        			if (_bolFingerDown[index])
        			{
        				// Calculate avg hit points per finger
        				if (intAvgHistPoints > -1)
	        				intAvgHistPoints = (intAvgHistPoints + _intFingerTracking[index].Count) / 2;
	        			else
	        				intAvgHistPoints = _intFingerTracking[index].Count;
	        			
	        			// Caclulate average magnitude
	        			if (intAvgMagnitude > -1)
	        				intAvgMagnitude = (intAvgMagnitude + Vector2.Distance(_vecFingerDownPosition[index], _vecFingerLastPosition[index])) / 2;
	        			else
	        				intAvgMagnitude = Vector2.Distance(_vecFingerDownPosition[index], _vecFingerLastPosition[index]);
 
 						// Start Pos
 						if (vecAvgStartPos.x > -1)
 						{
 							vecAvgStartPos.x = (vecAvgStartPos.x + _vecFingerDownPosition[index].x) / 2;
 							vecAvgStartPos.y = (vecAvgStartPos.y + _vecFingerDownPosition[index].y) / 2;
 						}
 						else
 						{
 							vecAvgStartPos.x = _vecFingerDownPosition[index].x;
 							vecAvgStartPos.y = _vecFingerDownPosition[index].y;
 						}

 						// End Pos
 						if (vecAvgEndPos.x > -1)
 						{
 							vecAvgEndPos.x = (vecAvgEndPos.x + _vecFingerLastPosition[index].x) / 2;
 							vecAvgEndPos.y = (vecAvgEndPos.y + _vecFingerLastPosition[index].y) / 2;
 						}
 						else
 						{
 							vecAvgEndPos.x = _vecFingerLastPosition[index].x;
 							vecAvgEndPos.y = _vecFingerLastPosition[index].y;
 						}

						// Figure out the average direction moved
						fingerAngle = GetAngle(vecAvgEndPos, vecAvgStartPos);					
						intAvgDirection = GetDirection(fingerAngle);
					}
        		}
								
				// Check if we have a been tapped
				if (intAvgHistPoints <= 1 && intAvgMagnitude <= 15)
				{
					// Call the tap callback
					this.OnTap(intFingersUsed, vecAvgStartPos);
					
					// check for double tap
					if (_bolDoubleTapOccuring) {
						// testing for double tap
						if ((Time.time - _fltDoubleTapTime) < _fltDoubleTapInterval) {
							// double tap
							OnDoubleTap(intFingersUsed, vecAvgStartPos);
						}
						_bolDoubleTapOccuring = false;
					} else {
						// begin detection
						_bolDoubleTapOccuring = true;
						_fltDoubleTapTime = Time.time;
					}
				}

				// Check if we have a been flicked
				else if (intAvgHistPoints <= 10 && intAvgMagnitude > 15)
				{
					// Call the tap callback
					this.OnFlick(intFingersUsed, vecAvgStartPos, intAvgDirection, intAvgMagnitude);
				}
				
				// Nothing we care about, the user didnt do anything we recognised
				else
				{
					// Get the signature of the finger's movement
        			for (index = 0; index < 5; index++)
        			{
        				if (_bolFingerDown[index])
    	    			{
			        		this.SignatureFinger(index);
    	    			}
        			}
        			
        			//check for finger gestures here
				}
								
        		_state = TouchState.Reset;
				break;

       	 	default:
            	break;
		}
}

//
// Return the angle between two positions
//
function GetAngle(P1 : Vector2, P2 : Vector2) : float
{
	var fltAngle : float;
	
	// Vector Math!!
	var tEvtPosn : Vector3 = new Vector3(P1.x, P1.y, 0.0);
	var tPrvPosn : Vector3 = new Vector3(P2.x, P2.y, 0.0);
	var tVectorA : Vector3 = tPrvPosn - tEvtPosn;
	var tVectorB : Vector3 = new Vector3(-1.0, 0.0, 0.0);
							
	// Figure out the angle the finger moved
	fltAngle = Vector3.Angle(tVectorA, tVectorB);							
	if (P1.y <= P2.y) {
		fltAngle = 360 - fltAngle;
	}
	
	return fltAngle;
}

//
// Return the direction of an angle
//
function GetDirection(fltAngle : float) : int
{
	var intAngle : int = -1;
	
	// We only want to deal with 8 directions
	if (fltAngle > 22.5 && fltAngle <= 67.5) {
		intAngle = 1;	// North East
	} else if (fltAngle > 67.5 && fltAngle <= 112.5) {
		intAngle = 2;	// North
	} else if (fltAngle > 112.5 && fltAngle <= 157.5) {
		intAngle = 3;	// North West
	} else if (fltAngle > 157.5 && fltAngle <= 202.5) {
		intAngle = 4;	// West
	} else if (fltAngle > 202.5 && fltAngle <= 247.5) {
		intAngle = 5;	// South West
	} else if (fltAngle > 247.5 && fltAngle <= 292.5) {
		intAngle = 6;	// South
	} else if (fltAngle > 292.5 && fltAngle <= 337.5) {
		intAngle = 7;	// South East
	} else if (fltAngle > 337.5 || fltAngle <= 22.5) {
		intAngle = 8;	// East
	}
	
	return intAngle;
}

//
// Return to origin state and reset fingers that we are watching
//
function ResetTouchState()
{
	_state = TouchState.Waiting;
	_bolFingerDown[0] = false;
	_bolFingerDown[1] = false;
	_bolFingerDown[2] = false;
	_bolFingerDown[3] = false;
	_bolFingerDown[4] = false;
	_intFingerTracking[0].Clear();
	_intFingerTracking[1].Clear();
	_intFingerTracking[2].Clear();
	_intFingerTracking[3].Clear();
	_intFingerTracking[4].Clear();
	
	OnRelease();
}

//
// Clean up the fingers history
//
function CleanFinger(id : int)
{
	// remove outlyers from the history
	for (var index : int = 1; index < _intFingerTracking[id].Count - 1; index++) {
		if (_intFingerTracking[id][index] != _intFingerTracking[id][index - 1] && _intFingerTracking[id][index] != _intFingerTracking[id][index + 1]) {
			_intFingerTracking[id].RemoveAt(index);
			index--;
		}
	}

	// Remove the first and last touch
	if (_intFingerTracking[id].Count > 0) {
		_intFingerTracking[id].RemoveAt(0);
	}
	if (_intFingerTracking[id].Count > 0) {
		_intFingerTracking[id].RemoveAt(_intFingerTracking[id].Count-1);
	}
}

//
// Remove doubles...
//  5555 = 5
//  55544455 = 545
//
function SignatureFinger(id : int)
{
	for (var index : int = 1; index < _intFingerTracking[id].Count; index++)
	{
		if (_intFingerTracking[id][index - 1] == _intFingerTracking[id][index])
		{
			_intFingerTracking[id].RemoveAt(index - 1);
			index--;
		}
	}
}

//
// Touch speakers (they call the methods on the listeners)
//
private var msg : String;
function OnTouch()
{
	//msg = "OnTouch";
}

function OnDrag(intFingers : int, vecPosition : Vector2, vecDelta : Vector2)
{	
	//msg = "OnDrag / " + intFingers + " fingers, pos = " + vecPosition;
}

function OnTap(intFingers : int, vecPosition : Vector2)
{	
	//msg = "OnTap / " + intFingers + " fingers, pos = " + vecPosition;
}

function OnDoubleTap(intFingers : int, vecPosition : Vector2)
{	
	//msg = "OnDoubleTap / " + intFingers + " fingers, pos = " + vecPosition;
}

function OnLongPress(intFingers : int, vecPosition : Vector2)
{	
	//msg = "OnLongPress / " + intFingers + " fingers, pos = " + vecPosition;
}

function OnFlick(intFingers : int, vecPosition : Vector2, intDirection : int, intMagnatude : int)
{
	//msg = "OnFlick / " + intFingers + " fingers, pos = " + vecPosition + ",dir = " + intDirection + ", mag = " + intMagnatude;
}

function OnZoom(bolZoomIn : boolean)
{
	//msg = "OnZoom / zoomIn : " + bolZoomIn;
}

function OnRotate(bolRight : boolean)
{
	//msg = "OnRotate / right : " + bolRight;
}

function OnRelease()
{
	//msg = "OnRelease";
}
/*
function OnGUI()
{
	GUILayout.Label("" + msg);
}
*/
