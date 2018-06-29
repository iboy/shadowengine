using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class KinematicSwitcher : MonoBehaviour {

	public GameObject baseObject;
	public List<Rigidbody2D> rigidbody2DList;
	private Rigidbody2D[] rigidbodies2D;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void setIsKinematicToFalse() {

		if (baseObject != null) {
		
			rigidbodies2D = baseObject.GetComponentsInChildren<Rigidbody2D>(); 

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

		rigidbodies2D = baseObject.GetComponentsInChildren<Rigidbody2D>();
		foreach (Rigidbody2D rb in rigidbodies2D)
		{
			// save current state to list
			// clear list first?
			if (rb.gameObject.tag !="PuppetController") { // tags are important! Exclude the controllers from this
				rigidbody2DList.Add(rb);
			}
			// set all to false
			if (rb.gameObject.tag !="PuppetController") { // tags are important! Exclude the controllers from this
				rb.isKinematic = !rb.isKinematic;
			}
			//jointInfoList.Add(new JointInfo(sj));

		}

	}

	public void toggleIsKinematicToTrue() {

		if (baseObject != null) {

			rigidbodies2D = baseObject.GetComponentsInChildren<Rigidbody2D>(); 

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
