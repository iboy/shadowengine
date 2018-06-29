using UnityEngine;
using System.Collections;



public class DrawingDebugLines : MonoBehaviour {

	// Fill/drag these in from the editor

	// Choose the Unlit/Color shader in the Material Settings
	// You can change that color, to change the color of the connecting lines
	public Material lineMat;
	public bool drawInEditor = true;
	public bool drawInGame = true;
	public GameObject[] mainPoints;
	public GameObject[] points;
	private int count;
	// Connect all of the `points` to the `mainPoint`



	void DrawConnectingLines() {
		if(mainPoints.Length > 0  && points.Length > 0) {

			foreach (GameObject mainPoint in mainPoints) {

				if (mainPoint == null) { return; }


			}

			foreach (GameObject point in points) {

				if (point == null) { return; }


			}
			// Loop through each point to connect to the mainPoint
			count = 0;
			foreach(GameObject mainPoint in mainPoints) {
				
				Vector3 mainPointPos = mainPoint.transform.position;
				Vector3 pointPos = points[count].transform.position;

				//Debug.Log(count);
				if (mainPoint.activeInHierarchy) {
				
					GL.Begin(GL.LINES);
					GL.PushMatrix();
					lineMat.SetPass(0);
					GL.Color(new Color(lineMat.color.r, lineMat.color.g, lineMat.color.b, lineMat.color.a));
					GL.Vertex3(mainPointPos.x, mainPointPos.y, mainPointPos.z);
					GL.Vertex3(pointPos.x, pointPos.y, pointPos.z);
					GL.End();
					GL.PopMatrix();
				}
				count ++;
			}
		}
	}

	// To show the lines in the game window when it is running
	void OnPostRender() {

		if (drawInGame == true) {
			DrawConnectingLines();
		}
	
	}

	// To show the lines in the editor
	void OnDrawGizmos() {
		if (drawInEditor == true) {
			DrawConnectingLines();
		}
	}

}
