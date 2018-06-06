using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCube : MonoBehaviour {

    public GameObject[] CubeArray;

    public GameObject[] CreateCubeArray;

    public GameObject[] GameUI;

    int index = 0;

    public int[] saveArray;

    public int[] ResultArray;

    public bool ClickState = false;

    //오디오 설정
    public AudioSource ButtonAudio;
    public AudioClip ButtonSound;

    // Use this for initialization
    void Start () {
        saveArray = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0,};

        //9, 19, 29 ,39
        ResultArray = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 1, 1, 1, 1, 0, 0, 1,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 1,
        0, 1, 1, 0, 0, 1, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 1, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0,};
    }
	

    public void LeftArrow()
    {
        if(index > 0)
        {
            CubeArray[index].SetActive(false);
            index -= 1;
            CubeArray[index].SetActive(true);

            //소리
            ButtonAudio.PlayOneShot(ButtonSound);
        } 
    }

    public void RightArrow()
    {
        if(index < (CubeArray.Length-1))
        {
            CubeArray[index].SetActive(false);
            index += 1;
            CubeArray[index].SetActive(true);

            //소리
            ButtonAudio.PlayOneShot(ButtonSound);
        } 
    }

    public void UpArrow()
    {
        if (index > 5)
        {
            CubeArray[index].SetActive(false);
            index -= 6;
            CubeArray[index].SetActive(true);

            //소리
            ButtonAudio.PlayOneShot(ButtonSound);
        }
    }

    public void DownArrow()
    {
        if (index < (CubeArray.Length-1))
        {
            CubeArray[index].SetActive(false);
            index += 6;
            CubeArray[index].SetActive(true);

            //소리
            ButtonAudio.PlayOneShot(ButtonSound);
        }
    }

    public void UpButton()
    {
        if (index <= 71)
        {
            CubeArray[index].SetActive(false);
            index += 36;
            CubeArray[index].SetActive(true);

            //소리
            ButtonAudio.PlayOneShot(ButtonSound);
        }
    }

    public void DownButton()
    {
        if (index >= 36)
        {
            CubeArray[index].SetActive(false);
            index -= 36;
            CubeArray[index].SetActive(true);

            //소리
            ButtonAudio.PlayOneShot(ButtonSound);
        }
    }

    public void ClickButton()
    {
        if(ClickState == false)
        {
            ClickState = true;
            saveArray[index] = 1;

            CreateCubeArray[index].SetActive(true);

            //소리
            ButtonAudio.PlayOneShot(ButtonSound);
        }

        else
        {
            ClickState = false;
            saveArray[index] = 0;

            CreateCubeArray[index].SetActive(false);

            //소리
            ButtonAudio.PlayOneShot(ButtonSound);
        }
        
    }

    public void Submit()
    {
        bool confirm = true;
        for(int i=0; i< ResultArray.Length; i++)
        {
            if(saveArray[i] != ResultArray[i])
            {
                confirm = false;
            }
        }

        if(confirm == true)
        {
            Debug.Log("맞다");
            GameUI[0].SetActive(true);
        }
        else
        {
            Debug.Log("틀리다");
            GameUI[1].SetActive(true);

        }

        //소리
        ButtonAudio.PlayOneShot(ButtonSound);
    }
}
