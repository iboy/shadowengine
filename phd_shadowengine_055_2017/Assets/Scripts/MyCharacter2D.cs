// MyCharacter.cs - A simple example showing how to get input from Rewired.Player

using UnityEngine;
using System.Collections;
using Rewired;
using Prime31;

//[RequireComponent(typeof(CharacterController2D))]
public class MyCharacter2D : MonoBehaviour {

	public int playerId = 0; // The Rewired player id of this character

	public float moveSpeed = 3.0f;
	//public float bulletSpeed = 15.0f;
	//public GameObject bulletPrefab;

	private Player player; // The Rewired Player
	private CharacterController2D cc;
	private Vector3 moveVector;
	//private bool fire;
	//private float buttonValue;

	void Awake() {
		// Get the Rewired Player object for this player and keep it for the duration of the character's lifetime
		player = ReInput.players.GetPlayer(playerId);

		// Get the character controller
		cc = GetComponent<CharacterController2D>();


	}

	void Update () {
		GetInput();
		ProcessInput();
	}

	private void GetInput() {
		// Get the input from the Rewired Player. All controllers that the Player owns will contribute, so it doesn't matter
		// whether the input is coming from a joystick, the keyboard, mouse, or a custom controller.

		moveVector.x = player.GetAxis("Move Horizontal"); // get input by name or action id
		moveVector.y = player.GetAxis("Move Vertical");
		//fire = player.GetButtonDown("Fire");
		//buttonValue = player.GetAxis("AnalogueButtonL2");
	}

	private void ProcessInput() {
		// Process movement
		if(moveVector.x != 0.0f || moveVector.y != 0.0f) {
			cc.move(moveVector * moveSpeed * Time.deltaTime);
		}

		// Process fire
		//if(fire) {
		//	GameObject bullet = (GameObject)Instantiate(bulletPrefab, transform.position , transform.rotation);
		//	bullet.GetComponent<Rigidbody>().AddForce(transform.right * bulletSpeed, ForceMode.VelocityChange);
		//}
		//
		//if (buttonValue != 0) {
		//	// yeah! This works and brings in the analogue value - not just 0 or 1 like Unity does...
		//	Debug.Log("Lower Button 2 Pressed: "+ buttonValue);
		//}

	}
}