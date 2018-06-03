using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour {
    public void GoToSceneLTH1 ()
    {
        SceneManager.LoadScene("THL1");
    }
    public void GoToSceneLTH2()
    {
        SceneManager.LoadScene("THL2");
    }
    public void GoToSceneSHC1()
    {
        SceneManager.LoadScene("SWC1");
    }
    public void GoToSceneSHC2()
    {
        SceneManager.LoadScene("SWC2");
    }
    public void GoToSceneSHC3()
    {
        SceneManager.LoadScene("SWC3");
    }
    public void GoToSceneEGK1()
    {
        SceneManager.LoadScene("EGK1");
    }
    public void GoToSceneEGK2()
    {
        SceneManager.LoadScene("EGK2");
    }
}
