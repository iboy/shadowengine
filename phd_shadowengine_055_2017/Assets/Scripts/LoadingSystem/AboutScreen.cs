using UnityEngine;
using System.Collections;

public class AboutScreen : MonoBehaviour
{
    #region PUBLIC_METHODS
	public void OnStartShadowEngine()
    {
      
#if (UNITY_5_2 || UNITY_5_1 || UNITY_5_0)
        Application.LoadLevel("ShadowEngine-2-Loading");
#else // UNITY_5_3 or above
		UnityEngine.SceneManagement.SceneManager.LoadScene("ShadowEngine-2-Loading");
#endif
    }
    #endregion // PUBLIC_METHODS


    #region MONOBEHAVIOUR_METHODS
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Return))
        {
            // Treat 'Return' key as pressing the Close button and dismiss the About Screen
			OnStartShadowEngine();
        }
        else if (Input.GetKeyUp(KeyCode.JoystickButton0))
        {
            // Similar to above except detecting the first Joystick button
            // Allows external controllers to dismiss the About Screen
            // On an ODG R7 this is the select button
            OnStartShadowEngine();
        }
        else if (Input.GetKeyUp(KeyCode.Escape))
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        }
    }
    #endregion // MONOBEHAVIOUR_METHODS
}