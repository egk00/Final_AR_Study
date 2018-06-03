using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mOnClick : MonoBehaviour {

    public void OnClick1()
    {
        Restart();
        Time.timeScale = 0;
    }

    public void OnClick2()
    {
    
        
        Restart();
        Time.timeScale = 1;
        
    }

    public void Restart()
    {
        SceneManager.LoadScene("test11");
    }
}
