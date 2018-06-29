using UnityEngine;
using System.Collections;

public class TestProperties : MonoBehaviour {



	private float m_MyVar = 0f;
	public float MyVar
	{
		get {return m_MyVar;}
		set {
			if (m_MyVar == value) return;
			m_MyVar = value;
			if (OnVariableChange != null)
				OnVariableChange(m_MyVar);
			Debug.Log("We're setting the variable");
		}
	}

	public delegate void OnVariableChangeDelegate(float newVal);
	public event OnVariableChangeDelegate OnVariableChange;


}
