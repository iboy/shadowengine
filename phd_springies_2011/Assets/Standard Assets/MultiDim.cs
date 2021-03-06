// Declaring multi-dimensional arrays doesn't work in JS (as of Unity 3.1 anyway), so this C# class only exists to be called by JS scripts
// when multi-dim arrays need to be declared (which is accomplished using type inference).

using UnityEngine;

public class MultiDim {
	public static int[][] JaggedInt (int a) {
		return new int[a][];
	}

	public static float[][] JaggedFloat (int a) {
		return new float[a][];
	}
	
	public static string[][] JaggedString (int a) {
		return new string[a][];
	}
	
	public static Vector2[][] JaggedVector2 (int a) {
		return new Vector2[a][];
	}
	
	public static Vector3[][] JaggedVector3 (int a) {
		return new Vector3[a][];
	}
}