using UnityEngine;
using System.Collections;

//[ExecuteInEditMode]
public class ToggleControllerSetVisibility : MonoBehaviour {

	public bool visible = true;
	public bool invisible = false;
	public bool drawLines = true;
	public bool b_controllerSet1 = true; 
	public bool b_controllerSet2 = true; 
	public bool b_controllerSet3 = true;
	public bool b_controllerSet4 = true; 
	[Range(0f,1f)]
	public float globalControllerAlpha =.54f;
	public bool controllersAreGrayScale = false;

	public bool activateSet1 = true;
	public GameObject[] controllerSet1;
	public Color controllerSet1Color;
	public bool activateSet2 = true;
	public GameObject[] controllerSet2;
	public Color controllerSet2Color;
	public bool activateSet3 = true;
	public GameObject[] controllerSet3;
	public Color controllerSet3Color;
	public bool activateSet4 = true;
	public GameObject[] controllerSet4;
	public Color controllerSet4Color;
	private float currentGlobalControllerAlpha;
	// Update is called once per frame
	private UIControllerScript UIController;

	private GameObject GUIController;
	void Start() {


		GUIController = GameObject.Find("_GUIController");
		UIController = (UIControllerScript)GUIController.GetComponent(typeof(UIControllerScript));
		//UIController.PuppetControllerAlphaAmount = GUIDataManager.guiData.controllerAlphaAmountValue;
		//Debug.Log(UIController.name);
		//puppetControllerVisibity
		//puppetControllerAlphaAmount

		//c.OnVariableChange += VariableChangeHandler;

	}

	//public void setGlobalControllerAlpha(float value){
	//
	//
	//	globalControllerAlpha = value;
	//	currentGlobalControllerAlpha  = value;
	//
	//	UIController.PuppetControllerAlphaAmount = value;
	//}

	public void setControllerSetIsGrayScale(bool state) {

		controllersAreGrayScale = state;
		GUIDataManager.guiData.controllerIsGrayscaleIsOn = state;

	}

	//public void setGlobalControllerAlphaIsOn(bool state){
	//	
	//	if (state == true) {
	//		
	//		globalControllerAlpha = currentGlobalControllerAlpha;
	//		UIController.PuppetControllerVisibity = false; 
	//
	//		GUIDataManager.guiData.controllerAlphaAmountValue = currentGlobalControllerAlpha;
	//		GUIDataManager.guiData.controllerVisibilityIsOn = true;
	//
	//	} else {
	//
	//		UIController.PuppetControllerAlphaAmount = 0f;
	//		UIController.PuppetControllerVisibity = false; 
	//		//globalControllerAlpha = 0f;
	//		GUIDataManager.guiData.controllerAlphaAmountValue = 0f;
	//		GUIDataManager.guiData.controllerVisibilityIsOn = false;
	//
	//	}


	//}
	void Update () {

		globalControllerAlpha = UIController.PuppetControllerAlphaAmount;

		//if (UIController.PuppetControllerAlphaAmount > 0f) {
		//
		//	UIController.PuppetControllerVisibility = true;
		//
		//} else {
		//
		//	UIController.PuppetControllerVisibility = false;
		//
		//}

		if (visible == true) {
			b_controllerSet1 = true;
			b_controllerSet2 = true;
			b_controllerSet3 = true;
			b_controllerSet4 = true;
			invisible = false;
		} 

		if (invisible == true) {
			b_controllerSet1 = false;
			b_controllerSet2 = false;
			b_controllerSet3 = false;
			b_controllerSet4 = false;
			visible = false;
		} 

		if (drawLines == false) {
			//DrawingDebugLines lines =  
			Camera.main.GetComponent<DrawingDebugLines>().drawInGame = false;
			Camera.main.GetComponent<DrawingDebugLines>().drawInEditor = false;
		} else {
			Camera.main.GetComponent<DrawingDebugLines>().drawInGame = true;
			Camera.main.GetComponent<DrawingDebugLines>().drawInEditor = true;
		}
//----------------------------------------------------------------------------------------------
// toggle visibility of renderer on set 1
		if (b_controllerSet1 == true || visible == true ) { // || on == true
		
			foreach (GameObject go in controllerSet1) {

				if (go != null) {

					//go.activeInHierarchy = false;

						
						SpriteRenderer spriteRenderer = go.GetComponent<SpriteRenderer>();

						if (spriteRenderer != null) {

						if (controllersAreGrayScale == false) {
							float r = controllerSet1Color.r;
							float g = controllerSet1Color.g;
							float b = controllerSet1Color.b;
							float a = globalControllerAlpha;
							spriteRenderer.color = new Color(r, g, b, a);
						} else {
							// 0.21 R + 0.72 G + 0.07 B.
							float r = 0.005917f;
							float g = 0.005917f;
							float b = 0.005917f;
							float a = globalControllerAlpha;
							spriteRenderer.color = new Color(r, g, b, a);
						}

						GUIDataManager.guiData.controllerAlphaAmountValue = globalControllerAlpha;
				
						} // maybe handle other kinds of renderer here

				}
			}
		} else { // b_controllerSet1 == false


			 
			foreach (GameObject go in controllerSet1) {


				if (go != null) {

					//go.activeInHierarchy = false;

					SpriteRenderer spriteRenderer = go.GetComponent<SpriteRenderer>();

					if (spriteRenderer != null) {

						if (controllersAreGrayScale == false) {

							float r = controllerSet1Color.r;
							float g = controllerSet1Color.g;
							float b = controllerSet1Color.b;
							spriteRenderer.color = new Color(r, g, b, 0);
						} else {

							float r = 0.005917f;
							float g = 0.005917f;
							float b = 0.005917f;
							spriteRenderer.color = new Color(r, g, b, 0);
						}


						//float a = controllerSet1Color.a;

						 
						GUIDataManager.guiData.controllerAlphaAmountValue = 0f;
					} // maybe handle other kinds of renderer here
				} 
			}
		} // end of b_controllerSet1 == false
// end of toggle set 1
//----------------------------------------------------------------------------------------------
// toggle visibility of renderer on set 2
		if (b_controllerSet2 == true || visible == true) {

			foreach (GameObject go in controllerSet2) {

				if (go != null) {

					//go.activeInHierarchy = false;

					SpriteRenderer spriteRenderer = go.GetComponent<SpriteRenderer>();

					if (spriteRenderer != null ) {
						
						if (controllersAreGrayScale == false) {
							float r = controllerSet2Color.r;
							float g = controllerSet2Color.g;
							float b = controllerSet2Color.b;
							float a = globalControllerAlpha;
							spriteRenderer.color = new Color(r, g, b, a);
						} else {
							// 0.21 R + 0.72 G + 0.07 B.
							float r = 0.0078125f;
							float g = 0.0078125f;
							float b = 0.0078125f;
							float a = globalControllerAlpha;
							spriteRenderer.color = new Color(r, g, b, a);
						}



						GUIDataManager.guiData.controllerAlphaAmountValue = globalControllerAlpha;

					} // maybe handle other kinds of renderer here
				} 
			}
		} else { 
			//if (all == true) { all = false; } 
			// b_controllerSet2 == false
			foreach (GameObject go in controllerSet2) {


				if (go != null) {

					//go.activeInHierarchy = false;

					SpriteRenderer spriteRenderer = go.GetComponent<SpriteRenderer>();

					if (spriteRenderer != null ) {
						if (controllersAreGrayScale == false) {

							float r = controllerSet2Color.r;
							float g = controllerSet2Color.g;
							float b = controllerSet2Color.b;
							spriteRenderer.color = new Color(r, g, b, 0);
						} else {

							float r = 0.0078125f;
							float g = 0.0078125f;
							float b = 0.0078125f;
							spriteRenderer.color = new Color(r, g, b, 0);
						}

						GUIDataManager.guiData.controllerAlphaAmountValue = 0f;

					} // maybe handle other kinds of renderer here
				} 
			}
		} // end of b_controllerSet2 == false
// end of toggle set 2
//----------------------------------------------------------------------------------------------
// toggle visibility of renderer on set 3
		if (b_controllerSet3 == true || visible == true ) {
			
			foreach (GameObject go in controllerSet3) {

				if (go != null) {

					//go.activeInHierarchy = false;

					SpriteRenderer spriteRenderer = go.GetComponent<SpriteRenderer>();

					if (spriteRenderer != null) {
						if (controllersAreGrayScale == false) {
							float r = controllerSet3Color.r;
							float g = controllerSet3Color.g;
							float b = controllerSet3Color.b;
							float a = globalControllerAlpha;
							spriteRenderer.color = new Color(r, g, b, a);
						} else {
							// 0.21 R + 0.72 G + 0.07 B.
							float r = 0.009524f;
							float g = 0.009524f;
							float b = 0.009524f;
							float a = globalControllerAlpha;
							spriteRenderer.color = new Color(r, g, b, a);
						}

						GUIDataManager.guiData.controllerAlphaAmountValue = globalControllerAlpha;

					} // maybe handle other kinds of renderer here
				} 
			}
		} else { // b_controllerSet3 == false
			//if (all == true) { all = false; } 

			foreach (GameObject go in controllerSet3) {


				if (go != null) {

					//go.activeInHierarchy = false;

					SpriteRenderer spriteRenderer = go.GetComponent<SpriteRenderer>();

					if (spriteRenderer != null) {
						if (controllersAreGrayScale == false) {

							float r = controllerSet3Color.r;
							float g = controllerSet3Color.g;
							float b = controllerSet3Color.b;
							spriteRenderer.color = new Color(r, g, b, 0);
						} else {

							float r = 0.009524f;
							float g = 0.009524f;
							float b = 0.009524f;
							spriteRenderer.color = new Color(r, g, b, 0);
						}

						GUIDataManager.guiData.controllerAlphaAmountValue = 0f;

					} // maybe handle other kinds of renderer here
				} 
			}
		} // end of b_controllerSet3 == false
// end of toggle set 3
//----------------------------------------------------------------------------------------------
// toggle visibility of renderer on set 4
		if (b_controllerSet4 == true || visible == true ) {

			foreach (GameObject go in controllerSet4) {

				if (go != null) {

					//go.activeInHierarchy = false;

					SpriteRenderer spriteRenderer = go.GetComponent<SpriteRenderer>();

					if (spriteRenderer != null) {
						if (controllersAreGrayScale == false) {
							float r = controllerSet4Color.r;
							float g = controllerSet4Color.g;
							float b = controllerSet4Color.b;
							float a = globalControllerAlpha;
							spriteRenderer.color = new Color(r, g, b, a);
						} else {
							// 0.21 R + 0.72 G + 0.07 B.
							float r = 0.0078125f;
							float g = 0.0078125f;
							float b = 0.0078125f;
							float a = globalControllerAlpha;
							spriteRenderer.color = new Color(r, g, b, a);
						}

						GUIDataManager.guiData.controllerAlphaAmountValue = globalControllerAlpha;

					} // maybe handle other kinds of renderer here
				} 
			}
		} else { // b_controllerSet4 == false
			//if (all == true) { all = false; } 

			foreach (GameObject go in controllerSet4) {


				if (go != null) {

					//go.activeInHierarchy = false;

					SpriteRenderer spriteRenderer = go.GetComponent<SpriteRenderer>();

					if (spriteRenderer != null) {
						if (controllersAreGrayScale == false) {

							float r = controllerSet4Color.r;
							float g = controllerSet4Color.g;
							float b = controllerSet4Color.b;
							spriteRenderer.color = new Color(r, g, b, 0);
						} else {

							float r = 0.0078125f;
							float g = 0.0078125f;
							float b = 0.0078125f;
							spriteRenderer.color = new Color(r, g, b, 0);
						}

						GUIDataManager.guiData.controllerAlphaAmountValue = 0f;

					} // maybe handle other kinds of renderer here
				} 
			}
		} // end of b_controllerSet4 == false
		// end of toggle set 4




//----------------------------------------------------------------------------------------------
//---------------------------------------------------------

		if (activateSet1 == false) {
		
			foreach (GameObject go in controllerSet1) {
				if (go != null) {

					if (go.activeInHierarchy == true) {
						go.SetActive(false);
					}
				} // maybe handle other kinds of renderer here
			} 
		


	} else {

		foreach (GameObject go in controllerSet1) {

			if (go != null) {

				if (go.activeInHierarchy == false) {
						go.SetActive(true);
				}
			} 
		} 

	}
//---------------------------------------------------------

		if (activateSet2 == false) {

			foreach (GameObject go in controllerSet2) {
				if (go != null) {

					if (go.activeInHierarchy == true) {
						go.SetActive(false);
					}
				} // maybe handle other kinds of renderer here
			} 



		} else {

			foreach (GameObject go in controllerSet2) {

				if (go != null) {

					if (go.activeInHierarchy == false) {
						go.SetActive(true);
					}
				} 
			} 

		}
//---------------------------------------------------------

		if (activateSet3 == false) {

			foreach (GameObject go in controllerSet3) {
				if (go != null) {

					if (go.activeInHierarchy == true) {
						go.SetActive(false);
					}
				} // maybe handle other kinds of renderer here
			} 



		} else {

			foreach (GameObject go in controllerSet3) {

				if (go != null) {

					if (go.activeInHierarchy == false) {
						go.SetActive(true);
					}
				} 
			} 

		}
//---------------------------------------------------------

		if (activateSet4 == false) {

			foreach (GameObject go in controllerSet4) {
				if (go != null) {

					if (go.activeInHierarchy == true) {
						go.SetActive(false);
					}
				} // maybe handle other kinds of renderer here
			} 



		} else {

			foreach (GameObject go in controllerSet4) {

				if (go != null) {

					if (go.activeInHierarchy == false) {
						go.SetActive(true);
					}
				} 
			} 

		}
//---------------------------------------------------------
	} // end of update

}