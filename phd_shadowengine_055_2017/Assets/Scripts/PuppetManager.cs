using UnityEngine;
using System.Collections;

public class PuppetManager : MonoBehaviour {
	public GameObject [] puppets;
	private string objectName;
	// Use this for initialization
	void Start () {
	
		if (puppets !=null) {
			//foreach (GameObject puppet in puppets) {
				//   GUIDataManager.guiData.wayangSNIsOn;
				//   GUIDataManager.guiData.wayangSN2IsOn;
				//   GUIDataManager.guiData.wayangDDIsOn;
				//   GUIDataManager.guiData.wayangIKIsOn;
				//   GUIDataManager.guiData.IIMBirdIsOn;
		
				//(GUIDataManager.guiData.wayangSNIsOn)
		
		
		
			if (puppets[0] != null) { setPuppetIsActive(puppets[0],GUIDataManager.guiData.wayangSNIsOn);  }
			if (puppets[1] != null) { setPuppetIsActive(puppets[1],GUIDataManager.guiData.wayangSN2IsOn);  }
			if (puppets[2] != null) { setPuppetIsActive(puppets[2],GUIDataManager.guiData.wayangDDIsOn);  }
			if (puppets[3] != null) { setPuppetIsActive(puppets[3],GUIDataManager.guiData.wayangIKIsOn);  }
			if (puppets[4] != null) { setPuppetIsActive(puppets[4],GUIDataManager.guiData.IIMBirdIsOn);  }
		
		}
	}

	//public void setPuppetIsActive2(bool state) {


	//}
	public void setPuppetIsActive(GameObject go, bool isActive) {
		
		objectName = go.name;
		
		if (objectName == "PuppetRoot_IIM_Bird_Spring_Network_MT") {
			
			go.SetActive(GUIDataManager.guiData.IIMBirdIsOn);
			GUIDataManager.guiData.IIMBirdIsOn = isActive;
		}
		
		if (objectName== "PuppetRoot_Wayang_IK-FABRIK_MT") {
		
			go.SetActive(GUIDataManager.guiData.wayangIKIsOn);
			GUIDataManager.guiData.wayangIKIsOn = isActive;
		}
		
		if (objectName == "PuppetRoot_Wayang_Spring_Network_MT") {
		
			go.SetActive(GUIDataManager.guiData.wayangSNIsOn);
			GUIDataManager.guiData.wayangSNIsOn = isActive;
		}
		
		if (objectName == "PuppetRoot_Wayang_Spring_Network_MT- Less Heirarchy") {
		
			go.SetActive(GUIDataManager.guiData.wayangSN2IsOn);
			GUIDataManager.guiData.wayangSN2IsOn = isActive;
		}
		
		if (objectName == "PuppetRoot_Wayang_Directly_Draggable_MT") {
		
			go.SetActive(GUIDataManager.guiData.wayangDDIsOn);
			GUIDataManager.guiData.wayangDDIsOn = isActive;
		}
		
		if (objectName == "PuppetRoot_Abstract_MT") {
		
			go.SetActive(GUIDataManager.guiData.abstract001IsOn);
			GUIDataManager.guiData.abstract001IsOn = isActive;
		}

	}

}
