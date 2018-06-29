using UnityEngine;
using System.Collections;

 
public class CircleTouch : MonoBehaviour {


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
	private bool mouseTouch = 		false;

	// Use this for initialization
	void Start () {
	
	}



	// Update is called once per frame
	void Update () {
	
		// Handle mouse click (this also handles the first touch (on iOS)
		//Debug.Log("Mouse clicked");
		//if (Input.GetMouseButton(0)) {
		//	
		//	mouseTouch = true; 
		//	TouchPointSprite_1.SetActive(true);
		//	//Debug.Log(mouseTouch);
		//} else {			
		//	mouseTouch = false; 
		//	TouchPointSprite_1.SetActive(false);
		//	//Debug.Log(mouseTouch);
		//	
		//}


		if (mouseTouch == true) {

			//Instantiate(circle, Camera.main.ScreenToWorldPoint(fTC), Quaternion.identity);
			//TouchPointSprite_1.SetActive(true);
			//mousePosition = Input.mousePosition;
			//mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
			//TouchPointSprite_1.transform.position = new Vector3(mousePosition.x, mousePosition.y, touchOverlayZ);
			//circle.transform.position= new Vector3(Input.mousePosition);
			
			
		}

		// Next check for extra touches

		int fingerCount = 0;
		foreach (Touch touch in Input.touches) {
			if (touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled){
				fingerCount++;
			}

		}
		if (fingerCount > 0)
		{
			//print("User has " + fingerCount + " finger(s) touching the screen");

			if (fingerCount == 1){
		
				Debug.Log("Moving touch 1 pad");
				Vector3 touchDeltaPosition1 = Input.GetTouch(0).position; // remember get touched is zero indexed.
				TouchPointSprite_1.SetActive(true);
				//TouchPointSprite_1.transform.Translate(-touchDeltaPosition1.x * trackSpeed, -touchDeltaPosition1.y * trackSpeed, touchOverlayZ);

				touchDeltaPosition1 = Camera.main.ScreenToWorldPoint(touchDeltaPosition1);
				TouchPointSprite_1.transform.position = new Vector3(touchDeltaPosition1.x, touchDeltaPosition1.y, touchOverlayZ);
				//touchPosition1 = Input.GetTouch(0).position;
				//touchPosition1 = Camera.main.ScreenToWorldPoint(touchPosition1);
				//TouchPointSprite_1.transform.position = new Vector3(touchPosition1.x, touchPosition1.y, touchOverlayZ);
				//touchPosition2 = Touch;
				//mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
				//TouchPointSprite_1.transform.position = new Vector3(mousePosition.x, mousePosition.y, touchOverlayZ);
			}

			if (fingerCount == 2) {
				Debug.Log("Moving touch 2 pad");

				Vector3 touchDeltaPosition2 = Input.GetTouch(1).position; // remember get touched is zero indexed.
				TouchPointSprite_2.SetActive(true);
				//TouchPointSprite_2.transform.Translate(-touchDeltaPosition2.x * trackSpeed, -touchDeltaPosition2.y * trackSpeed, touchOverlayZ);
				
				touchDeltaPosition2 = Camera.main.ScreenToWorldPoint(touchDeltaPosition2);
				TouchPointSprite_2.transform.position = new Vector3(touchDeltaPosition2.x, touchDeltaPosition2.y, touchOverlayZ);
			}

		}
	



		//if(Input.touchCount > 1 ){ //Does finger count on screen equal 1?

			//if (Input.GetMouseButtonDown(0)) {
		
			//Debug.Log("More than one touch");

		//	if(Input.touchCount == 2 ){

				//Debug.Log("Two touches");

		//	}





		// }
		

		//	if (Input.touchCount == 1) {
		//	if(Input.GetTouch(0).phase == TouchPhase.Began){ //When touch on the touch screen begins.
            
		//		fTC = Input.GetTouch(0).position;
		//		Instantiate(TouchPointSprite_1, Camera.main.ScreenToWorldPoint(fTC), Quaternion.identity);
             //Debug.Log(fTC);
     //    }
         
	//		if(Input.GetTouch(0).phase == TouchPhase.Ended){ //When touch on the touch screen ends.
            
				//Destroy(circleTouch); //This gave me an error. Never used destroy before but thought I'd try it.
         
	//			}
     
			
		
	

}
}