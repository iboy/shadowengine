using UnityEngine;
using System.Collections;
using HedgehogTeam.EasyTouch;

public class ScaleMe2D : MonoBehaviour {

	public GameObject target;
	public void ScaleWithDelta(Gesture gesture) {

		if (gesture.pickedObject) {

			if (gesture.pickedObject.name == "Controller 1" || gesture.pickedObject.name == "Scaler") { // select intended target - requires naming consistency

				if (target.transform.localScale.x > .4f) {
					target.transform.localScale += new Vector3( (gesture.deltaPinch/2)* Time.deltaTime,  (gesture.deltaPinch/2) * Time.deltaTime,  0);
				//target.transform.localScale += new Vector3( gesture.deltaPinch* .4f * Time.deltaTime,  gesture.deltaPinch* .4f * Time.deltaTime,  1);
				//Debug.Log("You're scaling Controller 1");
				} else {


					// target.transform.localScale = new Vector3(.5f,.5f,0f);

				}

			} else {
				
				// pinching in space
				//Debug.Log("Picked Object:"+gesture.pickedObject.name+" on layer "+gesture.pickedObject.layer);
		
			}

		}
	}

}
