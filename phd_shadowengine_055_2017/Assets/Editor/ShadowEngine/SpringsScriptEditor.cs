using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(GetSprings)),CanEditMultipleObjects]

public class SpringsScriptEditor : Editor {

	//SerializedProperty puppets;

	void OnEnable()
	{
		//puppets = serializedObject.FindProperty("puppets");
	}

//	public override void OnInspectorGUI() {

	//	serializedObject.Update();
	//	var t = target as GetSprings;
	//	SerializedProperty tps = serializedObject.FindProperty ("puppets");
	//	EditorGUI.BeginChangeCheck();
	//	EditorGUILayout.PropertyField(tps, true);
	//	if(EditorGUI.EndChangeCheck())
	//	serializedObject.ApplyModifiedProperties();
	//	
	//
	//	//NullReferenceException: Object reference not set to an instance of an object
	//	// error here when array doesnt exist?
	//
	//	foreach (GameObject puppet in t.puppets) {
	//					
	//		Traverse(puppet);
	//		//Debug.Log(puppet.name);		
	//	}

//	}

	void Traverse(GameObject obj) {

		if (obj != null) {
			foreach (Transform child in obj.transform) {

				Component[] springJoints;
				springJoints = child.gameObject.GetComponents( typeof(SpringJoint2D) );
				//Debug.Log("Parent Object: "+obj.name);
				foreach (SpringJoint2D spring in springJoints) {
					//EditorGUILayout.LabelField(obj.name, );
					if (spring) {
						EditorGUI.BeginChangeCheck();
						EditorGUILayout.LabelField(spring.gameObject.name,EditorStyles.boldLabel);
						EditorGUILayout.FloatField(spring.gameObject.name+ " Frequency", spring.frequency);
						//EditorGUILayout.Slider(spring.frequency,0.0f,200f);
						EditorGUILayout.FloatField(spring.gameObject.name+ " Damping", spring.dampingRatio);
						//EditorGUILayout.Slider(spring.dampingRatio,0.0f,200f);
						EditorGUILayout.FloatField(spring.gameObject.name+ " Distance", spring.distance);
						//EditorGUILayout.Slider(spring.distance,0.0f,10f);
						if(EditorGUI.EndChangeCheck()) {
							serializedObject.ApplyModifiedProperties();
						}
					
						//Debug.Log("Parent: "+spring.gameObject.name+"\r\n"+
						//	"Connected Body: "+spring.connectedBody+"\r\n"+
						//	"Distance: "+spring.distance+"\r\n"+
						//	"Damping: "+spring.dampingRatio+"\r\n"+
						//	"Frequency: "+spring.frequency+"\r\n");

					}
		
				}
		
				Traverse(child.gameObject);
		
			}
		
		}
	}

}
