using UnityEngine;
using System.Collections;

public class HiResScreenShots : MonoBehaviour {
	public string captureKey = "k";
	public int resWidth = 2048; // 1920 * 1080; 2048 * 1152  or 3840 * 2160 (4K UHDTV) = 16:9
	public int resHeight = 1152;


	private bool takeHiResShot = false;
	
	public static string ScreenShotName(int width, int height) {
		return string.Format("{0}/screenshots/screen_{1}x{2}_{3}.png", 
		                     Application.dataPath, 
		                     width, height, 
		                     System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
	}
	
	public void TakeHiResShot() {
		takeHiResShot = true;
	}
	
	void LateUpdate() {
		takeHiResShot |= Input.GetKeyDown(captureKey);
		if (takeHiResShot) {
			RenderTexture rt = new RenderTexture(resWidth, resHeight, 24);
			GetComponent<Camera>().targetTexture = rt;
			Texture2D screenShot = new Texture2D(resWidth, resHeight, TextureFormat.RGB24, false);
			GetComponent<Camera>().Render();
			RenderTexture.active = rt;
			screenShot.ReadPixels(new Rect(0, 0, resWidth, resHeight), 0, 0);
			GetComponent<Camera>().targetTexture = null;
			RenderTexture.active = null; // JC: added to avoid errors
			Destroy(rt);
			byte[] bytes = screenShot.EncodeToPNG();
			string filename = ScreenShotName(resWidth, resHeight);
			System.IO.File.WriteAllBytes(filename, bytes);
			Debug.Log(string.Format("Took screenshot to: {0}", filename));
			takeHiResShot = false;
		}
	}
}