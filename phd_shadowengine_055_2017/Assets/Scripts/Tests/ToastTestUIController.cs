using UnityEngine;
using System.Collections;
using MaterialUI;

public class ToastTestUIController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// TOAST MESSAGE -------------------------------------------------------------------

	public void displayPuppetNameAndControlType(string myName, string controllerType, float displayTime, int fontSize) {

		ToastManager.Show(myName+" "+controllerType, displayTime,  new Color (0f,0f,0f,1f),  new Color (255f,255f,255f,1f), fontSize);

	}

}
