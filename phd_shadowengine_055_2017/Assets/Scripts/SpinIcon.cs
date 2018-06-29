using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

public class SpinIcon : MonoBehaviour {
	public RectTransform rectTransform;
	public RectTransform logoRectTransform;
	public RectTransform textcolorRectTransform;
	public CanvasGroup canvasGroupLogoGroupToFade;
	public CanvasGroup canvasGroupSEngineToFade;
	public RectTransform shadowEngine005;
	public Color textChangeColor;


	public float spinDuration = 4f;
	public float moveInDuration = 1f;
	public float colorChangeDuration = 2f;
	public float fadeDuration = 5f;
	public float spinDelay = 4f;
	public float moveInDelay = 2f;
	public float colorChangeDelay = 4f;
	public float fadeDelay = 5f;
	public float blurShakeDuration = 2f;


	public float SE_fadeInTime;
	public float SE_fadeOutTime;
	public float SE_fadeInDelay;
	public float SE_fadeOutDelay;
	public float SE_BloomUpDuration;
	public float SE_BloomDownDuration;
	public float SE_BloomUpDelay;
	public float SE_BloomDownDelay;



	// Use this for initialization
	void Start () {


		ShadowEngineTextAnimation();

		SpinMe(spinDelay);
		MoveIn(moveInDelay);
		//ShakeBlur(blurShakeDuration);
		ChangeTextColor(textChangeColor,colorChangeDelay);
		FadeElement(fadeDelay);
	}


	void ShadowEngineTextAnimation() {


		//FadeIn
		LeanTween.alphaCanvas(canvasGroupSEngineToFade, 1f, SE_fadeInTime).setEase(LeanTweenType.easeOutSine).setDelay(SE_fadeInDelay);

		// Bloom and Blur
		LeanTween.value(gameObject,0f,50f, SE_BloomUpDuration).setOnUpdate( (float val)=> { setBloomIntensity(val); }).setEase( LeanTweenType.easeOutSine).setDelay(SE_BloomUpDelay);


		//FadeOut
		LeanTween.alphaCanvas(canvasGroupSEngineToFade, 0f, SE_fadeOutTime).setEase(LeanTweenType.easeInSine).setDelay(SE_fadeOutDelay);

		LeanTween.value(gameObject,50f,-50f, SE_BloomDownDuration).setOnUpdate( (float val)=> { setBloomIntensity(val); }).setEase( LeanTweenType.easeInSine).setDelay(SE_BloomDownDelay);

		LeanTween.value(gameObject,-50f,0f, .001f).setOnUpdate( (float val)=> { setBloomIntensity(val); }).setDelay(SE_BloomDownDelay+SE_BloomDownDuration);


	}

	void SpinMe (float delay) {
		
		LeanTween.rotate(rectTransform, -3240, 4f).setEase(LeanTweenType.easeInOutSine).setDelay(delay);
	}

	void MoveIn (float delay) {

		LeanTween.moveX(logoRectTransform, 141f, 1f).setEase( LeanTweenType.easeOutElastic).setDelay(delay);

	}

	void ChangeTextColor (Color color,float delay) {

		LeanTween.colorText ( textcolorRectTransform,  color, 2f ).setDelay(delay);

	}

	void ShakeBlur (float myduration, float delay) {

		LeanTween.value(gameObject,0f,10f, myduration).setOnUpdate( (float val)=> { setBlurSize(val); }).setEase( LeanTweenType.easeShake).setDelay(delay);

	}



	void FadeElement (float delay) {

		LeanTween.alphaCanvas(canvasGroupLogoGroupToFade, 0f, fadeDuration).setEase(LeanTweenType.easeInCirc).setDelay(delay);

	}

	void setBlurSize (float value) {

		var blur = Camera.main.GetComponent<BlurOptimized>();
		blur.blurSize = value; 
	}



	void setBloomIntensity(float value) {
		var bloom = Camera.main.GetComponent<Bloom>();

		bloom.bloomIntensity = value;
	}






	// Update is called once per frame
	void Update () {
	
	}
}
