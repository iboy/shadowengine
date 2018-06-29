using UnityEngine;
using System.Collections;

public class DoubleClick : MonoBehaviour {

    float doubleClickStart = 0;
    //static bool flag = false;
  	public Transform myTarget = null;
//  	public Transform myTarget2 = null;
//  	public Transform myTarget3 = null;
//  	public Transform myTarget4 = null;
//  	public Transform myTarget5 = null;
  	
    void OnMouseUp()
    {
        if ((Time.time - doubleClickStart) < 0.3f)
        {
            this.OnDoubleClick();
            doubleClickStart = -1;
            //flag = true;
        }
        else
        {
            doubleClickStart = Time.time;
           // flag = false;
        }
    }



    void OnDoubleClick()
    {
       Debug.Log("You have double clicked the puppet");
        //GameObject myObject = GameObject.Find("Cylinder");
       	//myObject.transform.Rotate(Vector3.right * 180);
      	//flag = true;
      	
      	// Adds a force upwards in the global coordinate system
    myTarget.rigidbody.AddRelativeTorque (Vector3.up * 10);


      	//Debug.Log(flag);

      //myTarget.rigidbody.AddForce (Vector3.up * 10);
      // do the force
//        this.rigidbody.isKinematic = flag;
//        myTarget.rigidbody.isKinematic = flag;
//        myTarget2.rigidbody.isKinematic = flag;
//        myTarget3.rigidbody.isKinematic = flag;
//        myTarget4.rigidbody.isKinematic = flag;
//        myTarget5.rigidbody.isKinematic = flag;
        
        //myObject.active = false;
        //myObject.animation.Play("Rotate180");
        
       //when under physics control, dont TRANSFORM
//        myTarget.Rotate(0,0,0);
//        myTarget2.Rotate(180,0,0); 
//        myTarget3.Rotate(180,0,0); 
//        myTarget4.Rotate(180,0,0); 
//        myTarget5.Rotate(0,0,0); 
        
       
    }


}