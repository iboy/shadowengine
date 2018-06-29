using UnityEngine;
using System.Collections;

public class InitialisePuppet : MonoBehaviour {

	public GameObject thisPuppet;
	private bool isActiveAtStart;
	//private string shortName;
	// TODO this could and should be re-written. Otherwise I need to manage this list manually.
	// a list should be formed at runtime.
	// Each puppet should be a class with a number of properties / methods

	// Use this for initialization


	void Start () {

		//   GUIDataManager.guiData.wayangSNIsOn
		//   GUIDataManager.guiData.wayangSN2IsOn
		//   GUIDataManager.guiData.wayangDDIsOn
		//   GUIDataManager.guiData.wayangIKIsOn
		//   GUIDataManager.guiData.IIMBirdIsOn
		//	 GUIDataManager.guiData.abstract001IsOn
		//Debug.Log("Start: "+this.gameObject.name);
		if (this.gameObject.name == "PuppetRoot_Abstract_MT") 								{	isActiveAtStart = GUIDataManager.guiData.abstract001IsOn; }
		if (this.gameObject.name == "PuppetRoot_Wayang_Spring_Network_MT") 					{	isActiveAtStart = GUIDataManager.guiData.wayangSNIsOn;	}
		if (this.gameObject.name == "PuppetRoot_Wayang_Spring_Network_MT- Less Heirarchy")  {	isActiveAtStart = GUIDataManager.guiData.wayangSN2IsOn;	}
		if (this.gameObject.name == "PuppetRoot_Wayang_Directly_Draggable_MT") 				{	isActiveAtStart = GUIDataManager.guiData.wayangDDIsOn;	}
		if (this.gameObject.name == "PuppetRoot_Wayang_IK-FABRIK_MT") 						{	isActiveAtStart = GUIDataManager.guiData.wayangIKIsOn;	}
		if (this.gameObject.name == "PuppetRoot_IIM_Bird_Spring_Network_MT") 				{	isActiveAtStart = GUIDataManager.guiData.IIMBirdIsOn;	}
		if (this.gameObject.name == "Reiniger_Hand_Spring_Network_MT") 						{	isActiveAtStart = GUIDataManager.guiData.reinigerHandSNIsOn;}
		if (this.gameObject.name == "Reiniger_Hand_Spring_Network_MT") 						{	isActiveAtStart = GUIDataManager.guiData.reinigerHandIKIsOn;} // add IK version
		if (this.gameObject.name == "PuppetRoot_IIM_Bird_Spring_Network_MT_small") 			{	isActiveAtStart = GUIDataManager.guiData.IIMBirdSmallIsOn;}

		if (this.gameObject.name == "FABRIKTest001") 			{	isActiveAtStart = GUIDataManager.guiData.FABRIKTest001IsOn;}
		if (this.gameObject.name == "FABRIKTest002") 			{	isActiveAtStart = GUIDataManager.guiData.FABRIKTest002IsOn;}
		if (this.gameObject.name == "FABRIKBird") 				{	isActiveAtStart = GUIDataManager.guiData.FABRIKBirdIsOn;}
		if (this.gameObject.name == "FABRIKBird_002") 			{	isActiveAtStart = GUIDataManager.guiData.FABRIKBird_002IsOn;}

		SetIsActiveAndEnabled(isActiveAtStart);

		//thisPuppet.name

		//this.isActiveAndEnabledOnLaunch

	}
	
	public void SetIsActiveAndEnabled(bool state) {

		gameObject.SetActive(state);
		//Debug.Log("SetIsActiveAndEnabled: Initialising Puppet:"+gameObject.name+" is "+state);
		if (this.gameObject.name == "PuppetRoot_Abstract_MT") 								{	GUIDataManager.guiData.abstract001IsOn = state; 	}
		if (this.gameObject.name == "PuppetRoot_Wayang_Spring_Network_MT") 					{	GUIDataManager.guiData.wayangSNIsOn = state;	}
		if (this.gameObject.name == "PuppetRoot_Wayang_Spring_Network_MT- Less Heirarchy")  {	GUIDataManager.guiData.wayangSN2IsOn = state;	}
		if (this.gameObject.name == "PuppetRoot_Wayang_Directly_Draggable_MT") 				{	GUIDataManager.guiData.wayangDDIsOn = state;	}
		if (this.gameObject.name == "PuppetRoot_Wayang_IK-FABRIK_MT") 						{	GUIDataManager.guiData.wayangIKIsOn = state;	}
		if (this.gameObject.name == "PuppetRoot_IIM_Bird_Spring_Network_MT") 				{	GUIDataManager.guiData.IIMBirdIsOn = state;	}
		if (this.gameObject.name == "Reiniger_Hand_Spring_Network_MT") 						{	GUIDataManager.guiData.reinigerHandSNIsOn = state;}
		if (this.gameObject.name == "PuppetRoot_IIM_Bird_Spring_Network_MT_small") 			{	GUIDataManager.guiData.IIMBirdSmallIsOn = state;}

		if (this.gameObject.name == "FABRIKTest001") 			{	GUIDataManager.guiData.FABRIKTest001IsOn = state;}
		if (this.gameObject.name == "FABRIKTest002") 			{	GUIDataManager.guiData.FABRIKTest002IsOn = state;}
		if (this.gameObject.name == "FABRIKBird") 				{	GUIDataManager.guiData.FABRIKBirdIsOn = state;}
		if (this.gameObject.name == "FABRIKBird_002") 			{	GUIDataManager.guiData.FABRIKBird_002IsOn = state;}



		//PuppetRoot_IIM_Bird_Spring_Network_MT_small

		//Debug.Log("guidata state for reinigerHandSNIsOn: "+GUIDataManager.guiData.reinigerHandSNIsOn);

	}

}
