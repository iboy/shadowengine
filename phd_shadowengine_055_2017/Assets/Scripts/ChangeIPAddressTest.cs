using UnityEngine;
using System.Collections;
using OSCsharp.Data;
using UniOSC;
public class ChangeIPAddressTest : MonoBehaviour {


	// Use this for initialization
	public string newIP = "192.68.0.11";
	public int newPort = 9000;
	private bool IPAddressOSCOutHasChanged = false;
	private bool PortNumberOSCOutHasChanged = false;
	private UniOSCConnection myConnection;
	void Start () {

		myConnection = GetComponent<UniOSCConnection>();
		//Debug.Log(myConnection.oscOutIPAddress);

	}
	
	// Update is called once per frame
	void Update () {
		if (IPAddressOSCOutHasChanged == true) {

			myConnection.oscOutIPAddress = newIP;
			Debug.Log(myConnection.oscOutIPAddress);
			IPAddressOSCOutHasChanged = false;
		}

		if (PortNumberOSCOutHasChanged == true) {

			myConnection.oscOutPort = newPort;
			Debug.Log(myConnection.oscOutPort);
			PortNumberOSCOutHasChanged = false;
		}

	}




	
	public void SetIPAddress(string newIPFromGUI) {

		// TODO: could validate if it is a valid IP here or in the UI
		newIP = newIPFromGUI;
		IPAddressOSCOutHasChanged = true;

	}


	public void SetOSCPortNumber(string newPortFromGUI) {

		int portValueAsInt;
		// attempt to parse the value using the TryParse functionality of the integer type
		int.TryParse(newPortFromGUI, out portValueAsInt);
		// TODO: could validate here
		newPort = portValueAsInt;
		PortNumberOSCOutHasChanged = true;

	}

}
	
	
	
