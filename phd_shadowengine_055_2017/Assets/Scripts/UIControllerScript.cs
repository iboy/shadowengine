using UnityEngine;
using UnityStandardAssets.ImageEffects;
using UnityEngine.UI;
using System.Collections;
using Colorful;
using MaterialUI;

/// <summary>
/// User interface controller script.
/// </summary>


public class UIControllerScript : MonoBehaviour {

	// Transitions

	[SerializeField] private Slider m_SliderIrisRadius;
	[SerializeField] private Toggle m_ToggleAutoIris;

	[SerializeField] private Slider m_SliderSceneFade;
	[SerializeField] private Toggle m_ToggleAutoSceneFade;
	[SerializeField] private Slider m_SliderTransitionSpeed;

	public GameObject iris;
	public GameObject sceneFade;


	// Vignette
	[SerializeField] private Toggle m_ToggleChromaticAbberation;
	[SerializeField] private Toggle m_ToggleVignetteBlur;
	[SerializeField] private Toggle m_ToggleVignetteAmountIsOn;
	[SerializeField] private Slider m_SliderVignetteAmount;
	[SerializeField] private Slider m_SliderVignetteBlur;
	[SerializeField] private Slider m_SliderVignetteChromaticAbberationAmount;

	private float currentVignetteChromaticAberrationAmount;
	private float currentVignetteBlurAmount;
	private float currentColorFilterBlendingAmount;

	// FX
	[SerializeField] private Slider m_SliderFXBlur;
	[SerializeField] private Slider m_SliderFXMotionBlurAmount;
	[SerializeField] private Slider m_SliderFXNoise;
	[SerializeField] private Slider m_SliderFXSunshafts;

	[SerializeField] private Toggle m_ToggleFXBlur;
	[SerializeField] private Toggle m_ToggleFXMotionBlur;
	[SerializeField] private Toggle m_ToggleFXNoise;
	[SerializeField] private Toggle m_ToggleFXSunShafts;
	// Color

	[SerializeField] private MaterialDropdown m_DropdownColorFilter;
	[SerializeField] private Slider m_SliderColorFilterBlendingAmount;
	[SerializeField] private Slider m_SliderVintageFilterBlendingAmount;
	[SerializeField] private Toggle m_ToggleColorFilter;
	[SerializeField] private MaterialDropdown m_DropdownVintageFilter;
	[SerializeField] private MaterialRadioGroup m_RadioGroupColorGreyMono;
	[SerializeField] private MaterialRadio m_RadioColor;
	[SerializeField] private MaterialRadio m_RadioGray;
	[SerializeField] private MaterialRadio m_RadioMono;
	[SerializeField] private MaterialRadioGroup m_RadioGroupColorGreyMonoPopUp;
	[SerializeField] private MaterialRadio m_RadioColorPopUp;
	[SerializeField] private MaterialRadio m_RadioGrayPopUp;
	[SerializeField] private MaterialRadio m_RadioMonoPopUp;

	[SerializeField] private Toggle m_ToggleInvertIsOn;
	[SerializeField] private Toggle m_ToggleSepiaIsOn;
	[SerializeField] private Toggle m_ToggleColorFiltersIsOn;
	[SerializeField] private Toggle m_ToggleVintageFiltersIsOn;

	// puppet toggles
	[SerializeField] private Toggle m_TogglePuppetWayangSNIsOn;
	[SerializeField] private Toggle m_TogglePuppetWayangSN2IsOn;
	[SerializeField] private Toggle m_TogglePuppetWayangDDIsOn;
	[SerializeField] private Toggle m_TogglePuppetWayangIKIsOn;
	[SerializeField] private Toggle m_TogglePuppetIIMBirdSN2IsOn;
	[SerializeField] private Toggle m_TogglePuppetIIMBirdSNSmallIsOn;
	[SerializeField] private Toggle m_TogglePuppetAbstract001IsOn;

	[SerializeField] private Toggle m_TogglePuppetReinigerHorseIKIsOn;
	[SerializeField] private Toggle m_TogglePuppetReinigerHandIKIsOn;
	[SerializeField] private Toggle m_TogglePuppetReinigerHandSNIsOn;
	[SerializeField] private Toggle m_TogglePuppetReinigerHorseSNIsOn;
	[SerializeField] private Toggle m_TogglePuppetReinigerGirlSNIsOn;
	[SerializeField] private Toggle m_TogglePuppetReinigerGirlIKIsOn;

	[SerializeField] private Toggle m_TogglePuppetReiniger_Hand_Spring_Network_MTIsOn;
	[SerializeField] private Toggle m_TogglePuppetFABRIKTest001IsOn;
	[SerializeField] private Toggle m_TogglePuppetFABRIKTest002IsOn;
	[SerializeField] private Toggle m_TogglePuppetFABRIKBirdIsOn;
	[SerializeField] private Toggle m_TogglePuppetFABRIKBird_002IsOn;


	[SerializeField] private Toggle m_ToggleControllerVisibityIsOn;
	[SerializeField] private Slider m_SliderControllerAlphaAmount;
	[SerializeField] private Toggle m_ToggleControllerIsGrayscaleIsOn;

	private Color myColor;
	public int currentlySelectedColorFilterIndex = 14; // default sepia
	//private ColorList myColorList;

//------------------------------------------------------------------------------
	void Awake()
	{
		//OnSliderValueChanged();
		currentVignetteChromaticAberrationAmount = m_SliderVignetteChromaticAbberationAmount.value;
		currentVignetteBlurAmount = m_SliderVignetteBlur.value;

		//Debug.Log("Awake:" + m_SliderFXBlur.value);

		//m_SliderFXBlur.han
	}

	void Start() 
	{

		// load and initialise values from the datastore guidata.dat
		// this looks to the store
		// finds and sets the component value
		// also sets the UI

		// FX - Blur
		setGaussianBlurAmount(GUIDataManager.guiData.gaussianBlurAmount);
		setGaussianBlurIsOn(GUIDataManager.guiData.gaussianBlurIsOn);
		m_SliderFXBlur.value = GUIDataManager.guiData.gaussianBlurAmount;
		m_ToggleFXBlur.isOn = GUIDataManager.guiData.gaussianBlurIsOn;


		m_SliderSceneFade.value= GUIDataManager.guiData.sceneFadeAmountValue;
		setSceneFade(GUIDataManager.guiData.sceneFadeAmountValue);
		setAutoSceneFadeIsOnTrue(true); // default setting for this control
		//m_SliderSceneFade.value= GUIDataManager.guiData.sceneFadeAmountValue;
		m_ToggleAutoSceneFade.isOn= GUIDataManager.guiData.sceneFadeIsOn;
		// TODO m_SliderTransitionSpeed; not implemented yet

		setIrisFade(GUIDataManager.guiData.irisAmountValue);
		setIrisIsOn(GUIDataManager.guiData.irisIsOn);
		m_ToggleAutoIris.isOn= GUIDataManager.guiData.irisIsOn;
		m_SliderIrisRadius.value = GUIDataManager.guiData.irisAmountValue;

		//setIrisRadius(GUIDataManager.guiData.irisAmountValue);
		// Iris Auto Fade Toggle should default to on / true
		//m_SliderIrisRadius.value= GUIDataManager.guiData.irisAmountValue;


		if (GUIDataManager.guiData.colorModeIsOn == true) {

			m_RadioColor.toggle.Set(true, true);
		}
			
		// TODO it is a choice as to whether the monochrome mode is totally devoid of colour. Shouldn't be really. Lights
		// can still be coloured even if a silhouette is opaque.
		if (GUIDataManager.guiData.grayscaleModeIsOn == true && GUIDataManager.guiData.monoModeIsOn == true) {

			m_RadioMono.toggle.Set(true, true);

		}

		if (GUIDataManager.guiData.grayscaleModeIsOn == true && GUIDataManager.guiData.monoModeIsOn == false) {

			m_RadioGray.toggle.Set(true, true);

		}
			
		setMotionBlurAmount(GUIDataManager.guiData.motionBlurAmountValue);
		setMotionBlurIsOn(GUIDataManager.guiData.motionBlurIsOn);
		m_SliderFXMotionBlurAmount.value= GUIDataManager.guiData.motionBlurAmountValue;
		m_ToggleFXMotionBlur.isOn= GUIDataManager.guiData.motionBlurIsOn;

		setInvertIsOn(GUIDataManager.guiData.invertIsOn);
		setSepiaIsOn(GUIDataManager.guiData.sepiaIsOn);
		setVintageIsOn(GUIDataManager.guiData.vintageFiltersIsOn);

		m_ToggleInvertIsOn.isOn= GUIDataManager.guiData.invertIsOn;
		m_ToggleSepiaIsOn.isOn= GUIDataManager.guiData.sepiaIsOn;
		m_ToggleColorFiltersIsOn.isOn= GUIDataManager.guiData.photoFilterIsOn;
		m_ToggleVintageFiltersIsOn.isOn= GUIDataManager.guiData.vintageFiltersIsOn;

		setColorFilterDensityByValue(GUIDataManager.guiData.colorFiltersBlendingValue);
		m_SliderColorFilterBlendingAmount.value = GUIDataManager.guiData.colorFiltersBlendingValue;

		setColorFilterColorInitFromData(GUIDataManager.guiData.photoFilterColorRed, GUIDataManager.guiData.photoFilterColorGreen, GUIDataManager.guiData.photoFilterColorBlue, GUIDataManager.guiData.photoFilterColorAlpha);
		setToggleColorFilter(GUIDataManager.guiData.photoFilterIsOn);

		// Vignette

		setVignetteAmount(GUIDataManager.guiData.vignetteAmountValue);
		m_SliderVignetteAmount.value= GUIDataManager.guiData.vignetteAmountValue;
		setVignetteIsOnInit(GUIDataManager.guiData.vignetteAmountIsOn);
		m_ToggleVignetteAmountIsOn.isOn= GUIDataManager.guiData.vignetteAmountIsOn;
		setToggleVignetteBlurInit(GUIDataManager.guiData.vignetteAmountIsOn);
		m_ToggleVignetteBlur.isOn= GUIDataManager.guiData.vignetteBlurIsOn;
		setVignetteBlur(GUIDataManager.guiData.vignetteBlurAmount);
		m_SliderVignetteBlur.value= GUIDataManager.guiData.vignetteBlurAmount;
		setToggleChromaticIsOn(GUIDataManager.guiData.vignetteChromaticAbIsOn);
		m_ToggleChromaticAbberation.isOn= GUIDataManager.guiData.vignetteChromaticAbIsOn;
		setVignetteChromaticAberrationInit(GUIDataManager.guiData.vignetteChromaticAbValue);
		m_SliderVignetteChromaticAbberationAmount.value= GUIDataManager.guiData.vignetteChromaticAbValue; //vignetteChromaticAbValue


		setNoiseAmount(GUIDataManager.guiData.noiseAmountValue);
		m_SliderFXNoise.value= GUIDataManager.guiData.noiseAmountValue;

		setNoiseIsOn(GUIDataManager.guiData.noiseIsOn);
		m_ToggleFXNoise.isOn= GUIDataManager.guiData.noiseIsOn;

		setSunshaftsIsOn(GUIDataManager.guiData.sunshaftsIsOn);
		m_ToggleFXSunShafts.isOn= GUIDataManager.guiData.sunshaftsIsOn;
		setSunShaftsIntensityAmount(GUIDataManager.guiData.sunshaftsAmountValue);
		m_SliderFXSunshafts.value= GUIDataManager.guiData.sunshaftsAmountValue;

		//Puppets
		// set puppet state from startup. We still need to switch the enabled status somewhere
		// this doesn't really belong in GUI
		// TODO we need a puppet controller that handles sets and visibility.

		m_TogglePuppetWayangSNIsOn.isOn= GUIDataManager.guiData.wayangSNIsOn;
		m_TogglePuppetWayangSN2IsOn.isOn= GUIDataManager.guiData.wayangSN2IsOn;
		m_TogglePuppetWayangDDIsOn.isOn= GUIDataManager.guiData.wayangDDIsOn;
		m_TogglePuppetWayangIKIsOn.isOn= GUIDataManager.guiData.wayangIKIsOn;
		m_TogglePuppetIIMBirdSN2IsOn.isOn= GUIDataManager.guiData.IIMBirdIsOn;
		m_TogglePuppetAbstract001IsOn.isOn= GUIDataManager.guiData.abstract001IsOn;


		m_TogglePuppetReinigerHorseIKIsOn.isOn 	= GUIDataManager.guiData.reinigerHorseIKIsOn;
		m_TogglePuppetReinigerHandIKIsOn.isOn	= GUIDataManager.guiData.reinigerHandIKIsOn;
		m_TogglePuppetReinigerHorseSNIsOn.isOn	= GUIDataManager.guiData.reinigerHorseSNIsOn;

		m_TogglePuppetReinigerHandSNIsOn.isOn	= GUIDataManager.guiData.reinigerHandSNIsOn;
		m_TogglePuppetReinigerGirlSNIsOn.isOn	= GUIDataManager.guiData.reinigerGirlSNIsOn;
		m_TogglePuppetReinigerGirlIKIsOn.isOn	= GUIDataManager.guiData.reinigerGirlIKIsOn;
		m_TogglePuppetIIMBirdSNSmallIsOn.isOn = GUIDataManager.guiData.IIMBirdSmallIsOn;

		m_TogglePuppetIIMBirdSNSmallIsOn.isOn = GUIDataManager.guiData.IIMBirdSmallIsOn;
		m_TogglePuppetIIMBirdSNSmallIsOn.isOn = GUIDataManager.guiData.IIMBirdSmallIsOn;
		m_TogglePuppetIIMBirdSNSmallIsOn.isOn = GUIDataManager.guiData.IIMBirdSmallIsOn;
		m_TogglePuppetIIMBirdSNSmallIsOn.isOn = GUIDataManager.guiData.IIMBirdSmallIsOn;


		m_TogglePuppetReiniger_Hand_Spring_Network_MTIsOn.isOn = GUIDataManager.guiData.reinigerHandSNIsOn;
		m_TogglePuppetFABRIKTest001IsOn.isOn = GUIDataManager.guiData.FABRIKTest001IsOn;
		m_TogglePuppetFABRIKTest002IsOn.isOn = GUIDataManager.guiData.FABRIKBird_002IsOn;
		m_TogglePuppetFABRIKBirdIsOn.isOn = GUIDataManager.guiData.FABRIKBirdIsOn;
		m_TogglePuppetFABRIKBird_002IsOn.isOn = GUIDataManager.guiData.FABRIKBird_002IsOn;

		//m_TogglePuppetAbstract001IsOn.isOn= GUIDataManager.guiData.IIMBirdIsOn;

		// global puppet control slider

		//this.PuppetControllerAlphaAmount = GUIDataManager.guiData.controllerAlphaAmountValue;
		storedPuppetControllerAlphaAmount = GUIDataManager.guiData.controllerAlphaAmountValue;
		setSliderControllerAlphaAmount(GUIDataManager.guiData.controllerAlphaAmountValue);
		setToggleControllerVisibityIsOn(GUIDataManager.guiData.controllerVisibilityIsOn);
		//this.PuppetControllerVisibility = GUIDataManager.guiData.controllerVisibilityIsOn;

		setToggleControllerGrayscaleIsOn(GUIDataManager.guiData.controllerIsGrayscaleIsOn);

		m_ToggleControllerVisibityIsOn.isOn= GUIDataManager.guiData.controllerVisibilityIsOn;
		m_SliderControllerAlphaAmount.value= GUIDataManager.guiData.controllerAlphaAmountValue;
		m_ToggleControllerIsGrayscaleIsOn.isOn = GUIDataManager.guiData.controllerIsGrayscaleIsOn;

		//Debug.Log("Start:" + m_SliderFXBlur.value);

	}
		/// <summary>
		/// Sets the defaults.
		/// </summary>
	public void SetDefaults() {

		// these are some critical values (to see something on launch)
		// Could break these down a bit


		setVignetteAmount (0.396f);
		GUIDataManager.guiData.vignetteAmountValue 			= 0.396f; 
		m_SliderVignetteAmount.value						= 0.396f;
		setVignetteIsOnInit (true);	
		GUIDataManager.guiData.vignetteAmountIsOn 			= true;
		m_ToggleVignetteAmountIsOn.isOn 					= true;
		setToggleVignetteBlurInit (true);
		GUIDataManager.guiData.vignetteAmountIsOn 			= true;
		m_ToggleVignetteBlur.isOn							= true;
		setVignetteBlur (0.508f);
		GUIDataManager.guiData.vignetteBlurAmount 			= 0.508f;
		m_SliderVignetteBlur.value							= 0.508f;
		setToggleChromaticIsOn (true);
		GUIDataManager.guiData.vignetteChromaticAbIsOn 		= true;
		m_ToggleChromaticAbberation.isOn					= true;
		setVignetteChromaticAberration (0f);
		GUIDataManager.guiData.vignetteChromaticAbValue 	=	 0f;
		m_SliderVignetteChromaticAbberationAmount.value		= 	 0f;
		//vignetteChromaticAbValue



		setInvertIsOn(false);
		setSepiaIsOn(false);
		setToggleColorFilter(false);
		setVintageIsOn(false);

		GUIDataManager.guiData.invertIsOn = false;
		GUIDataManager.guiData.sepiaIsOn = false;
		GUIDataManager.guiData.photoFilterIsOn =  false;
		GUIDataManager.guiData.vintageFiltersIsOn =  false;
		GUIDataManager.guiData.noiseIsOn =  false;
		m_ToggleInvertIsOn.isOn=  false;
		m_ToggleSepiaIsOn.isOn=  false;
		m_ToggleColorFiltersIsOn.isOn=  false;
		m_ToggleVintageFiltersIsOn.isOn=  false;
		m_ToggleFXNoise.isOn = false;



	}

// TOAST MESSAGE -------------------------------------------------------------------
	/// <summary>
	/// Displays the type of the puppet, name and control type.
	/// </summary>
	/// <param name="myName">Puppet name.</param>
	/// <param name="controllerType">Controller type.</param>
	/// <param name="displayTime">Display time for Material UI 'Toast'</param>
	/// <param name="fontSize">Font size.</param>
	public void displayPuppetNameAndControlType(string myName, string controllerType, float displayTime, int fontSize) {

		ToastManager.Show(myName+" "+controllerType, displayTime,  new Color (0f,0f,0f,1f),  new Color (255f,255f,255f,1f), fontSize);

	}



// PUPPET CONTROLLERS---------------------------------------------------------------

	// this is a test to check if 'properties' will make a number of things easier.
	// e.g. default management; binding to OSC; centralising the data to objects look here
	private bool puppetControllerVisibility;
	private bool changeFlag = false;
	public bool PuppetControllerVisibility {

		get { 	return puppetControllerVisibility; }
		set { 	
			if (value == true) {
				//Debug.Log("Turning on the toggle and setting the slider-value the stored value");
				//	this.PuppetControllerAlphaAmount = storedPuppetControllerAlphaAmount;
				this.PuppetControllerAlphaAmount = storedPuppetControllerAlphaAmount;
				}
			if (value == false) {
				//Debug.Log("Turning off the toggle and storing the slider-float value");
				storedPuppetControllerAlphaAmount = puppetControllerAlphaAmount;
				this.PuppetControllerAlphaAmount = 0f;
				//GUIDataManager.guiData.controllerAlphaAmountValue = storedPuppetControllerAlphaAmount;
				//this.StoredPuppetControllerAlphaAmount = puppetControllerAlphaAmount;

				}
			puppetControllerVisibility = value;	
			m_ToggleControllerVisibityIsOn.isOn = value;
			GUIDataManager.guiData.controllerVisibilityIsOn = value;

			//if (!value) { this.StoredPuppetControllerAlphaAmount = puppetControllerAlphaAmount ;
			//	PuppetControllerAlphaAmount = 0f;
			//	//puppetControllerAlphaAmount = 0f;
			//} else { 
			//
			//	if  ( puppetControllerAlphaAmount > 0f ) {
			//	this.PuppetControllerAlphaAmount = storedPuppetControllerAlphaAmount;
			//	}
			//}
		}
	}

	private float puppetControllerAlphaAmount;
	public float PuppetControllerAlphaAmount {

		get { 	return puppetControllerAlphaAmount; }
		set { 	
			
			//if (value == 0f) {
			//
			//	PuppetControllerVisibity = false;
			//}
				puppetControllerAlphaAmount = value;	
				m_SliderControllerAlphaAmount.value = value;
				GUIDataManager.guiData.controllerAlphaAmountValue = value;
			//Debug.Log("Stored controllerAlphaAmountValue = "+GUIDataManager.guiData.controllerAlphaAmountValue);
		}
	}

	private float storedPuppetControllerAlphaAmount;
	public float StoredPuppetControllerAlphaAmount {

		get { 	return storedPuppetControllerAlphaAmount; }
		set { 	storedPuppetControllerAlphaAmount = value; 
			//if ( storedPuppetControllerAlphaAmount == 0f ) {

				//this.PuppetControllerVisibility = false;
			//}
		}
	}

	public void setToggleControllerVisibityIsOn(bool state) {

		m_ToggleControllerVisibityIsOn.isOn = state;
	}

	public void setSliderControllerAlphaAmount(float value) {

		m_SliderControllerAlphaAmount.value = value;
		GUIDataManager.guiData.controllerAlphaAmountValue = value;
	}

	public void setToggleControllerGrayscaleIsOn(bool state) {

		m_ToggleControllerIsGrayscaleIsOn.isOn = state;
	}

// FX ------------------------------------------------------------------------------
	public void setGaussianBlurAmount(float value) {

	
		var gaussianBlur = Camera.main.GetComponent<GaussianBlur>();

		GUIDataManager.guiData.gaussianBlurAmount = value; // update the store

		//Debug.Log("gaussianBlurAmount: "+value);
		m_SliderFXBlur.value = value;

		gaussianBlur.Amount = value;
	}

	public float getGaussianBlurAmount() {


		var gaussianBlur = Camera.main.GetComponent<GaussianBlur>();

		//gaussianBlur.Amount = m_SliderFXBlur.value;

		return gaussianBlur.Amount;
	}

	public void setGaussianBlurIsOn(bool state) {
		var gaussianBlur = Camera.main.GetComponent<GaussianBlur>();
		if (gaussianBlur != null) {
			gaussianBlur.enabled = state;
			GUIDataManager.guiData.gaussianBlurIsOn = state;
			//Debug.Log("setGaussianBlurIsOn: "+state);
		}

	}

	public void toggleGaussianBlur() {

		var gaussianBlur = Camera.main.GetComponent<GaussianBlur>();
		if (gaussianBlur != null) {
			if (gaussianBlur.enabled == true) { 

				gaussianBlur.enabled = false; 
				GUIDataManager.guiData.gaussianBlurIsOn = false;
				// Reset Blur
				//m_SliderBlur.value = 0f;

			} else {

				gaussianBlur.enabled = true;
				GUIDataManager.guiData.gaussianBlurIsOn = true;
			}
		}
	}
// FX ------------------------------------------------------------------------------
	public void setMotionBlurAmount(float value) {


		var motionBlur = Camera.main.GetComponent<UnityStandardAssets.ImageEffects.MotionBlur>();
		if (motionBlur != null) {

			GUIDataManager.guiData.motionBlurAmountValue = value; // update the store
			motionBlur.blurAmount = value;
		}

	}

	public void setMotionBlurIsOn(bool state) {


		var motionBlur = Camera.main.GetComponent<UnityStandardAssets.ImageEffects.MotionBlur>();
		if (motionBlur != null) {
			motionBlur.enabled = state;
			m_ToggleFXMotionBlur.isOn = state;
			GUIDataManager.guiData.motionBlurIsOn = state;
		}

	}
// FX ------------------------------------------------------------------------------
	public void setSunShaftsIntensityAmount(float value) {


		var sunShafts = Camera.main.GetComponent<SunShafts>();
		if (sunShafts != null) {
			GUIDataManager.guiData.sunshaftsAmountValue = value; // update the store
			sunShafts.sunShaftIntensity = value;
		}

	}

	public void setSunshaftsIsOn(bool state) {


		var sunShafts = Camera.main.GetComponent<SunShafts>();
		if (sunShafts != null) {

			sunShafts.enabled = state;
			GUIDataManager.guiData.sunshaftsIsOn = state;
		}

	}
// FX ------------------------------------------------------------------------------
	public void setNoiseAmount(float value) {


		var noise = Camera.main.GetComponent<UnityStandardAssets.ImageEffects.NoiseAndGrain>();
		if (noise != null) {
			GUIDataManager.guiData.noiseAmountValue = value; // update the store
			noise.intensityMultiplier = value;

		}

	}

	public void setNoiseIsOn(bool state) {


		var noise = Camera.main.GetComponent<UnityStandardAssets.ImageEffects.NoiseAndGrain>();
		if (noise != null) {
			noise.enabled = state;
			m_ToggleFXNoise.isOn = state;
			GUIDataManager.guiData.noiseIsOn = state;
		} else {

			Debug.Log("no noise component");
		}


	}

// COLOURS ------------------------------------------------------------------------------
	public void setInvertIsOn(bool state) {

		var invertColors = Camera.main.GetComponent<Negative>();

		if (invertColors != null) { 

			invertColors.enabled = state; 
			GUIDataManager.guiData.invertIsOn = state;
		}
	}

	public void toggleInvert() {

		var invertColors = Camera.main.GetComponent<Negative>();

		if (invertColors.enabled == true) { 

			invertColors.enabled = false; 
			GUIDataManager.guiData.invertIsOn = false;

		} else {

			invertColors.enabled = true;
			GUIDataManager.guiData.invertIsOn = true;
		}

	}

// COLOURS ------------------------------------------------------------------------------

	public void toggleGrayscale() {


		//Camera.main.gameObject.GetComponent<UnityStandardAssets.ImageEffects.Grayscale>().enabled = true;
		var grayscale = Camera.main.GetComponent<UnityStandardAssets.ImageEffects.Grayscale>();


		if (grayscale != null ) {
	
			//Debug.Log(grayscale.name);

			if (grayscale.enabled == true) { 
				GUIDataManager.guiData.grayscaleModeIsOn = false;
				grayscale.enabled = false; 
			
			} else {

				grayscale.enabled = true;
				GUIDataManager.guiData.grayscaleModeIsOn = true;
			}

		}
	}



	public void setGrayscale(bool state) {


		//Camera.main.gameObject.GetComponent<UnityStandardAssets.ImageEffects.Grayscale>().enabled = true;
		var grayscale = Camera.main.GetComponent<UnityStandardAssets.ImageEffects.Grayscale>();

		if (grayscale != null ) {
			grayscale.enabled = state; 

			GUIDataManager.guiData.grayscaleModeIsOn = state;
			//GUIDataManager.guiData.colorModeIsOn = false;
			//if (state == false) { 
			//	GUIDataManager.guiData.colorModeIsOn = true;
			//}
		}

	}

	public void setColorModeIsOn(bool state) {



		// set UI - this should only happen on Start();
		//m_RadioGray.toggle.isOn = !state;
		//m_RadioColor.toggle.isOn = state;
		//m_RadioMono.toggle.isOn = !state;
		//
		//m_RadioGrayPopUp.toggle.isOn = !state;
		//m_RadioColorPopUp.toggle.isOn = state;
		//m_RadioMonoPopUp.toggle.isOn = !state;

		setGrayscale(false);

		GUIDataManager.guiData.colorModeIsOn = state;

	}

	public void setMonochromeModeIsOn(bool state) {

		// this manages the UI but doesn't trigger the IsMonochrome action in 


		GUIDataManager.guiData.monoModeIsOn = state;
		//GUIDataManager.guiData.colorModeIsOn = false;

		m_RadioMono.toggle.Set(true,true);
		m_RadioMonoPopUp.toggle.Set(true, true);
		// set UI - this should only happen on Start();
		//m_RadioGray.toggle.isOn = !state;
		//m_RadioColor.toggle.isOn = !state;
		//m_RadioMono.toggle.isOn = state;
		//
		//m_RadioGrayPopUp.toggle.isOn = !state;
		//m_RadioColorPopUp.toggle.isOn = !state;
		//m_RadioMonoPopUp.toggle.isOn = state;

		//setGrayscale(true); // this tickles grayscale if the scene is restored / loaded fresh with monochrome = true


		// not sure if grayscale is required... it turns off colored lights.
		//var grayscale = Camera.main.GetComponent<UnityStandardAssets.ImageEffects.Grayscale>();


	//		grayscale.enabled = state; 

			


	}

// COLOURS ------------------------------------------------------------------------------
	public void toggleVintage() {

		var vintage = Camera.main.GetComponent<VintageFast>();

		if (vintage != null) {
			if (vintage.enabled == true) { 
			
				vintage.enabled = false; 
				GUIDataManager.guiData.vintageFiltersIsOn = false;
			
			} else {
			
				vintage.enabled = true;
				GUIDataManager.guiData.vintageFiltersIsOn = true;
			}
		}

	}

	public void setVintageIsOn(bool state) {
		var vintage = Camera.main.GetComponent<VintageFast>();

		if (vintage != null) {
			vintage.enabled = state;
			GUIDataManager.guiData.vintageFiltersIsOn = state;
		}
	}



	public void setSepiaIsOn(bool state) {
		var photoFilter = Camera.main.GetComponent<PhotoFilter>();

		if (photoFilter != null) {
			Color cachedFilterColor = photoFilter.Color;
			GUIDataManager.guiData.sepiaIsOn = state;
			Color32 sepiaColor = new Color32 (172, 122, 51, 255	);
			photoFilter.Color = sepiaColor;
			photoFilter.enabled = state;


			if (state == false) {

				photoFilter.Color = cachedFilterColor;
			} 

		}
	}



// TRANSITIONS ------------------------------------------------------------------------------
	public void setIrisRadius(float value) {

		//var holeSize = iris.renderer
			// hole size min = 0  max = 
		Renderer rend = iris.GetComponent<Renderer>();

		if (m_SliderIrisRadius.value >= 0.3f) {
				// the idea here is to help selection in the scene view by hiding the 
				// large square texture of the iris - 
				// TODO check if there is a way of making GOs unselectable in the editor.

			//iris.SetActive(false);

			} else {

			iris.SetActive(true);
				

			rend.material.SetFloat( "_Radius", m_SliderIrisRadius.value );
			GUIDataManager.guiData.irisAmountValue = value; // update the store

			}


	}


	public void setIrisIsOn(bool state) {
		
		GUIDataManager.guiData.irisIsOn = state;
		m_ToggleAutoIris.isOn = state;

	}

	public void autoIrisFade() {

		if (m_ToggleAutoIris.isOn == true) {
			// open iris

			//LeanTween.value(m_SliderIrisRadius.value, 0.14f, 2f);



			iTween.ValueTo( gameObject, iTween.Hash(
				"from", m_SliderIrisRadius.value,
				"to", 0.14f,
				"time", 2f,
				"onupdatetarget", gameObject,
				"onupdate", "setIrisFade",
				"easetype", iTween.EaseType.easeInQuad
			)
			);
			GUIDataManager.guiData.irisAmountValue =0.14f; // update the store
			GUIDataManager.guiData.irisIsOn = true;
			//iTween.CameraFadeAdd();
			//iTween.CameraFadeTo(1f, 5.0f);
			//iTween.CameraFadeDestroy();
		} 
		if (m_ToggleAutoIris.isOn == false) {
			// close iris


			iTween.ValueTo( gameObject, iTween.Hash(
				"from", m_SliderIrisRadius.value,
				"to", 0.0f,
				"time", 2f,
				"onupdatetarget", gameObject,
				"onupdate", "setIrisFade",
				"easetype", iTween.EaseType.easeOutQuad
			)
			);
			GUIDataManager.guiData.irisAmountValue =0f; // update the store
			GUIDataManager.guiData.irisIsOn = false;


		}

		//Color myColor = new Color (0f,0f, 0f, m_SliderSceneFade.value );
		//rend.material.SetColor("_Color", myColor );

	}

	public void setIrisFade(float value) {
		Renderer rend = iris.GetComponent<Renderer>();
		//Debug.Log("In Callback: "+value);
		rend.material.SetFloat( "_Radius", value );
		m_SliderIrisRadius.value = value; 
		GUIDataManager.guiData.irisAmountValue =value; // update the store

	}


// TRANSITIONS ------------------------------------------------------------------------------

	public void setSceneFade(float value) {

		GUITexture rend = sceneFade.GetComponent<GUITexture>();


		Color myFadeColor = new Color (0f,0f, 0f, value );
		rend.color = myFadeColor;
		//m_SliderSceneFade.value = value;
		GUIDataManager.guiData.sceneFadeAmountValue = m_SliderSceneFade.value; // update the store

		//SetColor("_Color", myColor );

	}

	public void setAutoSceneFadeIsOnTrue(bool state) {

		m_ToggleAutoSceneFade.isOn = state;
		GUIDataManager.guiData.sceneFadeIsOn =state;

	}



	public void autoSceneFade() {
		
		if (m_ToggleAutoSceneFade.isOn == false) {
	
			// fade in scene
			iTween.ValueTo( gameObject, iTween.Hash(
				"from", m_SliderSceneFade.value,
				"to", 1.0f,
				"time", 2f,
				"onupdatetarget", gameObject,
				"onupdate", "setAutoSceneFade",
				"easetype", iTween.EaseType.easeOutQuad)
			);
			GUIDataManager.guiData.sceneFadeAmountValue =1f; // update the store
			GUIDataManager.guiData.sceneFadeIsOn = false;
		}


		if (m_ToggleAutoSceneFade.isOn == true) {

			// fade out scene
			iTween.ValueTo( gameObject, iTween.Hash(
				"from", m_SliderSceneFade.value,
				"to", 0f,
				"time", 2f,
				"onupdatetarget", gameObject,
				"onupdate", "setAutoSceneFade",
				"easetype", iTween.EaseType.easeInQuad)
			);

			GUIDataManager.guiData.sceneFadeAmountValue =0f; // update the store
			GUIDataManager.guiData.sceneFadeIsOn = true;
		}
			
	}
	public void setAutoSceneFade(float value) {
		//Debug.Log("In setAutoSceneFade");
		GUITexture rend = sceneFade.GetComponent<GUITexture>();
		Color myFadeColor = new Color (0f,0f, 0f, value );
		rend.color = myFadeColor;
		m_SliderSceneFade.value = value;
		GUIDataManager.guiData.sceneFadeAmountValue =value; // update the store

	}


// VIGNETTE ------------------------------------------------------------------------------
	public void toggleVignette () {

		var vignette = Camera.main.GetComponent<VignetteAndChromaticAberration>();
		
		if (vignette.enabled == true) { 
			GUIDataManager.guiData.vignetteAmountIsOn = false;
			vignette.enabled = false; 
		
		} else {
			GUIDataManager.guiData.vignetteAmountIsOn = true;
			vignette.enabled = true;
		}

	}

	public void setVignetteIsOn (bool state) {

		var vignette = Camera.main.GetComponent<VignetteAndChromaticAberration>();

		if (vignette !=null ) { 
			GUIDataManager.guiData.vignetteAmountIsOn = state;
			vignette.enabled = state; 
			m_ToggleVignetteAmountIsOn.isOn = state;
		}

		

	}


	public void setVignetteIsOnInit (bool state) {

		var vignette = Camera.main.GetComponent<VignetteAndChromaticAberration>();

		if (vignette !=null ) { 
			//GUIDataManager.guiData.vignetteAmountIsOn = state;
			vignette.enabled = GUIDataManager.guiData.vignetteAmountIsOn; 
			m_ToggleVignetteAmountIsOn.isOn = GUIDataManager.guiData.vignetteAmountIsOn;
		}

	}

	public void setVignetteAmount(float value) {

		var vignette = Camera.main.GetComponent<VignetteAndChromaticAberration>();
		vignette.intensity = value;
		GUIDataManager.guiData.vignetteAmountValue = value; // update the store


	}

	public void setVignetteBlur(float value) {

		var vignette = Camera.main.GetComponent<VignetteAndChromaticAberration>();
		vignette.blur = value;
		//currentVignetteBlurAmount = m_SliderVignetteBlur.value;
		GUIDataManager.guiData.vignetteBlurAmount = value; // update the store

	}

	public void setVignetteChromaticAberrationInit (float value) {

		var vignette = Camera.main.GetComponent<VignetteAndChromaticAberration>();
		if (vignette != null ) {

			m_SliderVignetteChromaticAbberationAmount.value = value;
			//currentVignetteChromaticAberrationAmount = value;
			GUIDataManager.guiData.vignetteChromaticAbValue = value;
			vignette.chromaticAberration = value;

		}
	}

	public void setVignetteChromaticAberration(float value) {

		var vignette = Camera.main.GetComponent<VignetteAndChromaticAberration>();


		//if (m_SliderVignetteChromaticAbberationAmount.value > 0 && m_ToggleChromaticAbberation.isOn == false) {
		//	
		//	vignette.chromaticAberration = m_SliderVignetteChromaticAbberationAmount.value; // was 0  
		//	m_SliderVignetteChromaticAbberationAmount.value = m_SliderVignetteChromaticAbberationAmount.value; // or 0
		//	currentVignetteChromaticAberrationAmount = m_SliderVignetteChromaticAbberationAmount.value; // was 0
		//	m_ToggleChromaticAbberation.isOn = true;
		//	GUIDataManager.guiData.vignetteChromaticAbValue = m_SliderVignetteChromaticAbberationAmount.value;; // update the store
		//		
		//}
		//
		//if (m_SliderVignetteChromaticAbberationAmount.value < 0 && m_ToggleChromaticAbberation.isOn == false) {
		//	m_SliderVignetteChromaticAbberationAmount.value = m_SliderVignetteChromaticAbberationAmount.value; // was 0
		//	vignette.chromaticAberration = m_SliderVignetteChromaticAbberationAmount.value; // was 0 
		//	currentVignetteChromaticAberrationAmount = m_SliderVignetteChromaticAbberationAmount.value; // or 0
		//	m_ToggleChromaticAbberation.isOn = true;
		//	GUIDataManager.guiData.vignetteChromaticAbValue = m_SliderVignetteChromaticAbberationAmount.value;; // update the store
		//
		//
		//}
				
		vignette.chromaticAberration = value;
		GUIDataManager.guiData.vignetteChromaticAbValue = value; // update the store

		//currentVignetteChromaticAberrationAmount = m_SliderVignetteChromaticAbberationAmount.value;
		

	}
		
	public void setToggleChromaticIsOn(bool state) {

		var vignette = Camera.main.GetComponent<VignetteAndChromaticAberration>();
		//currentVignetteChromaticAberrationAmount = m_SliderVignetteChromaticAbberationAmount.value;

		//currentVignetteChromaticAberrationAmount = m_SliderVignetteChromaticAbberationAmount.value;

		if (state == false) {
			currentVignetteChromaticAberrationAmount = m_SliderVignetteChromaticAbberationAmount.value;
			vignette.chromaticAberration = 0f;
			m_SliderVignetteChromaticAbberationAmount.value = 0f;

		} else {
			vignette.chromaticAberration = currentVignetteChromaticAberrationAmount;
			m_SliderVignetteChromaticAbberationAmount.value = currentVignetteChromaticAberrationAmount;

		}
		//if (state == false) { 
		//	currentVignetteChromaticAberrationAmount = m_SliderVignetteChromaticAbberationAmount.value;
		//	vignette.chromaticAberration = 0f; 
		//	m_SliderVignetteChromaticAbberationAmount.value = 0f;
		//	GUIDataManager.guiData.vignetteChromaticAbIsOn = false;
		//	GUIDataManager.guiData.vignetteChromaticAbValue =  m_SliderVignetteChromaticAbberationAmount.value; // or 0
		//
		//} else {
		//	// this sets the value to the last cached value
		//	vignette.chromaticAberration = currentVignetteChromaticAberrationAmount;
		//	m_SliderVignetteChromaticAbberationAmount.value = currentVignetteChromaticAberrationAmount;
		//	GUIDataManager.guiData.vignetteChromaticAbIsOn = true;
		//	GUIDataManager.guiData.vignetteChromaticAbValue = m_SliderVignetteChromaticAbberationAmount.value; // or 0;
		//}

	}


	//public void toggleChromatic () {
	//
	//	var vignette = Camera.main.GetComponent<VignetteAndChromaticAberration>();
	//	//currentVignetteChromaticAberrationAmount = m_SliderVignetteChromaticAbberationAmount.value;
	//
	//	if (m_ToggleChromaticAbberation.isOn == false) { 
	//		currentVignetteChromaticAberrationAmount = m_SliderVignetteChromaticAbberationAmount.value;
	//		vignette.chromaticAberration = 0f; 
	//		m_SliderVignetteChromaticAbberationAmount.value = 0f;
	//		GUIDataManager.guiData.vignetteChromaticAbIsOn = false;
	//		GUIDataManager.guiData.vignetteChromaticAbValue = 0f;
	//
	//	} else {
	//		// this sets the value to the last cached value
	//		vignette.chromaticAberration = currentVignetteChromaticAberrationAmount;
	//		m_SliderVignetteChromaticAbberationAmount.value = currentVignetteChromaticAberrationAmount;
	//		GUIDataManager.guiData.vignetteChromaticAbIsOn = true;
	//		GUIDataManager.guiData.vignetteChromaticAbValue =currentVignetteChromaticAberrationAmount;
	//	}
	//
	//}

	public void toggleVignetteBlur () {

		var vignette = Camera.main.GetComponent<VignetteAndChromaticAberration>();

		if (m_ToggleVignetteBlur.isOn == false) { 
			currentVignetteBlurAmount = m_SliderVignetteBlur.value;
			vignette.blur = 0f; 
			m_SliderVignetteBlur.value = 0f;
			GUIDataManager.guiData.vignetteBlurIsOn = false;

		} 
		if (m_ToggleVignetteBlur.isOn == true) {

			vignette.blur = currentVignetteBlurAmount;
			m_SliderVignetteBlur.value = currentVignetteBlurAmount;
			GUIDataManager.guiData.vignetteBlurIsOn = true;
		}

	}

	public void setToggleVignetteBlur (bool state) {

		var vignette = Camera.main.GetComponent<VignetteAndChromaticAberration>();

		if (state == false) { 
			currentVignetteBlurAmount = m_SliderVignetteBlur.value;
			vignette.blur = 0f; 
			m_SliderVignetteBlur.value = 0f;
			GUIDataManager.guiData.vignetteBlurIsOn = false;

		} 
		if (state == true) {

			vignette.blur = currentVignetteBlurAmount;
			m_SliderVignetteBlur.value = currentVignetteBlurAmount;
			GUIDataManager.guiData.vignetteBlurIsOn = true;
		}

	}


	public void setToggleVignetteBlurInit (bool state) {

		var vignette = Camera.main.GetComponent<VignetteAndChromaticAberration>();

		if (vignette != null) { 
			
			m_ToggleVignetteBlur.isOn = state;

		} 

	}

// COLOR FILTER -------------------------x-----------------------------------------------------

	public void setToggleColorFilter(bool state) {
		var photoFilter = Camera.main.GetComponent<PhotoFilter>();

		if (photoFilter != null) {

			m_ToggleColorFiltersIsOn.isOn = state;
			photoFilter.enabled = state;


			GUIDataManager.guiData.colorFiltersIsOn = state;
			GUIDataManager.guiData.photoFilterIsOn = state;
		}
	

	}


	public void toggleColorFilter () {

		var photoFilter = Camera.main.GetComponent<PhotoFilter>();

		if (photoFilter != null) {
			currentColorFilterBlendingAmount = m_SliderColorFilterBlendingAmount.value;
			
			if (m_ToggleColorFilter.isOn == false) { 
				//currentColorFilterBlendingAmount = m_SliderColorFilterBlendingAmount.value;
				photoFilter.enabled = false;
				GUIDataManager.guiData.photoFilterIsOn = false;
				GUIDataManager.guiData.colorFiltersIsOn = false;
				//GUIDataManager.guiData.photoFilterColorAlpha = 0f; // update the store
				//photoFilter.Density = 0f; 
				//m_SliderColorFilterBlendingAmount.value = 0f;
			
			} 
			if (m_ToggleColorFilter.isOn == true) {
				photoFilter.enabled = true;
				photoFilter.Density = currentColorFilterBlendingAmount;
				m_SliderColorFilterBlendingAmount.value = currentColorFilterBlendingAmount;
				GUIDataManager.guiData.photoFilterIsOn = true;
				GUIDataManager.guiData.colorFiltersIsOn = true;
			}
		}
	}

	public void setColorFilterColorInitFromData(float r, float g, float b, float a) {

		var photoFilter = Camera.main.GetComponent<PhotoFilter>();
		if (photoFilter != null) {
			Color32 initColor = new Color(r, g, b, a);

			photoFilter.Color = initColor;
			}
	}



	public void setVintageFilterDensity(float value) {

		var vintageFilter = Camera.main.GetComponent<VintageFast>();

		vintageFilter.Amount = value;
		GUIDataManager.guiData.colorFiltersBlendingValue = m_SliderColorFilterBlendingAmount.value; // update the store Note the control is shared


	}


	public void setColorFilterDensityByValue(float value) {

		var photoFilter = Camera.main.GetComponent<PhotoFilter>();

		photoFilter.Density = value;
		m_SliderColorFilterBlendingAmount.value = value;
		GUIDataManager.guiData.colorFiltersBlendingValue = value; // update the store


	}

	public void setColorFilterDensity() {

		var photoFilter = Camera.main.GetComponent<PhotoFilter>();

		photoFilter.Density = m_SliderColorFilterBlendingAmount.value;
		GUIDataManager.guiData.colorFiltersBlendingValue = m_SliderColorFilterBlendingAmount.value; // update the store
		//m_SliderColorFilterBlendingAmount = 


	}
	public void colorFilterDropDown() {


		if (m_DropdownColorFilter.currentlySelected == 0) {   myColor = ColorList.ColorValue(ColorList.ColorNames.WarmingFilter85);   }
		if (m_DropdownColorFilter.currentlySelected == 1) {   myColor = ColorList.ColorValue(ColorList.ColorNames.WarmingFilterLBA);  }
		if (m_DropdownColorFilter.currentlySelected == 2) {   myColor = ColorList.ColorValue(ColorList.ColorNames.WarmingFilter81);   }
		if (m_DropdownColorFilter.currentlySelected == 3) {   myColor = ColorList.ColorValue(ColorList.ColorNames.CoolingFilter85);   }
		if (m_DropdownColorFilter.currentlySelected == 4) {   myColor = ColorList.ColorValue(ColorList.ColorNames.CoolingFilterLBA);  }
		if (m_DropdownColorFilter.currentlySelected == 5) {   myColor = ColorList.ColorValue(ColorList.ColorNames.CoolingFilter81);   }
		if (m_DropdownColorFilter.currentlySelected == 6) {   myColor = ColorList.ColorValue(ColorList.ColorNames.Red);               }
		if (m_DropdownColorFilter.currentlySelected == 7) {   myColor = ColorList.ColorValue(ColorList.ColorNames.Orange);            }
		if (m_DropdownColorFilter.currentlySelected == 8) {   myColor = ColorList.ColorValue(ColorList.ColorNames.Yellow);            }
		if (m_DropdownColorFilter.currentlySelected == 9) {  myColor = ColorList.ColorValue(ColorList.ColorNames.Green);             }
		if (m_DropdownColorFilter.currentlySelected == 10) {  myColor = ColorList.ColorValue(ColorList.ColorNames.Cyan);              }
		if (m_DropdownColorFilter.currentlySelected == 11) {  myColor = ColorList.ColorValue(ColorList.ColorNames.Blue);              }
		if (m_DropdownColorFilter.currentlySelected == 12) {  myColor = ColorList.ColorValue(ColorList.ColorNames.Violet);            }
		if (m_DropdownColorFilter.currentlySelected == 13) {  myColor = ColorList.ColorValue(ColorList.ColorNames.Magenta);           }
		if (m_DropdownColorFilter.currentlySelected == 14) {  myColor = ColorList.ColorValue(ColorList.ColorNames.Sepia);             }
		if (m_DropdownColorFilter.currentlySelected == 15) {  myColor = ColorList.ColorValue(ColorList.ColorNames.DeepRed);           }
		if (m_DropdownColorFilter.currentlySelected == 16) {  myColor = ColorList.ColorValue(ColorList.ColorNames.DeepBlue);          }
		if (m_DropdownColorFilter.currentlySelected == 17) {  myColor = ColorList.ColorValue(ColorList.ColorNames.DeepEmerald);       }
		if (m_DropdownColorFilter.currentlySelected == 18) {  myColor = ColorList.ColorValue(ColorList.ColorNames.DeepYellow);        }
		if (m_DropdownColorFilter.currentlySelected == 19) {  myColor = ColorList.ColorValue(ColorList.ColorNames.Underwater);		 }


		//Debug.Log("You selected: "+m_DropdownColorFilter.currentlySelected);
		var photoFilter = Camera.main.GetComponent<PhotoFilter>();

		//	int filterIndex = m_DropdownColorFilter.currentlySelected;
		//Debug.Log(ColorList.ColorValue(m_DropdownColorFilter.currentlySelected));
		photoFilter.Color = myColor;
		GUIDataManager.guiData.photoFilterColorRed = myColor.r; // update the store // store as int or float implicit conversion? color32 -> color?
		GUIDataManager.guiData.photoFilterColorGreen = myColor.g; // update the store
		GUIDataManager.guiData.photoFilterColorBlue = myColor.b; // update the store
		GUIDataManager.guiData.photoFilterColorAlpha = myColor.a; // update the store
		GUIDataManager.guiData.photoFilterIsOn = m_ToggleColorFiltersIsOn.isOn;

		//photoFilter.Color = PhotoFilter.

	}



	public void vintageFilterDropDown() {

		var vintageFilter = Camera.main.GetComponent<VintageFast>();

		if (vintageFilter != null) {
			if (m_DropdownVintageFilter.currentlySelected == 0) {  vintageFilter.Filter = Vintage.InstragramFilter.None;   }
			if (m_DropdownVintageFilter.currentlySelected == 1) {  vintageFilter.Filter = Vintage.InstragramFilter.F1977;   }
			if (m_DropdownVintageFilter.currentlySelected == 2) {  vintageFilter.Filter = Vintage.InstragramFilter.Aden;   }
			if (m_DropdownVintageFilter.currentlySelected == 3) {  vintageFilter.Filter = Vintage.InstragramFilter.Amaro;   }
			if (m_DropdownVintageFilter.currentlySelected == 4) {  vintageFilter.Filter = Vintage.InstragramFilter.Brannan;   }
			if (m_DropdownVintageFilter.currentlySelected == 5) {  vintageFilter.Filter = Vintage.InstragramFilter.Crema;   }
			if (m_DropdownVintageFilter.currentlySelected == 6) {  vintageFilter.Filter = Vintage.InstragramFilter.Earlybird;   }
			if (m_DropdownVintageFilter.currentlySelected == 7) {  vintageFilter.Filter = Vintage.InstragramFilter.Hefe;   }
			if (m_DropdownVintageFilter.currentlySelected == 8) {  vintageFilter.Filter = Vintage.InstragramFilter.Hudson;   }
			if (m_DropdownVintageFilter.currentlySelected == 9) {  vintageFilter.Filter = Vintage.InstragramFilter.Inkwell;   }
			if (m_DropdownVintageFilter.currentlySelected == 10) { vintageFilter.Filter = Vintage.InstragramFilter.Juno;   }
			if (m_DropdownVintageFilter.currentlySelected == 11) { vintageFilter.Filter = Vintage.InstragramFilter.Kelvin;   }
			if (m_DropdownVintageFilter.currentlySelected == 12) { vintageFilter.Filter = Vintage.InstragramFilter.Lark;   }
			if (m_DropdownVintageFilter.currentlySelected == 13) { vintageFilter.Filter = Vintage.InstragramFilter.LoFi;   }
			if (m_DropdownVintageFilter.currentlySelected == 14) { vintageFilter.Filter = Vintage.InstragramFilter.Ludwig;   }
			if (m_DropdownVintageFilter.currentlySelected == 15) { vintageFilter.Filter = Vintage.InstragramFilter.Mayfair;   }
			if (m_DropdownVintageFilter.currentlySelected == 16) { vintageFilter.Filter = Vintage.InstragramFilter.Nashville;   }
			if (m_DropdownVintageFilter.currentlySelected == 17) { vintageFilter.Filter = Vintage.InstragramFilter.Perpetua;   }
			if (m_DropdownVintageFilter.currentlySelected == 18) { vintageFilter.Filter = Vintage.InstragramFilter.Reyes;   }
			if (m_DropdownVintageFilter.currentlySelected == 19) { vintageFilter.Filter = Vintage.InstragramFilter.Rise;   }
			if (m_DropdownVintageFilter.currentlySelected == 20) { vintageFilter.Filter = Vintage.InstragramFilter.Sierra;   }
			if (m_DropdownVintageFilter.currentlySelected == 21) { vintageFilter.Filter = Vintage.InstragramFilter.Slumber;   }
			if (m_DropdownVintageFilter.currentlySelected == 22) { vintageFilter.Filter = Vintage.InstragramFilter.Sutro;   }
			if (m_DropdownVintageFilter.currentlySelected == 23) { vintageFilter.Filter = Vintage.InstragramFilter.Toaster;   }
			if (m_DropdownVintageFilter.currentlySelected == 24) { vintageFilter.Filter = Vintage.InstragramFilter.Valencia;   }
			if (m_DropdownVintageFilter.currentlySelected == 25) { vintageFilter.Filter = Vintage.InstragramFilter.Walden;   }
			if (m_DropdownVintageFilter.currentlySelected == 26) { vintageFilter.Filter = Vintage.InstragramFilter.Willow;   }
			if (m_DropdownVintageFilter.currentlySelected == 27) { vintageFilter.Filter = Vintage.InstragramFilter.XProII;   }

			// TODO: work out how to implement storage here. It should be an int.

			GUIDataManager.guiData.vintageFilterIndex = m_DropdownVintageFilter.currentlySelected; // update the store

		}
	


	}

// CAMERAS ------------------------------------------------------------------------------


	public void setCameraProjection(bool state ) {


		//bool cameraType = Camera.main.orthographic;

		if (state == true) {
			//cameraType = true;
			Camera.main.orthographic = true;

		} else {
			//cameraType = false;
			Camera.main.orthographic = false;

		}

	}

	public void setCameraProjectionSizeOrFOV(float value ) {


		//bool cameraType = Camera.main.orthographic;

		if (Camera.main.orthographic == true) {
			//cameraType = true;
			Camera.main.orthographicSize = value;

		} else {
			//cameraType = false;
			Camera.main.fieldOfView = value;

		}

	}


// COLOR GRAYSCALE MONO ------------------------------------------------------------------------------

    //public void ColorGrayscaleMonoRadioGroup() {
    //
    //
    //	if (m_RadioColor.toggle.isOn) {
    //
    //		//Debug.Log("Color On");
    //
    //		//Debug.Log("Grayscale Off");
    //		m_RadioColorPopUp.toggle.isOn = true;
    //		setGrayscale(false);
    //		//Debug.Log("Mono Off");
    //
    //
    //	}
    //
    //	if (m_RadioGray.toggle.isOn) {
    //
    //		//Debug.Log("Color Off");
    //		//Debug.Log("Grayscale On");
    //		m_RadioGrayPopUp.toggle.isOn = true;
    //		setGrayscale(true);
    //		//Debug.Log("Mono Off");
    //
    //	}
    //
    //	if (m_RadioMono.toggle.isOn) {
    //
    //		m_RadioMonoPopUp.toggle.isOn = true;
    //		//Debug.Log("Color Off");
    //		//Debug.Log("Grayscale Off");
    //		setGrayscale(false);
    //		//Debug.Log("Mono On");
    //
    //	}
    //
    //
    //}
    //

	//public void radioMonoPopUpSync(bool state) {
	//	m_RadioMonoPopUp.toggle.isOn = state;
	//	m_RadioGrayPopUp.toggle.isOn = !state;
	//	m_RadioColorPopUp.toggle.isOn = !state;
	//
	//}
	//
	//public void radioGrayPopUpSync(bool state) {
	//	m_RadioMonoPopUp.toggle.isOn = !state;
	//	m_RadioGrayPopUp.toggle.isOn = state;
	//	m_RadioColorPopUp.toggle.isOn = !state;
	//
	//}
	//
	//public void radioColorPopUpSync(bool state) {
	//	m_RadioMonoPopUp.toggle.isOn = !state;
	//	m_RadioGrayPopUp.toggle.isOn = !state;
	//	m_RadioColorPopUp.toggle.isOn = state;
	//
	//}

}
