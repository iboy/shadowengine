using UnityEngine;
using System.Collections;
using Rewired;
using Prime31;

public class ScrollWheelRotate : MonoBehaviour {
	
	// public varibles
	public GameObject objectToRotate1;   	// object to rotate around
	public GameObject objectToRotate2;   	// alternative object to rotate around
	public GameObject objectToRotate3;   	// alternative object to rotate around
	private GameObject objectToRotate;   
	public Vector3 axisOfRotation;			// e.g. set this to 0 0 1 for Z
	public float speed = 100.0f;      		//multiplier for the mouse wheel input
	
	public bool scrollWheelRotatable  = true; // this gets over-ridden / toggled by the Dropdowns (if possible)
	private float rotation;        			//stores the rotation of the mouse wheel
	private Vector3 storeRotation; 			//stores the rotation of the attached gameObject
	
	private Ray2D ray;
	private RaycastHit2D hit;
	//private int objectToRotateID;

	//private Player player; // The Rewired Player
	//private CharacterController2D cc;
	//public int playerId = 0; // The Rewired player id of this character

	void Start () {
		
		// check if any object is selected otherwise target 'self'
		if (objectToRotate1 == null && objectToRotate2 == null && objectToRotate3 == null) {

			// if no object is set default object to rotate is this ...
			objectToRotate = this.gameObject;
			//objectToRotateID = 4;
			//player = ReInput.players.GetPlayer(playerId);	
		}
	}
	
	void Update () {


		if (scrollWheelRotatable == true) { // you can disable the scrolling behaviour - might be needed if there are other scroll views etc.




			//storeRotation = objectToRotate.transform.eulerAngles;  // keeps storeRotation up to date 
			rotation = Input.GetAxis("Mouse ScrollWheel") * speed * Time.deltaTime; 
			//rotation = player.Input.GetAxis("Rotate Controller Object") * speed * Time.deltaTime; 

			// Check if the mouse is over some collider 

			// the hit collider test is to lock the rotation around a desired object

			if (rotation != 0 ) { // the wheel has rotated

				// fire a ray to see what collider, if any, is under the mouse
				Vector2 ray = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				hit = Physics2D.Raycast(ray, -Vector2.zero);

				if (hit.collider !=null) {

					if (hit.collider.gameObject == objectToRotate1 || hit.collider.gameObject == objectToRotate2 || hit.collider.gameObject == objectToRotate3) { // test if the object is the desired one to rotate

						//Debug.Log("You are scrolling over obj"+hit.collider.name);

						// this rotates the object the mouse is over
						// comment this line out if you only wish one object to work the rotation

						objectToRotate = hit.collider.gameObject;
						storeRotation = objectToRotate.transform.eulerAngles;  // keeps storeRotation up to date 
						storeRotation= new Vector3(storeRotation.x+(rotation*axisOfRotation.x), storeRotation.y+(rotation*axisOfRotation.y), storeRotation.z+(rotation*axisOfRotation.z));
				
					}
				
				}

				if (objectToRotate != null) { // null check then do the rotation
					objectToRotate.transform.eulerAngles = storeRotation;

					// send the object ID and



				}

		
			}


		
	
		}

	}


	
	public void scrollWheelRotatableToggle(bool isRotatable) {
		
		if (isRotatable == false) {
			
			scrollWheelRotatable = false; 
		} else {
			
			scrollWheelRotatable = true;
		}
		
	}
	
}