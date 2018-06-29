using UnityEngine;
using System.Collections;
using UnityEditor;


[CustomEditor(typeof(Springjoint2DInfoLister)),CanEditMultipleObjects]
public class JointInfoListerEditor : Editor {

	public override void OnInspectorGUI() {

	
		Springjoint2DInfoLister jointController = (Springjoint2DInfoLister)target;


		if (DrawDefaultInspector()) {

			jointController.UpdateValues();



		}

		if (GUILayout.Button("Update")) {

			jointController.UpdateValues();

			}


	}
}
