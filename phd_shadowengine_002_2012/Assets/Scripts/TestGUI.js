/* Example level loader */

//var icon : Texture2D;
//var hSliderValue : float = 1.0;
var target : Transform;
var target1 : Transform;
var target2 : Transform;
var target3 : Transform;
var target4 : Transform;
var myCamera : Camera;
var myCamera2 : Camera;
var thisGUISkin : GUISkin;


function OnGUI () {
	// Make a background box
	GUI.skin = thisGUISkin;
	GUI.Box (Rect (40,10,100,190), "Scene Selector");

	// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
	if (GUI.Button (Rect (50,40,80,20), "Scene 1")) {
		Application.LoadLevel (0);
	}

	// Make the second button.
	if (GUI.Button (Rect (50,70,80,20), "Scene 2")) {
		Application.LoadLevel (1);
	}
	
		// Make the third button.
	if (GUI.Button (Rect (50,100,80,20), "Scene 3")) {
		Application.LoadLevel (2);
	}
	
		// Make the next button.
	if (GUI.Button (Rect (50,130,80,20), "Scene 4")) {
		Application.LoadLevel (3);
	}
	
			// Make the next button.
	if (GUI.Button (Rect (50,160,80,20), "Clear")) {
		Application.LoadLevel (4);
	}
/* Horizontal Slider example */




	//hSliderValue = GUI.HorizontalSlider (Rect (50, 140, 90, 30), hSliderValue, 0.0, 20.0);
	//print(hSliderValue);
	//myCamera.transform.position.x = hSliderValue;
	//myCamera2.transform.position.x = hSliderValue;
	
	
}


/* Button Content examples */
