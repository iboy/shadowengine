using UnityEngine;
using System.Collections;
using MaterialUI;


public class DisplayNameAndType_ToastOnly : MonoBehaviour {

	public string myName;
	public string controllerType;
	public float displayTime;
	public int fontSize;

	public GameObject _GUIController;
	// Use this for initialization
	void Start () {
		
	}
	void Awake () {
		
		//UIControllerScript gui = _GUIController.GetComponent<UIControllerScript>();
		//gui.displayPuppetNameAndControlType(myName, controllerType, displayTime, fontSize);

	}

	void OnEnable() {
		Toaster gui = _GUIController.GetComponent<Toaster>();
		gui.displayPuppetNameAndControlType(myName, controllerType, displayTime, fontSize);

	}
	// Update is called once per frame
	void Update () {
	
	}
}
