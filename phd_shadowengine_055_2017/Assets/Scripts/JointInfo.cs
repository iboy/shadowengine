using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class JointInfo
{
	public string name;
	public SpringJoint2D joint;
	[Range(0.0f,100f)]
	public float frequency;
	[Range(0.0f,1f)]
	public float dampingRatio;
	[Range(0.005f,100f)]
	public float distance;

	public JointInfo(SpringJoint2D joint)
	{
		this.joint = joint;
		this.name = joint.transform.gameObject.name;

		this.frequency = joint.frequency;
		this.dampingRatio = joint.dampingRatio;
		this.distance = joint.distance;
	}

	//helper functions since you mentioned updating these on the fly
	public void Frequency(float val)
	{
		this.frequency = val;
		Refresh();
	}
	public void DampingRatio(float val)
	{
		this.dampingRatio = val;
		Refresh();
	}
	public void Distance(float val)
	{
		this.distance = val;
		Refresh();
	}
	//

	public void Refresh()
	{
		this.joint.frequency = this.frequency;
		this.joint.dampingRatio = this.dampingRatio;
		this.joint.distance = this.distance;
	}




}

