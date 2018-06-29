using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class GetSprings : MonoBehaviour {

	public GameObject[] puppets;

	public List<SpringJoint2D> springs =  new List<SpringJoint2D>();
	public List<float> springFrequencies2 = new List<float>();
	public List<ValueWrapper<float>> springFrequencies =  new List<ValueWrapper<float>>();

	public GameObject[] myObject {


		get {return puppets;}

	}


	// testing the value wrapper thing...
	public ValueWrapper<float> TestFloat = new ValueWrapper<float>(1.0f);
	public ValueWrapper<float> SpringFrequencyWrapper = new ValueWrapper<float>(1.0f);
	public List<ValueWrapper<float>> TestList;
	//---------

	void Start() {

		if (puppets[0] != null) {

			//Debug.Log(puppets[0].name);

			TestList = new List<ValueWrapper<float>>();
			TestList.Add(TestFloat);

			for (int i = 0; i < TestList.Count; i++)
			{
				TestList[i].Value++;
			//	Debug.Log("Class field: " + TestFloat.Value + ", list element: " + TestList[i].Value);
				// prints Class field: 2, list element: 2
			}

		}

		foreach (GameObject puppet in puppets) {

			Traverse(puppet);
			//Debug.Log(puppet.name);		
		}

	}

	void Update() {



	}

	void Traverse(GameObject obj) {

		if (obj != null) {
			foreach (Transform child in obj.transform) {

				Component[] springJoints;
				springJoints = child.gameObject.GetComponents( typeof(SpringJoint2D) );
				//Debug.Log("Parent Object: "+obj.name);
				int count = 0;
				foreach (SpringJoint2D spring in springJoints) {
					//EditorGUILayout.LabelField(obj.name, );
					if (spring) {
						
						Debug.Log("Parent: "+spring.gameObject.name+"\r\n"+
							"Connected Body: "+spring.connectedBody+"\r\n"+
							"Distance: "+spring.distance+"\r\n"+
							"Damping: "+spring.dampingRatio+"\r\n"+
							"Frequency: "+spring.frequency+"\r\n");

						// Try to set some Public Vars to change these values...
						springs.Add (spring);
						springFrequencies2.Add(spring.frequency);
						SpringFrequencyWrapper = new ValueWrapper<float>(spring.frequency);
					//SpringFrequencyWrapper = spring.frequency;
						springFrequencies.Add( SpringFrequencyWrapper );
						Debug.Log("Class field: " + SpringFrequencyWrapper.Value + ", list element: " + springFrequencies[count].Value);
						count ++;

					}

				}

				Traverse(child.gameObject);

			}

		}
	}

}
	
public class ValueWrapper<T>
{
	public ValueWrapper(T value)
	{
		Value = value;
	}

	public T Value;
}