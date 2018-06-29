using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoadingScreen : MonoBehaviour 
{
    #region PRIVATE_MEMBER_VARIABLES
    private bool mChangeLevel = true;
    //private RawImage mUISpinner;
	public RawImage spinner;
    #endregion // PRIVATE_MEMBER_VARIABLES


    #region MONOBEHAVIOUR_METHODS
    void Start () 
    {
        //mUISpinner = FindSpinnerImage();
        Application.backgroundLoadingPriority = ThreadPriority.Low;
        mChangeLevel = true;
    }
    
    void Update () 
    {
		spinner.rectTransform.Rotate(Vector3.forward, 90.0f * Time.deltaTime);

        if (mChangeLevel)
        {
            LoadNextSceneAsync();
            mChangeLevel = false;
        }
    }
    #endregion // MONOBEHAVIOUR_METHODS


    #region PRIVATE_METHODS
    private void LoadNextSceneAsync()
    {
#if (UNITY_5_2 || UNITY_5_1 || UNITY_5_0)
        Application.LoadLevelAsync(Application.loadedLevel+1);
#else // UNITY_5_3 or above
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex+1);
#endif
    }

    //private RawImage FindSpinnerImage()
    //{
    //    RawImage[] images = FindObjectsOfType<RawImage>();
    //    foreach (var img in images)
    //    {
    //        if (img.name.Contains("Spinner"))
    //        {
    //            return img;
    //        }
    //    }
    //    return null;
    //}
    #endregion // PRIVATE_METHODS
}