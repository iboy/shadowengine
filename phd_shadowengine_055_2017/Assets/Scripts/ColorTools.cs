using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using MaterialUI;

public class ColorTools : MonoBehaviour {

	public bool isMonochrome;
	public GameObject objectToToggle;
	private Color black;
	public Color originalTintColor;
	private SpriteRenderer objectToToggleSpriteRenderer;
	[HideInInspector]
	public List<SpriteRenderer> objectsToToggleSpriteRenderer;
	[HideInInspector]
	public List<Color> originalColors;


	// Use this for initialization
	void Start () {

		if (GUIDataManager.guiData.monoModeIsOn == true) {

			isMonochrome = true;

		} else {

			isMonochrome = false; 

		}

		objectsToToggleSpriteRenderer = new List<SpriteRenderer>();
		originalColors = new List<Color>();
		TraverseForRendererList(this.gameObject);
		black = new Color(0f,0f,0f,1f); //black

		setIsMonoChrome(isMonochrome);

	}

	public void setIsMonoChrome(bool state) {

		isMonochrome = state;
		GUIDataManager.guiData.monoModeIsOn = state;

		//if (state==false) {

			//GUIDataManager.guiData.colorModeIsOn = true;

		//}
	}

	// Update is called once per frame
	void Update () {
		if (isMonochrome == true) {

			foreach (SpriteRenderer sr in objectsToToggleSpriteRenderer) {

				sr.color = black;

			}


		} else {

			foreach (Color col in originalColors) {
				for (int count = 0; count < originalColors.Count; count++) {
					
					float r = col.r;
					float g = col.g;
					float b = col.b;
					float a = col.a;

					objectsToToggleSpriteRenderer[count].color = new Color(r,g,b,a);

				}

			}



		}
	}

	public void TraverseForRendererList(GameObject go)
	{
		
			if (go.tag == "PuppetPart" || go.tag == "PuppetBaseObject") {
			objectsToToggleSpriteRenderer.Add(go.GetComponent<SpriteRenderer>());
			originalColors.Add(go.GetComponent<SpriteRenderer>().color);
			}


		foreach (Transform child in go.transform)
		{
			TraverseForRendererList(child.gameObject);
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
				if (isMonochrome == true) {
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
	}


}
