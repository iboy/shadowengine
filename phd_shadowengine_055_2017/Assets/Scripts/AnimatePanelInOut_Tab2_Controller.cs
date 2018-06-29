using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class AnimatePanelInOut_Tab2_Controller : MonoBehaviour {
	public Animator contentPanel;
	public GameObject panel;
	public GameObject bg;

	// Use this for initialization
	private float posX;
	private float posY;
	private float posZ;
	private float panelHeight; 
	private bool panelVisible = false;
	private float yTouchPos;
	private int count;
	private Ray myRay;

	void Start () {
		RectTransform transform = contentPanel.gameObject.transform as RectTransform;
		Vector2 position = transform.anchoredPosition;
		panelHeight = transform.rect.height;
		position.y -= panelHeight;
		transform.anchoredPosition = position;
		count = 0;
	}

	void Update () {

		
		// instead of this use a button
		//check mouse pointer
		//if (Input.mousePosition.y < 10 && panelVisible == false) {
		//
		//	//Debug.Log("Mouse Pos / Touch pos is less than 10 etc..");	
		//	togglePanel(true);
		//
		//} else {
		//	
		//	if (Input.mousePosition.y >panelHeight+10 && panelVisible == true) {
		//		
		//		//Debug.Log("Mouse Pos / Touch pos is higher than 10 etc..");
		//
		//		togglePanel(false);
		//
		//	}
		//}


	}



	public void togglePanel() {
		//bool isHidden = contentPanel.GetBool("isHidden");

		if (count %2 == 0 ){

			contentPanel.enabled = true;

			//bool isHidden = contentPanel.GetBool("isHidden");
			contentPanel.SetBool("isHidden", false);

			//Debug.Log ("Panel is in View");
			panelVisible = true;
			bg.SetActive (true);
			//panel.transform.position = new Vector3 (posX,0,posZ);
			count++;

		} else {


			//Debug.Log ("Panel is hidden");
			contentPanel.SetBool("isHidden", true);
			//contentPanel.enabled = false;ma
			panelVisible = false;
			bg.SetActive (false);
			//panel.transform.position = new Vector3 (posX,-100,posZ);

			count++;
		}

	}

}

