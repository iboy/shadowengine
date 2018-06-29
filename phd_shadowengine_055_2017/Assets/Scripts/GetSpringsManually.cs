using UnityEngine;
using System.Collections;

public class GetSpringsManually : MonoBehaviour {

	public SpringJoint2D controllersSpring2D_1;
	[Range(0.0f,100f)]
	public float controllersSpring2D_1_freq;
	[Range(0.0f,1f)]
	public float controllersSpring2D_1_damp;
	[Range(0.005f,100f)]
	public float controllersSpring2D_1_dist;

	public SpringJoint2D controllersSpring2D_2;
	[Range(0.0f,100f)]
	public float controllersSpring2D_2_freq;
	[Range(0.0f,1f)]
	public float controllersSpring2D_2_damp;
	[Range(0.005f,100f)]
	public float controllersSpring2D_2_dist;

	public SpringJoint2D rodControllersSpring2D;
	[Range(0.0f,100f)]
	public float rodControllersSpring2D_freq;
	[Range(0.0f,1f)]
	public float rodControllersSpring2D_damp;
	[Range(0.005f,100f)]
	public float rodControllersSpring2D_dist;

	public SpringJoint2D controllersSpring2D_3;
	[Range(0.0f,100f)]
	public float controllersSpring2D_3_freq;
	[Range(0.0f,1f)]
	public float controllersSpring2D_3_damp;
	[Range(0.005f,100f)]
	public float controllersSpring2D_3_dist;

	public SpringJoint2D controllersSpring2D_3b;
	[Range(0.0f,100f)]
	public float controllersSpring2D_3b_freq;
	[Range(0.0f,1f)]
	public float controllersSpring2D_3b_damp;
	[Range(0.005f,100f)]
	public float controllersSpring2D_3b_dist;

	public SpringJoint2D controllersSpring2D_4;
	[Range(0.0f,100f)]
	public float controllersSpring2D_4_freq;
	[Range(0.0f,1f)]
	public float controllersSpring2D_4_damp;
	[Range(0.005f,100f)]
	public float controllersSpring2D_4_dist;

	public SpringJoint2D controllersSpring2D_4b;
	[Range(0.0f,100f)]
	public float controllersSpring2D_4b_freq;
	[Range(0.0f,1f)]
	public float controllersSpring2D_4b_damp;
	[Range(0.005f,100f)]
	public float controllersSpring2D_4b_dist;


	// Use this for initialization
	void Start () {

		if (controllersSpring2D_1) {
			controllersSpring2D_1_freq 	= controllersSpring2D_1.frequency;
			controllersSpring2D_1_dist 	= controllersSpring2D_1.distance;
			controllersSpring2D_1_damp 	= controllersSpring2D_1.dampingRatio;
		}
		if (controllersSpring2D_2) {
			controllersSpring2D_2_freq 	= controllersSpring2D_2.frequency;
			controllersSpring2D_2_dist 	= controllersSpring2D_2.distance;
			controllersSpring2D_2_damp 	= controllersSpring2D_2.dampingRatio;
		}
		if (controllersSpring2D_3) {
			controllersSpring2D_3_freq 	= controllersSpring2D_3.frequency;
			controllersSpring2D_3_dist 	= controllersSpring2D_3.distance;
			controllersSpring2D_3_damp 	= controllersSpring2D_3.dampingRatio;
		}
		if (rodControllersSpring2D) {
			rodControllersSpring2D_freq = rodControllersSpring2D.frequency;
			rodControllersSpring2D_dist = rodControllersSpring2D.distance;
			rodControllersSpring2D_damp = rodControllersSpring2D.dampingRatio;
		}
		if (controllersSpring2D_3b) {
			controllersSpring2D_3b_freq = controllersSpring2D_3b.frequency;
			controllersSpring2D_3b_dist = controllersSpring2D_3b.distance;
			controllersSpring2D_3b_damp = controllersSpring2D_3b.dampingRatio;
		}
		if (controllersSpring2D_4) {
			controllersSpring2D_4_freq 	= controllersSpring2D_4.frequency;
			controllersSpring2D_4_dist 	= controllersSpring2D_4.distance;
			controllersSpring2D_4_damp 	= controllersSpring2D_4.dampingRatio;
		}
		if (controllersSpring2D_4b) {
			controllersSpring2D_4b_freq = controllersSpring2D_4b.frequency;
			controllersSpring2D_4b_dist = controllersSpring2D_4b.distance;
			controllersSpring2D_4b_damp = controllersSpring2D_4b.dampingRatio;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (controllersSpring2D_1) {
			controllersSpring2D_1.frequency		=	controllersSpring2D_1_freq; 	
			controllersSpring2D_1.distance		=	controllersSpring2D_1_dist; 	
			controllersSpring2D_1.dampingRatio	=	controllersSpring2D_1_damp; 	



		}
		if (controllersSpring2D_2) {
			controllersSpring2D_2.frequency	  	=  controllersSpring2D_2_freq;
			controllersSpring2D_2.distance	  	=  controllersSpring2D_2_dist;
			controllersSpring2D_2.dampingRatio	=  controllersSpring2D_2_damp;



		}
		if (controllersSpring2D_3) {
			controllersSpring2D_3.frequency		=  controllersSpring2D_3_freq;
			controllersSpring2D_3.distance		=  controllersSpring2D_3_dist;
			controllersSpring2D_3.dampingRatio	=  controllersSpring2D_3_damp;



		}
		if (rodControllersSpring2D) {
			rodControllersSpring2D.frequency 	= rodControllersSpring2D_freq;
			rodControllersSpring2D.distance		= rodControllersSpring2D_dist;
			rodControllersSpring2D.dampingRatio	= rodControllersSpring2D_damp;



		}
		if (controllersSpring2D_3b) {
			controllersSpring2D_3b.frequency	=	controllersSpring2D_3b_freq;
			controllersSpring2D_3b.distance		=	controllersSpring2D_3b_dist;
			controllersSpring2D_3b.dampingRatio	=	controllersSpring2D_3b_damp;



		}
		if (controllersSpring2D_4) {
			controllersSpring2D_4.frequency		=	controllersSpring2D_4_freq;
			controllersSpring2D_4.distance		=	controllersSpring2D_4_dist;
			controllersSpring2D_4.dampingRatio	=	controllersSpring2D_4_damp;



		}
		if (controllersSpring2D_4b) {
			controllersSpring2D_4b.frequency	=	controllersSpring2D_4b_freq;
			controllersSpring2D_4b.distance		=	controllersSpring2D_4b_dist;
			controllersSpring2D_4b.dampingRatio	=	controllersSpring2D_4b_damp;




		}
	}
}
