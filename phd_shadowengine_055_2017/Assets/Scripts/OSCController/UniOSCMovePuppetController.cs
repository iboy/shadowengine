/*
* UniOSC
* Copyright © 2014-2015 Stefan Schlupek
* All rights reserved
* info@monoflow.org
*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using OSCsharp.Data;
using HedgehogTeam.EasyTouch;


namespace UniOSC{

	/// <summary>
	/// Moves a GameObject in normalized coordinates (ScreenToWorldPoint)
	/// </summary>
	[AddComponentMenu("UniOSC/MovePuppetController")]
	public class UniOSCMovePuppetController :  UniOSCEventTarget {

		[HideInInspector]
		public Transform transformToMove;
		public GameObject puppetBaseObject;
		public bool isDraggingEnabled = true;
		public bool isTwistingEnabled = false;
		public bool isPinchingEnabled = false;
		public bool isDoubleTappingEnabled = false;
		public bool doubleTapToFlip = false;
		private Vector3 storePosition;		// stores the postiion of the attached gameObject
		private Vector3 storeRotation; 		// stores the rotation of the attached gameObject
		private Vector3 storeScale; 		// stores the rotation of the attached gameObject
		private float rotation;
		private float scale;
		//private bool isPinchingFlag;
		private bool isKinematicOriginalState = true; // Default for 'Controllers'
		private Rigidbody2D rb2D;
		void Awake(){

		}


		public override void OnEnable()
		{
			base.OnEnable();

			if(transformToMove == null){
				Transform hostTransform = GetComponent<Transform>();
				if(hostTransform != null) { transformToMove = hostTransform; }


			}

			//Blink myBirdBlink = (Blink)puppetBaseObject.GetComponent(typeof(Blink));
		}

		// data at index [0] int isDragging 
		// data at index [1] float x
		// data at index [2] float y 
		// data at index [3] int isPinching 
		// data at index [4] float z scale
		// data at index [5] int isTwisting 
		// data at index [6] float z rotation (euler)
		// data at index [7] int IsDoubleTapped	

		//void FixedUpdate() {
		//	if (isPinchingFlag) {
		//		puppetBaseObject.transform.localScale = new Vector3(storeScale.x*scale,storeScale.y*scale,storeScale.z*scale);
		//
		//	}
		//
		//}

		public override void OnOSCMessageReceived(UniOSCEventArgs args)
		{
			OscMessage msg = (OscMessage)args.Packet;

			if(msg.Data.Count <1)return;


			// isdragging
			if ((int)msg.Data[0] == 1) { // isdragging
				
				if (isDraggingEnabled == true) {
					
					if(transformToMove == null) return;
					
					//Debug.Log("isDragging = true;");
					float x = transformToMove.transform.position.x;
					float y =  transformToMove.transform.position.y;
					float z = transformToMove.transform.position.z;
					
					//Debug.Log("isDragging: "+(int)msg.Data[0]);
					//Debug.Log("X: "+(float)msg.Data[1]);
					//Debug.Log("Y: "+(float)msg.Data[2]);
					//Debug.Log("isPinching: "+(int)msg.Data[3]);
					//Debug.Log("Z Scale: "+(float)msg.Data[4]);
					//Debug.Log("isTwisting: "+(int)msg.Data[5]);
					//Debug.Log("z rotation: "+(float)msg.Data[6]);
					//Debug.Log("IsDoubleTapped: "+(int)msg.Data[7]);
					
					x = (float)msg.Data[1];
					y = (float)msg.Data[2];
					z = transformToMove.transform.position.z;

					// this is designed to detect if the dragged object is a controller (iskinematic = true )
					// if the dragged object is physics based - disable then restore this.
					rb2D = (Rigidbody2D)transformToMove.gameObject.GetComponent(typeof(Rigidbody2D));
					if (rb2D != null) {

						if ( rb2D.isKinematic == false) { // we're just checking if the dragged object is a controller or part of the physics system
							isKinematicOriginalState =  false;
							rb2D.isKinematic = true;
						}

					}
					storePosition = new Vector3(x,y,z);
					transformToMove.transform.position = storePosition; 



				}
			} else { // not dragging
				if (rb2D != null) { // this will only be set after a drag.

					if ( isKinematicOriginalState == false) {
						isKinematicOriginalState =  true;
						rb2D.isKinematic = false;
					}

				}


			}

			// isPinching
			int isPinching = (int)msg.Data[3];
			if (isPinchingEnabled == true) {
				if (isPinching == 1) {
					//isPinchingFlag = true;
					scale = (float)msg.Data[4];
					//Debug.Log("isPinching = true; Scale = "+scale);
					storeScale = puppetBaseObject.transform.localScale;
					puppetBaseObject.transform.localScale = new Vector3(scale,scale,scale);
				} else { //isPinchingFlag = false;
				}
			}
			// isTwisting
			int isTwisting = (int)msg.Data[5];
			if (isTwistingEnabled == true) {
				if (isTwisting == 1) {
					
					rotation = (float)msg.Data[6];
					//Debug.Log("isTwisting = true;"+rotation);
					storeRotation = transformToMove.eulerAngles;
					transformToMove.eulerAngles = new Vector3(storeRotation.x, storeRotation.y, rotation); 
				}
			}
			// isDoubleTapped
			int isDoubleTapped = (int)msg.Data[7];
			if (isDoubleTappingEnabled == true) {
				if (isDoubleTapped == 1) {
					//Debug.Log("isDoubleTapped = true;");
					// call a function
					//QuickPinch myPinch = (QuickPinch)transformToMove.gameObject.GetComponent(typeof(QuickPinch));
					//Debug.Log(myPinch.quickActionName.ToString();)

					// hard code the feature you wish to enact on double tap
					if (puppetBaseObject.name == "PuppetRoot_IIM_Bird_Spring_Network_MT" || puppetBaseObject.name == "PuppetRoot_IIM_Bird_Spring_Network_MT_small") {
						Blink myBlink = (Blink)puppetBaseObject.GetComponent(typeof(Blink));
						myBlink.SFX_ShortBlink();
					}

					if (doubleTapToFlip == true) {

						FlipMe2D flipMe = (FlipMe2D)puppetBaseObject.GetComponent(typeof(FlipMe2D));
						flipMe.FlipViaScaleForRemoteControl(puppetBaseObject);
						//Debug.Log("isDoubleTapped = true; In doubleTapToFlipClause");


					}
				}
			}

		}
	}
}

