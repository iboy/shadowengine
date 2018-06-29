using UnityEngine;
using System.Collections;

public class ColorList {

	public enum ColorNames{
		WarmingFilter85, 	
		WarmingFilterLBA,	
		WarmingFilter81,	
		CoolingFilter85,	
		CoolingFilterLBA,	
		CoolingFilter81,	
		Red,	
		Orange,	
		Yellow,	
		Green,	
		Cyan,	
		Blue,	
		Violet,	
		Magenta,	
		Sepia,	
		DeepRed,
		DeepBlue,
		DeepEmerald,
		DeepYellow,	
		Underwater		
	}

	private static Hashtable ColorValues = new Hashtable{
		{ ColorNames.WarmingFilter85 		, new Color32 (236,		138,	  0,		255		) },
		{ ColorNames.WarmingFilterLBA		, new Color32 (250,		138,	  0,		255		) },
		{ ColorNames.WarmingFilter81		, new Color32 (235,		177,	 19,		255		) },
		{ ColorNames.CoolingFilter85 		, new Color32 (  0,		109,	255,		255		) },
		{ ColorNames.CoolingFilterLBA 		, new Color32 (  0,		 93,	255,		255			) },
		{ ColorNames.CoolingFilter81 		, new Color32 (  0,		181,	255,		255		) },
		{ ColorNames.Red 					, new Color32 (234, 	 26, 	 26,   		255		) },
		{ ColorNames.Orange 				, new Color32 (244, 	132, 	 23,        255	) },
		{ ColorNames.Yellow      			, new Color32 (249, 	227, 	 28,        255	) },
		{ ColorNames.Green       			, new Color32 (	25, 	201, 	 25,        255		) },
		{ ColorNames.Cyan        			, new Color32 (	29, 	203, 	234,        255	) },
		{ ColorNames.Blue        			, new Color32 (	29, 	 53, 	234,        255		) },
		{ ColorNames.Violet      			, new Color32 (244, 	132, 	 23,        255	) },
		{ ColorNames.Magenta     			, new Color32 (155, 	 29, 	234,        255	) },
		{ ColorNames.Sepia       			, new Color32 (172, 	122, 	 51,        255	) },
		{ ColorNames.DeepRed    			, new Color32 (255, 	  0, 	  0,        255		) },
		{ ColorNames.DeepBlue   			, new Color32 (  0, 	 34, 	205,        255		) },
		{ ColorNames.DeepEmerald			, new Color32 (  0, 	141, 	  0,        255		) },
		{ ColorNames.DeepYellow			    , new Color32 (255, 	213, 	  0,        255	    ) },
		{ ColorNames.Underwater				, new Color32 (  0, 	194, 	177,        255		) }, 
	};

	public static Color32 ColorValue( ColorNames color ) {


		return (Color32) ColorValues [color];
	}

	//public static Color ColourAtIndex( ColorNames color) {
	//	return (Color) ColorValues [color];
	//}

}
