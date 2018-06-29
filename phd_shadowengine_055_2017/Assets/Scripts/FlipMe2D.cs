using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using HedgehogTeam.EasyTouch;

public class FlipMe2D : MonoBehaviour {

	public GameObject puppetRoot;
	public GameObject puppetBaseObject;
	public GameObject puppetBaseController;
	public bool dynamicHeirarchy = false; 
	QuickTwist twister;
	public List<Rigidbody2D> rigidbody2DList;
	private Rigidbody2D[] rigidbodies2D;

	public List<GameObject> itemsToParent;
	//public Vector3 axisToFlipAcross = new Vector3 (0f,1f,0f);
	public bool flipX = true;
	public bool flipY = false;
	public float flipSpeed = 0.2f;
	int flipCount = 0; 
	private float yRot = 180f;
	//public float speed;


	public void FlipViaScale(Gesture gesture) {


		// improvement: dynamically parent all non-controller children
		// to controller 1 on flipviascale...

		//float originalPuppetRootXPosition = puppetRoot.transform.position.x;
		//float originalpuppetBaseXObject = puppetBaseObject.transform.position.x;
		//if (gesture.pickedObject.tag == "PuppetBaseObject" ) { // select intended target - this needs to be consistent 
		// commented out due to remote workings - clicking on controller to flip BEWARE weirdness
			//float currentXScale = 

			float currentXScale = puppetBaseController.transform.localScale.x;
			float currentYScale = puppetBaseController.transform.localScale.y;
			float currentZScale = puppetBaseController.transform.localScale.z;


			// the reparenting is in response to a varied heirarchy in 
			// PuppetRoot_Wayang_Spring_Network_MT- Less Heirarchy
			// the arrangement gives additional physical simulation
			// but items need to be dynamicially reparent prior to 'flipping' via scale

			//LeanTween.move();
			//ReparentObjects();
			//LeanTween.scaleX(puppetBaseController, -currentXScale, flipSpeed);
			//UnparentObjects();


			//LeanTween.scaleX(puppetBaseController, -currentXScale, flipSpeed).setOnStart( ()=>{ ReparentObjects(); }).setOnComplete( ()=> {UnparentObjects();});;
			if (flipX == true && flipY == false) {
				//Debug.Log("You're flipping the Puppet on X");
			iTween.ScaleTo(puppetBaseController,iTween.Hash(
				"name", "flipX",
				"x", -currentXScale, 
				"y", currentYScale, 
				"z", currentZScale, 
				"time", flipSpeed, 
				"EaseType","EaseInQuad",
				"oncomplete", "UnparentObjects",
				"onstart", "ReparentObjects",
				"onstarttarget", gameObject,
				"oncompletetarget", gameObject
			)
			);

			}

			if (flipY == true && flipX == false) {
				//Debug.Log("You're flipping the Puppet on Y");
				iTween.ScaleTo(puppetBaseController,iTween.Hash(
					"name", "flipY",
					"x", currentXScale, 
					"y", -currentYScale, 
					"z", currentZScale, 
					"time", flipSpeed, 
					"EaseType","EaseInQuad",
					"oncomplete", "UnparentObjects",
					"onstart", "ReparentObjects",
					"onstarttarget", gameObject,
					"oncompletetarget", gameObject
				)
				);

			}

			if (flipY == true && flipX == true) {
				//Debug.Log("You're flipping the Puppet on XY");
				iTween.ScaleTo(puppetBaseController,iTween.Hash(
					"name", "flipXY",
					"x", -currentXScale, 
					"y", -currentYScale, 
					"z", currentZScale, 
					"time", flipSpeed, 
					"EaseType","EaseInQuad",
					"oncomplete", "UnparentObjects",
					"onstart", "ReparentObjects",
					"onstarttarget", gameObject,
					"oncompletetarget", gameObject
				)
				);

			}

			flipCount = flipCount + 1; 
			if (flipCount % 2!=0) {

				//Debug.Log("Puppet is flipped - we better invert some of the controls");
				twister = puppetBaseObject.GetComponent<QuickTwist>();
				twister.inverseAxisValue = true;

			} else {
				twister = puppetBaseObject.GetComponent<QuickTwist>();
				twister.inverseAxisValue = false;
			}
			//transform.localScale = new Vector3( -transform.localScale.x,  transform.localScale.y, transform.localScale.z);

			// notes local transform the root means there is an ofset if the heirarchy has moved away from the root. Instead - restructure the 
			// heirarchy and use local transform on the base controller...

			//Debug.Log("You're flipping the Puppet");

			//Rigidbody2D myRigidbody;
			//myRigidbody  = puppetBaseObject.GetComponent<Rigidbody2D>();
			//myRigidbody.MoveRotation(180);
			//gesture.pickedObject








	}

	public void FlipViaScaleForRemoteControl(GameObject go) {


		// improvement: dynamically parent all non-controller children
		// to controller 1 on flipviascale...

		//float originalPuppetRootXPosition = puppetRoot.transform.position.x;
		//float originalpuppetBaseXObject = puppetBaseObject.transform.position.x;
		//if (go.tag == "PuppetBaseObject" ) { // select intended target - this needs to be consistent
			//float currentXScale = 

			float currentXScale = puppetBaseController.transform.localScale.x;
			float currentYScale = puppetBaseController.transform.localScale.y;
			float currentZScale = puppetBaseController.transform.localScale.z;


			// the reparenting is in response to a varied heirarchy in 
			// PuppetRoot_Wayang_Spring_Network_MT- Less Heirarchy
			// the arrangement gives additional physical simulation
			// but items need to be dynamicially reparent prior to 'flipping' via scale

			//LeanTween.move();
			//ReparentObjects();
			//LeanTween.scaleX(puppetBaseController, -currentXScale, flipSpeed);
			//UnparentObjects();


			//LeanTween.scaleX(puppetBaseController, -currentXScale, flipSpeed).setOnStart( ()=>{ ReparentObjects(); }).setOnComplete( ()=> {UnparentObjects();});;
			if (flipX == true && flipY == false) {
				//Debug.Log("You're flipping the Puppet on X");
				iTween.ScaleTo(puppetBaseController,iTween.Hash(
					"name", "flipX",
					"x", -currentXScale, 
					"y", currentYScale, 
					"z", currentZScale, 
					"time", flipSpeed, 
					"EaseType","EaseInQuad",
					"oncomplete", "UnparentObjects",
					"onstart", "ReparentObjects",
					"onstarttarget", gameObject,
					"oncompletetarget", gameObject
				)
				);

			}

			if (flipY == true && flipX == false) {
				//Debug.Log("You're flipping the Puppet on Y");
				iTween.ScaleTo(puppetBaseController,iTween.Hash(
					"name", "flipY",
					"x", currentXScale, 
					"y", -currentYScale, 
					"z", currentZScale, 
					"time", flipSpeed, 
					"EaseType","EaseInQuad",
					"oncomplete", "UnparentObjects",
					"onstart", "ReparentObjects",
					"onstarttarget", gameObject,
					"oncompletetarget", gameObject
				)
				);

			}

			if (flipY == true && flipX == true) {
				//Debug.Log("You're flipping the Puppet on XY");
				iTween.ScaleTo(puppetBaseController,iTween.Hash(
					"name", "flipXY",
					"x", -currentXScale, 
					"y", -currentYScale, 
					"z", currentZScale, 
					"time", flipSpeed, 
					"EaseType","EaseInQuad",
					"oncomplete", "UnparentObjects",
					"onstart", "ReparentObjects",
					"onstarttarget", gameObject,
					"oncompletetarget", gameObject
				)
				);

			}

			flipCount = flipCount + 1; 
			if (flipCount % 2!=0) {

				//Debug.Log("Puppet is flipped - we better invert some of the controls");
				twister = puppetBaseObject.GetComponent<QuickTwist>();
				twister.inverseAxisValue = true;

			} else {
				twister = puppetBaseObject.GetComponent<QuickTwist>();
				twister.inverseAxisValue = false;
			}
			//transform.localScale = new Vector3( -transform.localScale.x,  transform.localScale.y, transform.localScale.z);

			// notes local transform the root means there is an ofset if the heirarchy has moved away from the root. Instead - restructure the 
			// heirarchy and use local transform on the base controller...

			//Debug.Log("You're flipping the Puppet");

			//Rigidbody2D myRigidbody;
			//myRigidbody  = puppetBaseObject.GetComponent<Rigidbody2D>();
			//myRigidbody.MoveRotation(180);
			//gesture.pickedObject








	}


	public void ReparentObjects() {
		//Debug.Log("in ReparentObjects");


		// TODO it would be nice to generate this list dynamically - but it fails. Hence the manually fixed List - which works
		if (dynamicHeirarchy == true) {

			foreach (GameObject go in itemsToParent)
			{
				go.transform.parent = puppetBaseController.transform;
			
			}
		}

		//foreach (Transform go in puppetRoot.transform)
		//{
		//	if (go.gameObject.tag =="PuppetParts" || go.gameObject.tag =="PuppetBaseObject") { // tags are important! Exclude the controllers from this
		//
		//		Debug.Log("in ReparentObjects - first condition");
		//		go.transform.parent=puppetBaseController.transform;
		//	}
		//
		//
		//}

	}

	public void UnparentObjects() {
		//Debug.Log("in UnparentObjects");
		if (dynamicHeirarchy == true) {
			foreach (GameObject go in itemsToParent)
			{
					go.transform.parent=puppetRoot.transform;

			}

		}

	}

	public void FlipViaRotate(Gesture gesture) {
		
		if (gesture.pickedObject.tag == "PuppetBaseObject" ) { // select intended target - this needs to be consistent
			//float currentXScale = 

			//float currentXRotation = puppetBaseController.transform.localRotation.x;
			//float currentYRotation = puppetBaseController.transform.localRotation.y;
			//float currentZRotation = puppetBaseController.transform.localRotation.z;

			//iTween.ScaleTo(puppetBaseController,iTween.Hash("name", "flipX", "x", -currentXScale, "y", currentYScale, "z", currentZScale, "time", flipSpeed, "EaseType", "EaseInQuad"));

			iTween.RotateTo(puppetRoot, iTween.Hash(
				"rotation", new Vector3 (0f,yRot,0f), 
				"time", .5f, 
				"onstart", "toggleIsKinematic",
				"onstarttarget", gameObject,
				"oncompletetarget", gameObject, 
				"oncomplete", "toggleIsKinematic"
			)
			);
	
			flipCount = flipCount + 1; 
			if (flipCount % 2!=0) {

				Debug.Log("Puppet is rotated - we better invert some of the controls");
				twister = puppetBaseObject.GetComponent<QuickTwist>();
				twister.inverseAxisValue = true;
				yRot = 0f;

			} else {
				twister = puppetBaseObject.GetComponent<QuickTwist>();
				twister.inverseAxisValue = false;
				yRot = 180f;
			}
			//transform.localScale = new Vector3( -transform.localScale.x,  transform.localScale.y, transform.localScale.z);

			// notes local transform the root means there is an ofset if the heirarchy has moved away from the root. Instead - restructure the 
			// heirarchy and use local transform on the base controller...

			Debug.Log("You're rotating the Puppet");

			//Rigidbody2D myRigidbody;
			//myRigidbody  = puppetBaseObject.GetComponent<Rigidbody2D>();
			//myRigidbody.MoveRotation(180);
			//gesture.pickedObject

		} else {

			// pinching in space
			//Debug.Log("Picked Object:"+gesture.pickedObject.name+" on layer "+gesture.pickedObject.layer);

		}

	}

	public void setIsKinematicToFalse() {

		if (puppetBaseObject != null) {

			rigidbodies2D = puppetBaseObject.GetComponentsInChildren<Rigidbody2D>(); 

		} else {

			rigidbodies2D = GetComponentsInChildren<Rigidbody2D>(); 

		}

		if (rigidbodies2D.Length >0) {
			foreach (Rigidbody2D rb in rigidbodies2D)
			{
				// save current state to list

				if (rb.gameObject.tag !="PuppetController") { // tags are important! Exclude the controllers from this
					rigidbody2DList.Add(rb);
				}
				// set all to false

				if (rb.gameObject.tag !="PuppetController") { // tags are important! Exclude the controllers from this
					rb.isKinematic = false;
				}
				//jointInfoList.Add(new JointInfo(sj));

			}
		}

	}

	public void toggleIsKinematic() {
		Debug.Log("In toggleIsKinematic");
		rigidbodies2D = puppetRoot.GetComponentsInChildren<Rigidbody2D>();
		foreach (Rigidbody2D rb in rigidbodies2D)
		{
			// save current state to list
			// clear list first?
			//if (rb.gameObject.tag !="PuppetController") { // tags are important! Exclude the controllers from this
			//	rigidbody2DList.Add(rb);
			//	Debug.Log("In toggleIsKinematic - adding to a list...");
			//}
			// set all to false
			if (rb.gameObject.tag !="PuppetController") { // tags are important! Exclude the controllers from this
				rb.isKinematic = !rb.isKinematic;
				//Debug.Log("In toggleIsKinematic - setting the things...");
			}
			//jointInfoList.Add(new JointInfo(sj));

		}

	}

	public void toggleIsKinematicToTrue() {

		if (puppetBaseObject != null) {

			rigidbodies2D = puppetBaseObject.GetComponentsInChildren<Rigidbody2D>(); 

		} else {

			rigidbodies2D = GetComponentsInChildren<Rigidbody2D>(); 

		}

		if (rigidbodies2D.Length >0) {
			foreach (Rigidbody2D rb in rigidbodies2D)
			{
				// save current state to list

				if (rb.gameObject.tag !="PuppetController") { // tags are important! Exclude the controllers from this

					rigidbody2DList.Add(rb);
				}
				// set all to false
				if (rb.gameObject.tag !="PuppetController") { // tags are important! Exclude the controllers from this

					rb.isKinematic = true;
				}
				//jointInfoList.Add(new JointInfo(sj));

			}
		}


	}

}
