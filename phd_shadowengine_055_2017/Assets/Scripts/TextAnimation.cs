using UnityEngine;
using System.Collections;


public class TextAnimation : MonoBehaviour {

	public CanvasGroup title;
	public CanvasGroup text;
	public CanvasGroup button;

	public RectTransform rectTitle;
	public RectTransform rectButton;

	public Vector2 titleDestPos;
	public Vector2 buttonDestPos;

	public float fadeInDurationTitle;
	public float fadeInDurationText;
	public float fadeInDurationButton;
	public float fadeInDelayTitle;
	public float fadeInDelayText;
	public float fadeInDelayButton;

	public float fadeOutDurationTitle;
	public float fadeOutDurationText;
	public float fadeOutDurationButton;
	public float fadeOutDelayTitle;
	public float fadeOutDelayText;
	public float fadeOutDelayButton;

	public float moveDurationTitle;
	public float moveDelayTitle;
	public float moveDurationButton;
	public float moveDelayButton;

	public string nextScene = "ShadowEngine-2-Loading";

	// Use this for initialization
	void Start () {

		DoBeginningAnimation();


	}

	public void DoBeginningAnimation() {

		FadeElementIn(title, fadeInDurationTitle, fadeInDelayTitle);
		FadeElementIn(text, fadeInDurationText, fadeInDelayText);
		FadeElementIn(button, fadeInDurationButton, fadeInDelayButton);
	}

	public void DoEndAnimation() {

		FadeElementOut(title, fadeOutDurationTitle, fadeOutDelayTitle);
		FadeElementOut(text, fadeOutDurationText, fadeOutDelayText);
		FadeElementOut(button, fadeOutDurationButton, fadeOutDelayButton);
		MoveElementTo(rectTitle, titleDestPos, moveDurationTitle, moveDelayTitle);
		//MoveElementTo(rectButton, buttonDestPos, moveDurationButton, moveDelayButton);

	}

	void FadeElementOut (CanvasGroup canvasGroup, float duration, float delay) {

		LeanTween.alphaCanvas(canvasGroup, 0f, duration).setEase(LeanTweenType.easeInCirc).setDelay(delay);

	}

	void FadeElementIn (CanvasGroup canvasGroup, float duration, float delay) {

		LeanTween.alphaCanvas(canvasGroup, 1f, duration).setEase(LeanTweenType.easeInCirc).setDelay(delay);

	}

	void MoveElementTo (RectTransform rect, Vector2 pos, float duration, float delay) {

		LeanTween.move(rect, pos, duration).setEase( LeanTweenType.easeOutElastic).setDelay(delay).setOnComplete(CallStartShadowEngine);

	}

	void CallStartShadowEngine() {

		#if (UNITY_5_2 || UNITY_5_1 || UNITY_5_0)
		Application.LoadLevel("ShadowEngine-2-Loading");
		#else // UNITY_5_3 or above
		UnityEngine.SceneManagement.SceneManager.LoadScene(nextScene);
		#endif

	}

}
