using UnityEngine;
using System.Collections;

public class VintageColorList {

	public enum VintageColorNames{
		None,
		F1997,
		Aden,
		Amaro,
		Brannan,
		Crema,
		Earlybird,
		Hefe,
		Hudson,
		Inkwell,
		Juno,
		Kelvin,
		Lark,
		LoFi,
		Ludwig,
		Mayfair,
		Nashville,
		Perpetua,
		Reyes,
		Rise,
		Sierra,
		Slumber,
		Sutro,
		Toaster,
		Valencia,
		Walden,
		Willow,
		XProII			
	}

	private static Hashtable VintageColorValues = new Hashtable{
		{ VintageColorNames.None			, new Color32 (236,		138,	  0,		255		) },
		{ VintageColorNames.F1997			, new Color32 (250,		138,	  0,		255		) },
		{ VintageColorNames.Aden			, new Color32 (235,		177,	 19,		255		) },
		{ VintageColorNames.Amaro			, new Color32 (  0,		109,	255,		255		) },
		{ VintageColorNames.Brannan 		, new Color32 (  0,		 93,	255,		255			) },
		{ VintageColorNames.Crema			, new Color32 (  0,		181,	255,		255		) },
		{ VintageColorNames.Earlybird		, new Color32 (234, 	 26, 	 26,   		255		) },
		{ VintageColorNames.Hefe			, new Color32 (244, 	132, 	 23,        255	) },
		{ VintageColorNames.Hudson			, new Color32 (249, 	227, 	 28,        255	) },
		{ VintageColorNames.Inkwell			, new Color32 (	25, 	201, 	 25,        255		) },
		{ VintageColorNames.Juno			, new Color32 (	29, 	203, 	234,        255	) },
		{ VintageColorNames.Kelvin			, new Color32 (	29, 	 53, 	234,        255		) },
		{ VintageColorNames.Lark			, new Color32 (244, 	132, 	 23,        255	) },
		{ VintageColorNames.LoFi			, new Color32 (155, 	 29, 	234,        255	) },
		{ VintageColorNames.Ludwig			, new Color32 (172, 	122, 	 51,        255	) },
		{ VintageColorNames.Mayfair			, new Color32 (255, 	  0, 	  0,        255		) },
		{ VintageColorNames.Nashville		, new Color32 (  0, 	 34, 	205,        255		) },
		{ VintageColorNames.Perpetua		, new Color32 (  0, 	141, 	  0,        255		) },
		{ VintageColorNames.Reyes	        , new Color32 (255, 	213, 	  0,        255	    ) },
		{ VintageColorNames.Rise		    , new Color32 (  0, 	194, 	177,        255		) }, 
		{ VintageColorNames.Sierra		    , new Color32 (  0, 	194, 	177,        255		) }, 
		{ VintageColorNames.Slumber		    , new Color32 (  0, 	194, 	177,        255		) }, 
		{ VintageColorNames.Sutro		    , new Color32 (  0, 	194, 	177,        255		) }, 
		{ VintageColorNames.Toaster		    , new Color32 (  0, 	194, 	177,        255		) }, 
		{ VintageColorNames.Valencia		, new Color32 (  0, 	194, 	177,        255		) }, 
		{ VintageColorNames.Walden			, new Color32 (  0, 	194, 	177,        255		) }, 
		{ VintageColorNames.Willow			, new Color32 (  0, 	194, 	177,        255		) }, 
		{ VintageColorNames.XProII			, new Color32 (  0, 	194, 	177,        255		) },
	};

	public static Color32 VintageColorValue( VintageColorNames color ) {


		return (Color32) VintageColorValues [color];
	}

	//public static Color ColourAtIndex( ColorNames color) {
	//	return (Color) ColorValues [color];
	//}

}
