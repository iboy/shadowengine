using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;



public class GetClickPositionOnXYController : MonoBehaviour, IPointerClickHandler
{

	//public GameObject guiController; 
	//private AnimatePanelInOut_Tab1_Controller panelController;

	public RectTransform dragZone;
	public RectTransform draggable;
	public float moveDuration;
	private Vector2 draggableCurrentPosition;
	private Vector2 localCursor;
	private Vector2 targetPosition;
	private Vector3 cameraTargetPosition;
	private bool targetClicked;
	//private float dragZoneXPos;
	//private float dragZoneYPos;
	//private float dragZoneWidth;
	//private float dragZoneHeight;
	//
	//private float screenWidth;
	//private float screenHeight;
	//
	//private float startPointX;
	//private float endPointX;
	//private float startPointY;
	//private float endPointY;
	//private float midPointX;
	//private float midPointY;




	void Start () {

		//panelController = guiController.GetComponent( typeof(AnimatePanelInOut_Tab1_Controller) ) as AnimatePanelInOut_Tab1_Controller;
		//dragZoneXPos = dragZone.rect.position.x;
		//dragZoneYPos = dragZone.rect.position.y;
		//dragZoneWidth = dragZone.rect.width;
		//dragZoneHeight = dragZone.rect.height;
		//screenWidth = 2048f;   // hard coded ipad width
		//screenHeight = 1536f;  // hard coded ipad height
		//
		//startPointX = screenWidth - dragZoneXPos;
		//startPointY = screenHeight - dragZoneYPos;
		//endPointX = screenWidth  + dragZoneWidth;
		//endPointY = screenHeight  + dragZoneHeight;
		//midPointX = startPointX + (dragZoneWidth / 2);
		//midPointY = startPointY + (dragZoneHeight / 2);

	}




	public virtual void OnPointerClick(PointerEventData eventData)
	{
		//Debug.Log(eventData.pointerCurrentRaycast.gameObject.name);

		if (eventData.pointerCurrentRaycast.gameObject.name == "DragZone") {

			// This detects if a click has happened on the DragZone - if so we close the panel

			//Debug.Log(eventData.position.x);
			//Debug.Log(eventData.position.y);

			// This returns the local rect coordinates of the pointer position clicked on the drag zone



			if (!RectTransformUtility.ScreenPointToLocalPointInRectangle(GetComponent<RectTransform>(), eventData.position, eventData.pressEventCamera, out localCursor)) {

				targetClicked = false;
				return;  } else {

				targetClicked = true;
				draggableCurrentPosition = draggable.transform.localPosition;
				targetPosition = new Vector2(localCursor.x, localCursor.y);
				Vector3 camPos = Camera.main.transform.position;
				cameraTargetPosition = new Vector3(Mathf.Clamp(targetPosition.x, -40, 40),Mathf.Clamp(targetPosition.y, -30,30), camPos.z);

			}

			//Debug.Log("LocalCursor:" + localCursor);


			// conver this to local space
		} else { targetClicked = false; }




	}

	void Update () {

		if (targetClicked == true) {

			//Vector3 camPos = Camera.main.transform.position;
			//Camera.main.transform.position = new Vector3 (Mathf.Clamp(xpos, -40, 40), Mathf.Clamp(ypos, -30,30), camPos.z);

			LeanTween.move(Camera.main.gameObject, cameraTargetPosition, moveDuration).setEase(LeanTweenType.easeInOutQuad);
			LeanTween.move(draggable, targetPosition, moveDuration).setEase(LeanTweenType.easeInOutQuad);




		}
	}


}