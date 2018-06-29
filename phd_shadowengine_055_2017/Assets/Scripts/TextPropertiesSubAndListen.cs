using UnityEngine;
using System.Collections;

public class TextPropertiesSubAndListen : MonoBehaviour {

	private void Start()
	{
		TestProperties c = (TestProperties)this.GetComponent(typeof(TestProperties));
		c.OnVariableChange += VariableChangeHandler;
	}

	private void VariableChangeHandler(float newVal)
	{
		Debug.Log("The variable phreaking changed."+newVal);
	}
}
