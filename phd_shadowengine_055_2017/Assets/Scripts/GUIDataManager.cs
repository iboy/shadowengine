using UnityEngine;
using System.Collections;
using System; 
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GUIDataManager : MonoBehaviour {

	public static GUIDataManager guiData; // this line and the exist / destroy checkes below makes this a singleton

	//list public variables to store
	// we will need update processes for these
	// getters / setters for these and
	// binding to the UI etc.
	// Also set sensible defaults
	// You can have save / load methods
	// or handle in Enable // Disable (autosave / autoload)
	// Or control: via load / save
	public float gaussianBlurAmount; // done
	public bool  gaussianBlurIsOn;  // done



	public float sceneFadeAmountValue;
	public bool  sceneFadeIsOn;
	public float irisAmountValue;
	public bool  irisIsOn;
	public bool  colorModeIsOn;
	public bool  grayscaleModeIsOn;
	public bool  monoModeIsOn;

	public float motionBlurAmountValue;
	public bool  motionBlurIsOn;


	public bool  invertIsOn;
	public bool  sepiaIsOn;
	public bool  colorFiltersIsOn;
	public float colorFiltersBlendingValue;
	public bool  vintageFiltersIsOn;
	public bool  vignetteAmountIsOn;
	public float vignetteAmountValue;
	public bool  vignetteBlurIsOn;
	public float vignetteBlurAmount;
	public bool  vignetteChromaticAbIsOn;
	public float vignetteChromaticAbValue;
	public float noiseAmountValue;
	public bool  noiseIsOn;
	public bool  sunshaftsIsOn;
	public float sunshaftsAmountValue;

	public int 	 currentlySelectedColorFilter;
	public float photoFilterColorRed;
	public float photoFilterColorGreen;
	public float photoFilterColorBlue;
	public float photoFilterColorAlpha;
	public bool photoFilterIsOn;
	public int vintageFilterIndex;
	// Puppets
	public bool  wayangSNIsOn;
	public bool  wayangSN2IsOn;
	public bool  wayangDDIsOn;
	public bool  wayangIKIsOn;
	public bool  IIMBirdIsOn;
	public bool  IIMBirdSmallIsOn;
	public bool  abstract001IsOn;
	public bool  reinigerHandIKIsOn;
	public bool  reinigerHandSNIsOn;
	public bool  reinigerHorseIKIsOn;
	public bool  reinigerHorseSNIsOn;
	public bool  reinigerGirlIKIsOn;
	public bool  reinigerGirlSNIsOn;

	public bool  FABRIKTest001IsOn;
	public bool  FABRIKTest002IsOn;
	public bool  FABRIKBirdIsOn;
	public bool  FABRIKBird_002IsOn;




	//Global Setting for Controller Visibility
	public bool  controllerVisibilityIsOn;
	public float controllerAlphaAmountValue;
	public bool  controllerIsGrayscaleIsOn;



	void Awake() {
		if (guiData == null){
			DontDestroyOnLoad(gameObject);
			guiData = this;

		} else if (guiData != this) {

			Destroy(gameObject);

		}
			
	} // end of awake


	void OnEnable() {

		LoadGUIData();

	}

	void OnDisable() {

		SaveGUIData();

	}

	public void SaveGUIData() {

		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create(Application.persistentDataPath+ "/guidata.dat");
		ShadowEngineGUIData data = new ShadowEngineGUIData();
		data.gaussianBlurAmount 			= 					gaussianBlurAmount;
		data.gaussianBlurIsOn 				= 					gaussianBlurIsOn;

		data.sceneFadeAmountValue			=					sceneFadeAmountValue;
		data.sceneFadeIsOn					=					sceneFadeIsOn;
		data.irisAmountValue				=					irisAmountValue;
		data.irisIsOn						=					irisIsOn;
		data.colorModeIsOn					=					colorModeIsOn;
		data.grayscaleModeIsOn				=					grayscaleModeIsOn;
		data.monoModeIsOn					=					monoModeIsOn;

		data.motionBlurAmountValue			=					motionBlurAmountValue;
		data.motionBlurIsOn					=					motionBlurIsOn;

		data.invertIsOn						=					invertIsOn;
		data.sepiaIsOn						=					sepiaIsOn;
		data.colorFiltersBlendingValue		=					colorFiltersBlendingValue;
		data.colorFiltersIsOn				=					colorFiltersIsOn;
		data.vintageFiltersIsOn				=					vintageFiltersIsOn;
		data.vignetteAmountIsOn				=					vignetteAmountIsOn;
		data.vignetteAmountValue			=					vignetteAmountValue;
		data.vignetteBlurIsOn				=					vignetteBlurIsOn;
		data.vignetteBlurAmount				=					vignetteBlurAmount;
		data.vignetteChromaticAbIsOn		=					vignetteChromaticAbIsOn;
		data.vignetteChromaticAbValue		=					vignetteChromaticAbValue;
		data.noiseAmountValue				=					noiseAmountValue;
		data.noiseIsOn						=					noiseIsOn;
		data.sunshaftsIsOn					=					sunshaftsIsOn;
		data.sunshaftsAmountValue			=					sunshaftsAmountValue;

		data.currentlySelectedColorFilter	=					currentlySelectedColorFilter; 
		data.photoFilterColorRed			=					photoFilterColorRed;
		data.photoFilterColorGreen			=					photoFilterColorGreen;
		data.photoFilterColorBlue			=					photoFilterColorBlue;
		data.photoFilterColorAlpha			=					photoFilterColorAlpha;

		data.photoFilterIsOn				=					photoFilterIsOn;
		data.vintageFilterIndex				=					vintageFilterIndex;

		data.wayangSNIsOn					=					wayangSNIsOn;
		data.wayangSN2IsOn					=					wayangSN2IsOn;
		data.wayangDDIsOn					=					wayangDDIsOn;
		data.wayangIKIsOn					=					wayangIKIsOn;
		data.IIMBirdIsOn					=					IIMBirdIsOn;
		data.IIMBirdSmallIsOn				=					IIMBirdSmallIsOn;
		data.abstract001IsOn				=					abstract001IsOn;

		data.reinigerHandIKIsOn				=                   reinigerHandIKIsOn;	
		data.reinigerHandSNIsOn				=                   reinigerHandSNIsOn;	
		data.FABRIKTest001IsOn				=                   FABRIKTest001IsOn;	
		data.FABRIKTest002IsOn				=                   FABRIKTest002IsOn;	
		data.FABRIKBirdIsOn			        =                   FABRIKBirdIsOn;			
		data.FABRIKBird_002IsOn			        =               FABRIKBird_002IsOn;			


		data.reinigerHandIKIsOn				=					reinigerHandIKIsOn;
		data.reinigerHandSNIsOn				=					reinigerHandSNIsOn;
		data.reinigerHorseSNIsOn			=					reinigerHorseSNIsOn;
		data.reinigerHorseIKIsOn			=					reinigerHorseIKIsOn;
		data.reinigerGirlSNIsOn				=					reinigerGirlSNIsOn;
		data.reinigerGirlIKIsOn				=					reinigerGirlIKIsOn;
		data.controllerVisibilityIsOn		=					controllerVisibilityIsOn;
		data.controllerAlphaAmountValue		=					controllerAlphaAmountValue;
		data.controllerIsGrayscaleIsOn		=					controllerIsGrayscaleIsOn;


		bf.Serialize(file,data);
		file.Close();
		#if UNITY_WEBGL && !UNITY_EDITOR
		Application.ExternalEval("FS.syncfs(false, function (err) {})");
		#endif
	}

	public void LoadGUIData() {
		//Debug.Log(Application.persistentDataPath); // Uncomment to see where the persistentDataPath is
		if (File.Exists(Application.persistentDataPath+ "/guidata.dat")) {
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath+ "/guidata.dat", FileMode.Open);
			ShadowEngineGUIData data = (ShadowEngineGUIData)bf.Deserialize(file); // casts from generic object ot our ShadowEngineGUIData class
			file.Close();

			gaussianBlurAmount 				= 					data.gaussianBlurAmount;
			gaussianBlurIsOn 				= 					data.gaussianBlurIsOn;
			sceneFadeAmountValue			=					data.sceneFadeAmountValue;
			sceneFadeIsOn					=					data.sceneFadeIsOn;
			irisAmountValue					=					data.irisAmountValue;
			irisIsOn						=					data.irisIsOn;
			colorModeIsOn					=					data.colorModeIsOn;
			colorFiltersBlendingValue		=					data.colorFiltersBlendingValue;
			grayscaleModeIsOn				=					data.grayscaleModeIsOn;
			monoModeIsOn					=					data.monoModeIsOn;

			motionBlurAmountValue			=					data.motionBlurAmountValue;
			motionBlurIsOn					=					data.motionBlurIsOn;

			invertIsOn						=					data.invertIsOn;
			sepiaIsOn						=					data.sepiaIsOn;
			colorFiltersIsOn				=					data.colorFiltersIsOn;
			vintageFiltersIsOn				=					data.vintageFiltersIsOn;
			vignetteAmountIsOn				=					data.vignetteAmountIsOn;
			vignetteAmountValue				=					data.vignetteAmountValue;
			vignetteBlurIsOn				=					data.vignetteBlurIsOn;
			vignetteBlurAmount				=					data.vignetteBlurAmount;
			vignetteChromaticAbIsOn			=					data.vignetteChromaticAbIsOn;
			vignetteChromaticAbValue		=					data.vignetteChromaticAbValue;
			noiseAmountValue				=					data.noiseAmountValue;
			noiseIsOn						=					data.noiseIsOn;
			sunshaftsIsOn					=					data.sunshaftsIsOn;
			sunshaftsAmountValue			=					data.sunshaftsAmountValue;

			currentlySelectedColorFilter	=					data.currentlySelectedColorFilter;
			photoFilterColorRed				=					data.photoFilterColorRed;
			photoFilterColorGreen			=					data.photoFilterColorGreen;
			photoFilterColorBlue			=					data.photoFilterColorBlue;
			photoFilterColorAlpha			=					data.photoFilterColorAlpha;
			photoFilterIsOn					=					data.photoFilterIsOn;
			vintageFilterIndex				=					data.vintageFilterIndex;


			wayangSNIsOn					=					data.wayangSNIsOn;
			wayangSN2IsOn					=					data.wayangSN2IsOn;
			wayangDDIsOn					=					data.wayangDDIsOn;
			wayangIKIsOn					=					data.wayangIKIsOn;
			IIMBirdIsOn						=					data.IIMBirdIsOn;
			IIMBirdSmallIsOn				=					data.IIMBirdSmallIsOn;
			abstract001IsOn					=					data.abstract001IsOn;
			reinigerHandIKIsOn				=					data.reinigerHandIKIsOn;
			reinigerHandSNIsOn				=					data.reinigerHandSNIsOn;
			reinigerHorseSNIsOn				=					data.reinigerHorseSNIsOn;
			reinigerHorseIKIsOn				=					data.reinigerHorseIKIsOn;
			reinigerGirlSNIsOn				=					data.reinigerGirlSNIsOn;
			reinigerGirlIKIsOn				=					data.reinigerGirlIKIsOn;

	
			FABRIKTest001IsOn				=                   data.FABRIKTest001IsOn;	
			FABRIKTest002IsOn				=                   data.FABRIKTest002IsOn;	
			FABRIKBirdIsOn				    =                   data.FABRIKBirdIsOn;			
			FABRIKBird_002IsOn		        =                   data.FABRIKBird_002IsOn;	


			controllerVisibilityIsOn		=					data.controllerVisibilityIsOn;
			controllerAlphaAmountValue		=					data.controllerAlphaAmountValue;
			controllerIsGrayscaleIsOn		=					data.controllerIsGrayscaleIsOn;
		}

	}

}


// clean private class to mirror the data for this file
// this is where you need get and sets for all data
[Serializable]
class ShadowEngineGUIData {

	public float gaussianBlurAmount;
	public bool  gaussianBlurIsOn;
	public float sceneFadeAmountValue;
	public bool  sceneFadeIsOn;
	public float irisAmountValue;
	public bool  irisIsOn;
	public bool  colorModeIsOn;
	public bool  grayscaleModeIsOn;
	public bool  monoModeIsOn;

	public float motionBlurAmountValue;
	public bool  motionBlurIsOn;


	public bool  invertIsOn;
	public bool  sepiaIsOn;
	public bool  colorFiltersIsOn;
	public float colorFiltersBlendingValue;
	public bool  vintageFiltersIsOn;
	public bool  vignetteAmountIsOn;
	public float vignetteAmountValue;
	public bool  vignetteBlurIsOn;
	public float vignetteBlurAmount;
	public bool  vignetteChromaticAbIsOn;
	public float vignetteChromaticAbValue;
	public float noiseAmountValue;
	public bool  noiseIsOn;
	public bool  sunshaftsIsOn;
	public float sunshaftsAmountValue;

	public int 	 currentlySelectedColorFilter;
	public float photoFilterColorRed;
	public float photoFilterColorGreen;
	public float photoFilterColorBlue;
	public float photoFilterColorAlpha;
	public bool 	photoFilterIsOn;
	public int 		vintageFilterIndex;
	// Puppets
	public bool  wayangSNIsOn;
	public bool  wayangSN2IsOn;
	public bool  wayangDDIsOn;
	public bool  wayangIKIsOn;
	public bool  IIMBirdIsOn;
	public bool  IIMBirdSmallIsOn;
	public bool  abstract001IsOn;


	public bool  reinigerHorseIKIsOn;
	public bool  reinigerHorseSNIsOn;
	public bool  reinigerHandIKIsOn;	
	public bool  reinigerHandSNIsOn;	
	public bool  reinigerGirlIKIsOn;
	public bool  reinigerGirlSNIsOn;

	public bool  FABRIKTest001IsOn;
	public bool  FABRIKTest002IsOn;
	public bool  FABRIKBirdIsOn;
	public bool  FABRIKBird_002IsOn;


	public bool  controllerVisibilityIsOn;
	public float controllerAlphaAmountValue;
	public bool controllerIsGrayscaleIsOn;


}
