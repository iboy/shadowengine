using UnityEngine;
using System.Collections;
using HedgehogTeam.EasyTouch;

public class XYControllerConstraints : MonoBehaviour {

	// Use this for initialization
	public RectTransform draggable;
	public RectTransform bounds;
	public float resetAnimationSpeed = .5f;
	private float draggableWidth;
	private float draggableHeight;
	private float boundsWidth;
	private float boundsHeight;
	private Vector3 cameraDefaultPosition;


	void Start () {
		draggableWidth = draggable.rect.width;
		draggableHeight = draggable.rect.height;

		boundsWidth = bounds.rect.width;
		boundsHeight = bounds.rect.height;
		//cameraDefaultPosition = Camera.main.transform.position;
		cameraDefaultPosition = new Vector3 (0f,1f,-10f);

	}

	
	// Update is called once per frame
	void Update () {
	


	}

	public void DragStarts() {




	}

	public void ResetDraggablePositionAndCamera() {

		//new Vector2 ( 0, 0); 
		//LeanTween.move(draggable, new Vector2 ( 0f, 0f) ,resetAnimationSpeed).setEase(LeanTweenType.easeInOutQuad);

		draggable.localPosition = new Vector2 ( 0, 0); 
		//LeanTween.move(Camera.main.gameObject, cameraDefaultPosition, 1f).setEase(LeanTweenType.easeInOutQuad); 
		Camera.main.transform.position = new Vector3 (cameraDefaultPosition.x,cameraDefaultPosition.y,cameraDefaultPosition.z);

	}

	public void IsDragging() {
		//Debug.Log(draggable.localPosition.x );
		//Debug.Log(draggable.localPosition.y );

		float xpos = draggable.localPosition.x;
		float ypos = draggable.localPosition.y;
		if (draggable.localPosition.x < -boundsWidth/2 ) {


			xpos = -boundsWidth/2 + (draggableWidth / 2 );
			draggable.localPosition = new Vector2 ( xpos, ypos); 

		}

		if (draggable.localPosition.x > boundsWidth/2  ) {


			xpos = boundsWidth / 2 - (draggableWidth / 2 );
			draggable.localPosition = new Vector2 ( xpos, ypos); 

		}

		if (draggable.localPosition.y > boundsHeight/2  ) {


			ypos = boundsHeight / 2 - (draggableHeight / 2 );
			draggable.localPosition = new Vector2 ( xpos, ypos); 

		}

		if (draggable.localPosition.y < -boundsHeight/2  ) {


			ypos = -boundsHeight / 2 + (draggableHeight / 2 );
			draggable.localPosition = new Vector2 ( xpos, ypos); 

		}

		Vector3 camPos = Camera.main.transform.position;
		Camera.main.transform.position = new Vector3 (Mathf.Clamp(xpos, -40, 40), Mathf.Clamp(ypos, -30,30), camPos.z);

	}

	public void DragEnds() {

		Vector3 camPos = Camera.main.transform.position;

		Camera.main.transform.position = camPos;
	}

	public void SetCameraPositionX (float xpos) {
		
		Vector3 camPos = Camera.main.transform.position;

		Camera.main.transform.position = new Vector3 (xpos, camPos.y, camPos.z);


	}

	public void SetCameraPositionY (float ypos) {

		Vector3 camPos = Camera.main.transform.position;

		Camera.main.transform.position = new Vector3 (camPos.x, ypos, camPos.z);


	}

	public void SetCameraPositionZ (float zpos) {

		Vector3 camPos = Camera.main.transform.position;

		Camera.main.transform.position = new Vector3 (camPos.x, camPos.y, zpos);


	}
}
