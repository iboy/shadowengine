using UnityEngine;
using System.Collections;


public class ToggleMaterial : MonoBehaviour {

	public GameObject[] gameObjectsToToggle;
	public Color32 defaultTintColor = Color.white;
	public Color32 targetTintColor = Color.black;
	private Renderer rend;
	public Camera mainCamera;

	//private bool spaceToggle = false;

	// Use this for initialization
	void Start () {

		// cache all material colours
		//foreach (GameObject go in gameObjectsToToggle) {
		//	SetMaterialToBlack(go);
		//
		//}


	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Z)) {

				foreach (GameObject go in gameObjectsToToggle) {
					SetMaterialToBlack(go);

				}

		}
			
		if (Input.GetKeyDown(KeyCode.X)) {

			foreach (GameObject go in gameObjectsToToggle) {
				SetMaterialToDefault(go);
				
			}

		}

		if (Input.GetKeyDown(KeyCode.C)) {

			if (mainCamera != null) {
				GrayscaleEffect gs = mainCamera.GetComponent<GrayscaleEffect>();
				gs.enabled = !gs.enabled;

			}
			
		}


	}

	void SetMaterialToBlack( GameObject obj ) {

		//Debug.Log(obj.name);

		if (obj.renderer !=null) {


			obj.renderer.material.SetColor ("_Color", targetTintColor);

		
		}
		foreach (Transform child2 in obj.transform)
		{
			
			SetMaterialToBlack(child2.gameObject);
			
		}

	}

	void SetMaterialToDefault( GameObject obj ) {
		
		//Debug.Log(obj.name);
		
		if (obj.renderer !=null) {
			//rend = obj.GetComponent<Renderer>();
			
			//rend.material.color =  Color.blue;

			//obj.renderer.material.color =  Color.black;
			obj.renderer.material.SetColor ("_Color", defaultTintColor);
		}
		foreach (Transform child in obj.transform)
		{
			
			SetMaterialToDefault(child.gameObject);
			
		}
		
	}
	

}
