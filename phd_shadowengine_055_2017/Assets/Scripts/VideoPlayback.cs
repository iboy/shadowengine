using UnityEngine;
using System.Collections;

public class VideoPlayback : MonoBehaviour {

	void Start () {


		#if UNITY_IOS

		Handheld.PlayFullScreenMovie ("IntroSplash.mov", Color.black, FullScreenMovieControlMode.CancelOnInput);

		#endif
	}

}
