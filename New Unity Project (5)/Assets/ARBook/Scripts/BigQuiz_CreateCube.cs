using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BigQuiz_CreateCube : MonoBehaviour {

    public GameObject[] CubeArray;

    public GameObject[] CreateCubeArray;

    public GameObject[] GameUI;

    //바꿀 색상
    public Material[] Quiz_Materials;
    //나의 색상
    private Material m_Material;
    //메터리얼 인덱스
    public int materialIndex = 0;

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
        if(index < (CubeArray.Length -1) )
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
        if (index > 3)
        {
            CubeArray[index].SetActive(false);
            index -= 4;
            CubeArray[index].SetActive(true);

            //소리
            ButtonAudio.PlayOneShot(ButtonSound);
        }
    }

    public void DownArrow()
    {
        //(도형 최대- 크기 증가 크기) -1(0부터 시작하는 배열)
        if (index < ((CubeArray.Length -3) -1))
        {
            CubeArray[index].SetActive(false);
            index += 4;
            CubeArray[index].SetActive(true);

            //소리
            ButtonAudio.PlayOneShot(ButtonSound);
        }
    }

    public void UpButton()
    {
        if (index <= ((CubeArray.Length - 8)-1))
        {
            CubeArray[index].SetActive(false);
            index += 8;
            CubeArray[index].SetActive(true);

            //소리
            ButtonAudio.PlayOneShot(ButtonSound);
        }
    }

    public void DownButton()
    {
        if (index >= 8)
        {
            CubeArray[index].SetActive(false);
            index -= 8;
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
            saveArray[index] = materialIndex;

            CreateCubeArray[index].SetActive(true);

            //소리
            ButtonAudio.PlayOneShot(ButtonSound);

            //메터리얼 가져오기
            CreateCubeArray[index].GetComponent<MeshRenderer>().material = Quiz_Materials[materialIndex];
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

    public void MeterialIndexOne()
    {
        //소리
        ButtonAudio.PlayOneShot(ButtonSound);

        //메터리얼 인덱스 설정
        materialIndex = 0;
    }

    public void MeterialIndexTwo()
    {
        //소리
        ButtonAudio.PlayOneShot(ButtonSound);

        //메터리얼 인덱스 설정
        materialIndex = 1;
    }

    public void MeterialIndexThree()
    {
        //소리
        ButtonAudio.PlayOneShot(ButtonSound);

        //메터리얼 인덱스 설정
        materialIndex = 2;
    }
}
