using UnityEngine;
using System.Collections;

[System.Serializable]

public class JointPropertyEditor : MonoBehaviour {


	public GameObject[] puppetsControllers;
	public Rigidbody2D[] rigidbodiesOnControllers;
	public float frequency;
	// Use this for initialization

	public void  myGameObjectName() {

	//	if ( puppetsControllers[0] ) {
			//string name = puppetsControllers[0].name;
			//return name; 
	//	}
			

	}
	void FixedUpdate () {


		foreach (GameObject puppet in puppetsControllers) {

			Traverse(puppet);

		//	Component[] springJoints;
		//	springJoints = GetComponentsInChildren( typeof(SpringJoint2D) );
		//
		//Debug.Log("Puppets: No. "+puppets.Length); 
		//
		//	if( springJoints != null )
		//	{
		//		foreach( SpringJoint2D joint in springJoints ) {
		//			Debug.Log("All Spring Joints: Connected Anchor. "+joint.connectedAnchor); 
		//			Debug.Log("All Spring Joints: Connected Anchor. "+joint.connectedAnchor);
		//		
		//			//joint.useSpring = false;
		//
		//		}
		//	}
		//
		//	Debug.Log("All Spring Joints: No. "+springJoints.Length); 

		

		}

	}

	public void Traverse(GameObject obj) {


		foreach (Transform child in obj.transform) {


			//
			Component[] springJoints;
			springJoints = child.gameObject.GetComponents( typeof(SpringJoint2D) );
			//Debug.Log("Parent Object: "+obj.name);
			foreach (SpringJoint2D spring in springJoints) {

				if (spring) {

					Debug.Log("Parent: "+spring.gameObject.name+"\r\n"+
					"Connected Body: "+spring.connectedBody+"\r\n"+
					"Distance: "+spring.distance+"\r\n"+
					"Damping: "+spring.dampingRatio+"\r\n"+
					"Frequency: "+spring.frequency+"\r\n");


					// get to set things
					//spring.frequency = frequency;
				}

			}

			Traverse(child.gameObject);

		}

	}

	// Update is called once per frame
	//void Update () {
	//
	//}



}
