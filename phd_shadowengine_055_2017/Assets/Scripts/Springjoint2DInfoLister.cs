using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Springjoint2DInfoLister : MonoBehaviour {

	public GameObject listMe;
	public List<JointInfo> jointInfoList;
	void Start()
	{
		jointInfoList = new List<JointInfo>();
		if (listMe) {
			Traverse(listMe);
		} 
		else {
			Traverse(this.gameObject);
		}
		
	}
	public void Traverse(GameObject obj)
	{
		SpringJoint2D[] joints = obj.GetComponentsInChildren<SpringJoint2D>();
		foreach (SpringJoint2D sj in joints)
		{
			jointInfoList.Add(new JointInfo(sj));

		}
	}
	void Update() {

		//jointInfoList.Frequency() ;
		//if (listMe) {Traverse(listMe);}
		//foreach (JointInfo ji in jointInfoList)
		//{
		//	ji.Refresh();
		//}

	}

	public void UpdateValues() {

		foreach (JointInfo ji in jointInfoList) {

			ji.Refresh();

		}

	}


}
