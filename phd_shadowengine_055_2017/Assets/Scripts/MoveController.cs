using UnityEngine;
using System.Collections;
using HedgehogTeam.EasyTouch;


public class MoveController : MonoBehaviour {
	public Transform myCamera;

	public void moveCamera(Gesture gesture) {
//		float originalXPos = 0f; 
//		float originalYPos = 1.0f; 
		float currentXPos = myCamera.position.x;
		float currentYPos = myCamera.position.y;

		Debug.Log("moveCamera() called. Gesture Swipe:"+gesture.swipe+". Current X Position: "+currentXPos+"Current Y Position: "+currentYPos);

		//if (gesture.pickedObject.tag =="Set") { // tag name == set
			
			switch (gesture.swipe) {
			
			case EasyTouch.SwipeDirection.Right:
				if (currentXPos< -26) { break; } else {
				iTween.MoveBy(myCamera.gameObject, new Vector3(-13.38f,0,0),1.0f);
				break;
				}
			
			case EasyTouch.SwipeDirection.Left: 
				if (currentXPos> 26) { break; } else {
					iTween.MoveBy(myCamera.gameObject, new Vector3(13.38f,0,0),1.0f);
					break;
				}
			
			
			case EasyTouch.SwipeDirection.Down:
				if (currentYPos>21 ) { break; } else {
					iTween.MoveBy(myCamera.gameObject, new Vector3(0,10.064852f,0),1.0f);
					break;
				}
			
			case EasyTouch.SwipeDirection.Up:
				if (currentYPos< -19) { break; } else {
					iTween.MoveBy(myCamera.gameObject, new Vector3(0,-10.064852f,0),1.0f);
					break;
				}
			
			
			default:
				break;
			}

		//}
		//public float smoothTime = 0.3F;
		//private float yVelocity = 0.0F;
		//void Update() {
		//	float newPosition = Mathf.SmoothDamp(transform.position.y, target.position.y, ref yVelocity, smoothTime);
		//	transform.position = new Vector3(transform.position.x, newPosition, transform.position.z);

		

	}

}
