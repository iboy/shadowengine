/*
* UniOSC
* Copyright © 2014 Stefan Schlupek
* All rights reserved
* info@monoflow.org
*/
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;
using MaterialUI;

	

public class ToggleMonoOnSpriteRenderer :  MonoBehaviour {

	public bool toggleState;
	public GameObject objectToToggle;
	private Color black;
	private Color originalTintColor;
	private SpriteRenderer objectToToggleSpriteRenderer;
	private int counter;


	void OnEnable(){

		black = new Color(0f,0f,0f,1f); //black
		counter = 1;
		Traverse(this.gameObject);

		}



	public void ToggleMonoFromUI (bool myBool) {
		
		if (myBool == true) {
			
			toggleState = true;
			counter = 0;
			Traverse(objectToToggle);

		} else {
			counter = 0;
			toggleState = false;
			Traverse(objectToToggle);

			}

	}

	void Traverse(GameObject go)
	{

		if (go.tag == "PuppetPart" || go.tag == "PuppetBaseObject") {

			//Debug.Log(go.name);
			objectToToggleSpriteRenderer = go.GetComponent<SpriteRenderer>();
			//if (counter == 1) {
				//try and cache the original colour of all the sprites
				originalTintColor = objectToToggleSpriteRenderer.color;
			//}
			if (objectToToggleSpriteRenderer !=null) {
				Debug.Log("I have a spriterenderer");
				if (toggleState == true) {
					// CHANGE TO BLACK
					//Debug.Log("Changing to Black");	
					objectToToggleSpriteRenderer.color = black;

				} else { 			
					// RESTORE TO TINT
					//Debug.Log("Restoring original color");	
					objectToToggleSpriteRenderer.color = originalTintColor;

				} // end 	
			}

		}

		foreach (Transform child in go.transform)
		{
			Traverse(child.gameObject);
		}


		Debug.Log("Counter: "+counter);
		//counter++;
	}
		
	
}