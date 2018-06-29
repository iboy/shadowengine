using UnityEngine;
using System.Collections;
using MaterialUI;
using HedgehogTeam.EasyTouch;

public class GUIDataBinding : MonoBehaviour {
	public MaterialSlider UISliderC1xPos;
	public MaterialSlider UISliderC1yPos;
	public MaterialSlider UISliderC1Twist;
	public MaterialSlider UISliderC1Pinch;
	public MaterialCheckbox UICheckboxDoubleTap;

	public GameObject C1;

	private bool isDragging; 
	private bool isTwisting;
	private bool isPinching;
	private bool isDoubleTapped;

	private IEnumerator coroutine;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		// not sure if this is needed in update / fixedupdate
		// it can happen from the event calls dragging etc...
		if (isDragging == true) {

			UISliderC1xPos.slider.value = 	C1.transform.position.x;
			UISliderC1yPos.slider.value = 	C1.transform.position.y;
		}

		if (isTwisting == true) {
			UISliderC1Twist.slider.value = 	C1.transform.eulerAngles.z;
		}

		if (isPinching == true) {
			UISliderC1Pinch.slider.value = 	C1.transform.localScale.x;
		}

		if (isDoubleTapped == true) {
			UICheckboxDoubleTap.toggle.isOn = true;
		} else { 
			UICheckboxDoubleTap.toggle.isOn = false;
		}
			
	}
	public void TheDragStarted(Gesture gesture) {

		//Debug.Log("We've started the drag");
		isDragging = true;

	}

	public void TheDragEnded(Gesture gesture) {

		//Debug.Log("We've stopped the drag");

		isDragging = false;
	}

	public void Twisting(Gesture gesture) {
		Debug.Log("We're twisting");

		if (gesture !=null) { 
			isTwisting = true; 
		}  else { 
			isTwisting = false; 
		} 
	}

	public void Pinching(Gesture gesture) {
		Debug.Log("We're pinching");
		if (gesture !=null) { 
			isPinching = true; 
		}  else { 
			isPinching = false; 
		}
	}


	public void DoubleTapping(Gesture gesture) {
		//gesture.touchType
		if (gesture !=null) {
			isDoubleTapped = true;
			// wait a bit and set to false
			StartCoroutine(WaitAfterDoubleClickToResetSignal(0.2f));
		} 
	}


	private IEnumerator WaitAfterDoubleClickToResetSignal(float waitTime) {
		yield return new WaitForSeconds(waitTime);
		isDoubleTapped = false; 

	}
}
