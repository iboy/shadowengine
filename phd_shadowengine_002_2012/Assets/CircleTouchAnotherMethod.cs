using UnityEngine;
using System.Collections;

 
public class CircleTouchAnotherMethod : MonoBehaviour {


	public GameObject TouchPointSprite_1;
	public GameObject TouchPointSprite_2;
	public GameObject TouchPointSprite_3;
	public GameObject TouchPointSprite_4;
	public GameObject TouchPointSprite_5;
	public GameObject TouchPointSprite_6;
	public GameObject TouchPointSprite_7;
	public GameObject TouchPointSprite_8;
	public GameObject TouchPointSprite_9;
	public GameObject TouchPointSprite_10;
	public GameObject TouchPointSprite_11;

	private Vector2 fTC;
	private Vector2 touchPosition1;
	private Vector2 touchPosition2;
	private Vector2 touchPosition3;
	private Vector2 touchPosition4;
	private Vector2 touchPosition5;
	private Vector2 touchPosition6;
	private Vector2 touchPosition7;
	private Vector2 touchPosition8;
	private Vector2 touchPosition9;
	private Vector2 touchPosition10;
	private Vector2 touchPosition11;
	private Vector3 mousePosition;

	public float touchOverlayZ 	=  	6f;
	public float trackSpeed 	= 	0.1f;
	//private bool mouseTouch = 		false;

//
//	private   Vector2 leftFingerPos = Vector2.zero;
//	private   Vector2 leftFingerLastPos = Vector2.zero;
//	private   Vector2 leftFingerMovedBy = Vector2.zero;
	
	public float slideMagnitudeX = 0.0f;
	public float slideMagnitudeY = 0.0f;

	

	public float speed = 10.0f;
		
		void Update() {
			Move();
		}
		


		
	void Move() {
			
		for (int i = 0; i < Input.touches.Length; i++) {
		
			Touch touch = Input.GetTouch (i);
				

			Vector3 touchPos; 
			touchPos.x=touch.position.x; touchPos.y=touch.position.y; 
			touchPos.z=touchOverlayZ;


//			Vector3 touchPos3D = Camera.main.ScreenToWorldPoint(touchPos);

				

			if (Input.GetTouch(0).phase != TouchPhase.Ended) {
					//rigidbody2D.AddForce ((Vector2)forzeDir3D);
				//Touch touch_one = Input.GetTouch (0);

				Vector3 touchPos1; 
				touchPos1.x=touch.position.x; touchPos1.y=touch.position.y; 
				touchPos1.z=touchOverlayZ;
				Vector3 touchPos13D = Camera.main.ScreenToWorldPoint(touchPos1);

				TouchPointSprite_1.transform.position = touchPos13D;

				Debug.Log("We're in touch 1");

			} else {
					//rigidbody2D.velocity=Vector2.zero;
			
			}


			if (Input.GetTouch(1).phase != TouchPhase.Ended) {
				//rigidbody2D.AddForce ((Vector2)forzeDir3D);
				
	//			Touch touch_two = Input.GetTouch (1);
				
				Vector3 touchPos2; 
				touchPos2.x=touch.position.x; touchPos2.y=touch.position.y; 
				touchPos2.z=touchOverlayZ;
				Vector3 touchPos23D = Camera.main.ScreenToWorldPoint(touchPos2);
				
				TouchPointSprite_2.transform.position = touchPos23D;
				
				Debug.Log("We're in touch 2");
				
			} else {
				//rigidbody2D.velocity=Vector2.zero;
				
			}


		}
	
	}






}