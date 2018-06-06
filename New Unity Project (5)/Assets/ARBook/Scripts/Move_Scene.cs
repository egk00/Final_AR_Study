using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Move_Scene : MonoBehaviour {
    public void Move_ARStudy_Scene()
    {
        SceneManager.LoadScene("ARBook_Base");
    }

    public void GoToMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void GoToARMidAirScene()
    {
        SceneManager.LoadScene("ARQuiz");
    }
    public void GoToARExploded()
    {
        SceneManager.LoadScene("ARExploded");
    }
    public void GoToARBigQuiz()
    {
        SceneManager.LoadScene("ARBigQuiz");
    }
}
