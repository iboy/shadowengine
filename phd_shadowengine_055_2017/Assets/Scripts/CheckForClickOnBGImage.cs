using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;



public class CheckForClickOnBGImage : MonoBehaviour, IPointerClickHandler
{

	public GameObject guiController; 
	private AnimatePanelInOut_Tab1_Controller panelController;

	void Start () {

		 panelController = guiController.GetComponent( typeof(AnimatePanelInOut_Tab1_Controller) ) as AnimatePanelInOut_Tab1_Controller;



	}

	public virtual void OnPointerClick(PointerEventData eventData)
	{
		//Debug.Log(eventData.pointerCurrentRaycast.gameObject.name);

		if (eventData.pointerCurrentRaycast.gameObject.name == "Background Image") {

			// This detects if a click has happened on the BG Image - if so we close the panel


			//Debug.Log("You clicked the phreaking BG image");
			panelController.togglePanel();
		}

	}
}