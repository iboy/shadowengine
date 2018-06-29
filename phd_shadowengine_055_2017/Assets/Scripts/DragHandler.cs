using UnityEngine;
using System.Collections;
using HedgehogTeam.EasyTouch;

public class DragHandler : MonoBehaviour {


	public float dampingRatio = 1.0f;
	public float frequency = 2.5f;
	public float drag = 10.0f;
	public float angularDrag = 5.0f;
	// change these to private to check the 'reset' behaviour
	private float oldDrag = 0f;
	private float oldAngularDrag = 0.05f; 
	private float oldMass = 1f; 
	private SpringJoint2D springJoint;
	private GameObject obj;
	public bool showTouch= true;
	public Sprite touchIndicatorSprite;
	public Color touchIndicatorColor;

	private SpriteRenderer spriteRenderer;

	private Vector2 touchWorldPosVec2;
	private Vector3 touchWorldPosition;
	private bool update = false;

	public void dragStarted(Gesture gesture) {

		if (!springJoint) {
			//Debug.Log("DragStarted clause");

			// create dragging object and sprite renderer
			obj = new GameObject("Rigidbody2D dragger");

			if (showTouch == true) {
			obj.AddComponent<SpriteRenderer>();
			spriteRenderer = obj.GetComponent<SpriteRenderer>();
			spriteRenderer.color = touchIndicatorColor;
			spriteRenderer.sortingLayerName = "Controllers";
			spriteRenderer.sprite = touchIndicatorSprite;
			}

			Rigidbody2D body = obj.AddComponent<Rigidbody2D>() as Rigidbody2D;
			this.springJoint = obj.AddComponent<SpringJoint2D>() as SpringJoint2D;
			body.isKinematic = true;
			Rigidbody2D myRigidBody = gesture.pickedObject.GetComponent<Rigidbody2D>();
			oldDrag = myRigidBody.drag;
			oldMass = myRigidBody.mass;
			oldAngularDrag = myRigidBody.angularDrag;

			// Get/Set position

			touchWorldPosition = gesture.GetTouchToWorldPoint(gesture.position);
			touchWorldPosVec2 =  new Vector2(touchWorldPosition.x, touchWorldPosition.y);

			//------------------------------------
			// SpringJoint2D property setting.
			//------------------------------------


			springJoint.autoConfigureDistance = false;
			springJoint.autoConfigureConnectedAnchor = false;
			springJoint.distance = 0f;
			// Spring endpoint, set to the position of the hit object:
			springJoint.anchor =  touchWorldPosVec2;
			// Initially, both spring endpoints are the same point:
			springJoint.connectedAnchor = touchWorldPosVec2;
			springJoint.dampingRatio = this.dampingRatio;
			springJoint.frequency = this.frequency;
			// Don't want our invisible "Rigidbody2D dragger" to collide!
			springJoint.enableCollision = false;


			springJoint.connectedBody = gesture.pickedObject.GetComponent<Rigidbody2D>();

			//oldDrag = this.springJoint.connectedBody.drag;
			//oldAngularDrag = this.springJoint.connectedBody.angularDrag;

			//Debug.Log("OldDrag: "+oldDrag + " oldAngularDrag: " + oldAngularDrag);
			springJoint.connectedBody.drag = drag;
			springJoint.connectedBody.angularDrag = angularDrag;
		}
			
	}

	public void dragging(Gesture gesture) {

		// Reporting positions, deltaPositions etc.
		//Debug.Log("gesture.deltaPosition (xy): "+gesture.deltaPosition.x +" "+gesture.deltaPosition.y);
		//Debug.Log("gesture.pickedObject: "+gesture.pickedObject.name);
		//Debug.Log("Dragging Started");

		//Vector3 touchWorldPosition = gesture.GetTouchToWorldPoint(gesture.deltaPosition);
		//Vector3 touchWorldPosition = gesture.GetTouchToWorldPoint(gesture.position);
		//Vector2 touchWorldPosVec2 =  new Vector2(touchWorldPosition.x, touchWorldPosition.y);

		//Vector3 touchPosition = gesture.position;
		//Vector3 hitObjectPos = gesture.pickedObject.transform.localPosition;
		//Vector2 touchDeltaPosition = gesture.deltaPosition;
		//Vector2 hitObjectPosVec2 =  new Vector2(hitObjectPos.x, hitObjectPos.y);


		touchWorldPosition = gesture.GetTouchToWorldPoint(gesture.position);
		touchWorldPosVec2 =  new Vector2(touchWorldPosition.x, touchWorldPosition.y);
		// this moves the thing
		update = true;
		springJoint.transform.position =  touchWorldPosVec2;

	}

	void FixUpdate() {
		if (update == true) {
		
			springJoint.transform.position =  touchWorldPosVec2;

		} 
		//else { 
		//	if (obj != null) {
		//		Destroy (obj);
		//	} 
		//}


	}

	public void dragEnded(Gesture gesture) {
		//Debug.Log("Drag Ended. OldDrags = "+oldDrag+" "+oldAngularDrag);

		//if (springJoint.connectedBody) {
		springJoint.connectedBody.drag = oldDrag;
		springJoint.connectedBody.angularDrag = oldAngularDrag;
		springJoint.connectedBody.mass = oldMass;
			// springJoint.connectedBody = null;
		//}
		Destroy (obj);
		update = false;
	}






}

