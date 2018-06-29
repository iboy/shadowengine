using UnityEngine;
using System.Collections;
using HedgehogTeam.EasyTouch;

public class ChangeControllerColorOnTouch : MonoBehaviour {
	//public ToggleControllerSetVisibility getTouchedControllerAlpha;
	private float touchedControllerAlpha;
	//private Color colorOnVisitbiltyScript;
	//public Color normalColor;
	public Color activeColor;
	private Color originalColor;
	private SpriteRenderer spriteRenderer;
	// Use this for initialization

	void OnEnable() {
		//touchedControllerAlpha = this.GetComponent<ToggleControllerSetVisibility>().globalControllerAlpha;
		//spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
		//activeColor = new Color(1/115,1/115,1/206,1/74);
		//Debug.Log("Hello from the ChangeControllerColorOnTouch script- why am I not working from an enable?");
	}


	public void ChangeControllerColorOver (GameObject go) {
		//Debug.Log("controller: "+go.name);
		spriteRenderer = go.GetComponent<SpriteRenderer>();
		//colorOnVisitbiltyScript = this.GetComponent<ToggleControllerSetVisibility>().controllerSet1Color;
		touchedControllerAlpha = GetComponent<ToggleControllerSetVisibility>().globalControllerAlpha;
		//Debug.Log("touchedControllerAlpha: "+touchedControllerAlpha);
		//Debug.Log("globalControllerAlpha = "+touchedControllerAlpha);
		originalColor = spriteRenderer.color;

		spriteRenderer.color = new Color (activeColor.r, activeColor.g, activeColor.b, touchedControllerAlpha); 
		//spriteRenderer.color = new Color (activeColor.r, activeColor.g, activeColor.b, 1f); 

		//Debug.Log("Touched Controller");

	}

	public void ChangeControllerColorOff (GameObject go) {

		spriteRenderer = go.GetComponent<SpriteRenderer>();
		//if (spriteRenderer.color.a != 0) {
			spriteRenderer.color = originalColor; 
			//Debug.Log("Released Controller");
		//}

	}

}
