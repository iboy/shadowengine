using UnityEngine;
using System.Collections;

public class SetTilingXandY : MonoBehaviour {
	public Renderer myRenderer;

	public void setTilingX (float value) {


		float myY = myRenderer.material.mainTextureScale.y;

		myRenderer.material.mainTextureScale = new Vector2 (value, myY);



	}


	public void setTilingY (float value) {


		float myX = myRenderer.material.mainTextureScale.x;


		myRenderer.material.mainTextureScale = new Vector2 (myX, value);


	}
}
