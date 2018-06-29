using UnityEngine;
using System.Collections;
using HedgehogTeam.EasyTouch;
public class CameraController : MonoBehaviour {

	public Camera myCamera;

	public float orthoZoomSpeed;
	public float perspectiveZoomSpeed;

	public void CameraZoom(Gesture gesture) {

//		float currentOrthoZoom;
		//float currentPerspectiveZoom;

		//if (myCamera.

		//	myCamera.fieldOfView;

//		if (gesture.pickedObject.layer == 9 ) { // there is a background layer (9) called Camera.

		//	float value = gesture.deltaPinch * -.4f * Time.deltaTime;

		//	myCamera.orthographicSize += value;



//		}

	}

	public void ResetZoom(Gesture gesture) {

		if (gesture.pickedObject.layer == 9 ) { 
			
			if (myCamera.orthographic) {

			float currentOrthoZoom =  Camera.main.orthographicSize;
			float initialOrthoZoom = 5.0f;
			if (currentOrthoZoom != initialOrthoZoom) {
					
					Debug.Log("Double Tap detected. Resetting Orthographic Camera size");

					iTween.ValueTo(gameObject, 
						iTween.Hash(
							"From", currentOrthoZoom, 
							"To", initialOrthoZoom, 
							"Speed", orthoZoomSpeed, 
							"onupdate", "TweenOrthoSize",
							"easetype", "spring"
						
						));				
				
				} else {				
					Debug.Log("Double Tap detected. Orthographic Camera size = Original size");			
				}

			} 
		}

	}

	public void TweenOrthoSize(float i) {

		Camera.main.orthographicSize = i;

	}


}