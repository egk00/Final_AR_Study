using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//이미 사용하기
using UnityEngine.UI;

public class ExplationOnOff : MonoBehaviour
{

    public GameObject[] Shapes;
    //현재 클릭중 인 도형 저장
    int ShapeIndex = 0;

    //오디오 소스
    public AudioSource ARBookAudioSource;
    //오디오 클립
    public AudioClip[] audioClipArray;

    //도형 상태 0 중지 1 위로 회전 2 우회전
    public int shapeState = 0;

    //클릭 상태 false 클릭 o, true 클릭 x
    public bool clickOnOff = false;

    //버튼
    public GameObject[] Alpha;

    //알파벳 버튼 클릭 ONOff
    public bool[] AlphaOnOff;

    //답안 저장
    public int[] SaveArray;

    public int[] answer;

    private void Start()
    {
        SaveArray = new int[Shapes.Length];
        answer = new int[] { 1, 0, 1, 0, 0, 0, 1, 0 };
        AlphaOnOff = new bool[] { false, false, false, false, false, false, false, false };
    }

    public GameObject[] FinshUI;

    public void ExA()
    {
        ShapeIndex = 0;

        if (clickOnOff == false)
        {
            //클릭 중인 도형 1

            Shapes[0].SetActive(true);
            Shapes[1].SetActive(false);
            Shapes[2].SetActive(false);
            Shapes[3].SetActive(false);
            Shapes[4].SetActive(false);
            Shapes[5].SetActive(false);
            Shapes[6].SetActive(false);
            Shapes[7].SetActive(false);


        }
        else
        {
            //이미지 컨포넌트 가져오기
            Image m_image = Alpha[ShapeIndex].GetComponent<Image>();
            //버튼 ON Off확인 후 색상 변경
            if (AlphaOnOff[ShapeIndex] == false)
            {
                //이미지 색상 변경
                m_image.color = Color.green;
                SaveArray[ShapeIndex] = 1;
                AlphaOnOff[ShapeIndex] = true;
            }
            else
            {
                //이미지 색상 변경
                m_image.color = new Color32(22, 47, 255, 255);
                SaveArray[ShapeIndex] = 0;
                AlphaOnOff[ShapeIndex] = false;
            }
        }

        //클릭 소리
        ARBookAudioSource.PlayOneShot(audioClipArray[0]);
    }

    public void ExB()
    {
        ShapeIndex = 1;

        if (clickOnOff == false)
        {
            //클릭 중인 도형 2
            Shapes[0].SetActive(false);
            Shapes[1].SetActive(true);
            Shapes[2].SetActive(false);
            Shapes[3].SetActive(false);
            Shapes[4].SetActive(false);
            Shapes[5].SetActive(false);
            Shapes[6].SetActive(false);
            Shapes[7].SetActive(false);
        }
        else
        {
            //이미지 컨포넌트 가져오기
            Image m_image = Alpha[ShapeIndex].GetComponent<Image>();
            //버튼 ON Off확인 후 색상 변경
            if (AlphaOnOff[ShapeIndex] == false)
            {
                //이미지 색상 변경
                m_image.color = Color.green;
                SaveArray[ShapeIndex] = 1;
                AlphaOnOff[ShapeIndex] = true;
            }
            else
            {
                //이미지 색상 변경
                m_image.color = new Color32(22, 47, 255, 255);
                SaveArray[ShapeIndex] = 0;
                AlphaOnOff[ShapeIndex] = false;
            }
        }

        //클릭 소리
        ARBookAudioSource.PlayOneShot(audioClipArray[0]);
    }

    public void ExC()
    {
        ShapeIndex = 2;

        if (clickOnOff == false)
        {
            //클릭 중인 도형 3
            Shapes[0].SetActive(false);
            Shapes[1].SetActive(false);
            Shapes[2].SetActive(true);
            Shapes[3].SetActive(false);
            Shapes[4].SetActive(false);
            Shapes[5].SetActive(false);
            Shapes[6].SetActive(false);
            Shapes[7].SetActive(false);
        }
        else
        {
            //이미지 컨포넌트 가져오기
            Image m_image = Alpha[ShapeIndex].GetComponent<Image>();
            //버튼 ON Off확인 후 색상 변경
            if (AlphaOnOff[ShapeIndex] == false)
            {
                //이미지 색상 변경
                m_image.color = Color.green;
                SaveArray[ShapeIndex] = 1;
                AlphaOnOff[ShapeIndex] = true;
            }
            else
            {
                //이미지 색상 변경
                m_image.color = new Color32(22, 47, 255, 255);
                SaveArray[ShapeIndex] = 0;
                AlphaOnOff[ShapeIndex] = false;
            }
        }

        //클릭 소리
        ARBookAudioSource.PlayOneShot(audioClipArray[0]);
    }

    public void ExD()
    {
        ShapeIndex = 3;

        if (clickOnOff == false)
        {
            //클릭 중인 도형 4
            Shapes[0].SetActive(false);
            Shapes[1].SetActive(false);
            Shapes[2].SetActive(false);
            Shapes[3].SetActive(true);
            Shapes[4].SetActive(false);
            Shapes[5].SetActive(false);
            Shapes[6].SetActive(false);
            Shapes[7].SetActive(false);
        }
        else
        {
            //이미지 컨포넌트 가져오기
            Image m_image = Alpha[ShapeIndex].GetComponent<Image>();
            //버튼 ON Off확인 후 색상 변경
            if (AlphaOnOff[ShapeIndex] == false)
            {
                //이미지 색상 변경
                m_image.color = Color.green;
                SaveArray[ShapeIndex] = 1;
                AlphaOnOff[ShapeIndex] = true;
            }
            else
            {
                //이미지 색상 변경
                m_image.color = new Color32(22, 47, 255, 255);
                SaveArray[ShapeIndex] = 0;
                AlphaOnOff[ShapeIndex] = false;
            }
        }

        //클릭 소리
        ARBookAudioSource.PlayOneShot(audioClipArray[0]);
    }

    public void ExE()
    {
        //클릭 중인 도형 5
        ShapeIndex = 4;

        if (clickOnOff == false)
        {
            Shapes[0].SetActive(false);
            Shapes[1].SetActive(false);
            Shapes[2].SetActive(false);
            Shapes[3].SetActive(false);
            Shapes[4].SetActive(true);
            Shapes[5].SetActive(false);
            Shapes[6].SetActive(false);
            Shapes[7].SetActive(false);
        }
        else
        {
            //이미지 컨포넌트 가져오기
            Image m_image = Alpha[ShapeIndex].GetComponent<Image>();
            //버튼 ON Off확인 후 색상 변경
            if (AlphaOnOff[ShapeIndex] == false)
            {
                //이미지 색상 변경
                m_image.color = Color.green;
                SaveArray[ShapeIndex] = 1;
                AlphaOnOff[ShapeIndex] = true;
            }
            else
            {
                //이미지 색상 변경
                m_image.color = new Color32(22, 47, 255, 255);
                SaveArray[ShapeIndex] = 0;
                AlphaOnOff[ShapeIndex] = false;
            }
        }

        //클릭 소리
        ARBookAudioSource.PlayOneShot(audioClipArray[0]);
    }

    public void ExF()
    {
        //클릭 중인 도형 6
        ShapeIndex = 5;

        if (clickOnOff == false)
        {
            Shapes[0].SetActive(false);
            Shapes[1].SetActive(false);
            Shapes[2].SetActive(false);
            Shapes[3].SetActive(false);
            Shapes[4].SetActive(false);
            Shapes[5].SetActive(true);
            Shapes[6].SetActive(false);
            Shapes[7].SetActive(false);
        }
        else
        {
            //이미지 컨포넌트 가져오기
            Image m_image = Alpha[ShapeIndex].GetComponent<Image>();
            //버튼 ON Off확인 후 색상 변경
            if (AlphaOnOff[ShapeIndex] == false)
            {
                //이미지 색상 변경
                m_image.color = Color.green;
                SaveArray[ShapeIndex] = 1;
                AlphaOnOff[ShapeIndex] = true;
            }
            else
            {
                //이미지 색상 변경
                m_image.color = new Color32(22, 47, 255, 255);
                SaveArray[ShapeIndex] = 0;
                AlphaOnOff[ShapeIndex] = false;
            }
        }

        //클릭 소리
        ARBookAudioSource.PlayOneShot(audioClipArray[0]);
    }

    public void ExG()
    {
        //클릭 중인 도형 7
        ShapeIndex = 6;

        if (clickOnOff == false)
        {
            Shapes[0].SetActive(false);
            Shapes[1].SetActive(false);
            Shapes[2].SetActive(false);
            Shapes[3].SetActive(false);
            Shapes[4].SetActive(false);
            Shapes[5].SetActive(false);
            Shapes[6].SetActive(true);
            Shapes[7].SetActive(false);
        }
        else
        {
            //이미지 컨포넌트 가져오기
            Image m_image = Alpha[ShapeIndex].GetComponent<Image>();
            //버튼 ON Off확인 후 색상 변경
            if (AlphaOnOff[ShapeIndex] == false)
            {
                //이미지 색상 변경
                m_image.color = Color.green;
                SaveArray[ShapeIndex] = 1;
                AlphaOnOff[ShapeIndex] = true;
            }
            else
            {
                //이미지 색상 변경
                m_image.color = new Color32(22, 47, 255, 255);
                SaveArray[ShapeIndex] = 0;
                AlphaOnOff[ShapeIndex] = false;
            }
        }

        //클릭 소리
        ARBookAudioSource.PlayOneShot(audioClipArray[0]);
    }

    public void ExH()
    {
        //클릭 중인 도형 8
        ShapeIndex = 7;

        if (clickOnOff == false)
        {
            Shapes[0].SetActive(false);
            Shapes[1].SetActive(false);
            Shapes[2].SetActive(false);
            Shapes[3].SetActive(false);
            Shapes[4].SetActive(false);
            Shapes[5].SetActive(false);
            Shapes[6].SetActive(false);
            Shapes[7].SetActive(true);
        }
        else
        {
            //이미지 컨포넌트 가져오기
            Image m_image = Alpha[ShapeIndex].GetComponent<Image>();
            //버튼 ON Off확인 후 색상 변경
            if (AlphaOnOff[ShapeIndex] == false)
            {
                //이미지 색상 변경
                m_image.color = Color.green;
                SaveArray[ShapeIndex] = 1;
                AlphaOnOff[ShapeIndex] = true;
            }
            else
            {
                //이미지 색상 변경
                m_image.color = new Color32(22, 47, 255, 255);
                SaveArray[ShapeIndex] = 0;
                AlphaOnOff[ShapeIndex] = false;
            }
        }

        //클릭 소리
        ARBookAudioSource.PlayOneShot(audioClipArray[0]);
    }


    public void TurnUp()
    {
        //클릭 소리
        ARBookAudioSource.PlayOneShot(audioClipArray[0]);

        shapeState = 1;
    }

    public void TurnRight()
    {
        //클릭 소리
        ARBookAudioSource.PlayOneShot(audioClipArray[0]);

        shapeState = 2;
    }

    public void TurnStop()
    {
        //클릭 소리
        ARBookAudioSource.PlayOneShot(audioClipArray[0]);

        shapeState = 0;
    }

    public void Click()
    {
        //클릭 소리
        ARBookAudioSource.PlayOneShot(audioClipArray[0]);

        //이미지 컨포넌트 가져오기
        Image m_image = Alpha[8].GetComponent<Image>();

        //클릭 상태 변환
        if (clickOnOff == false)
        {
            clickOnOff = true;

            m_image.color = Color.green;
        }

        else
        {
            clickOnOff = false;
            //이미지 색상 변경
            m_image.color = new Color32(22, 47, 255, 255);
        }
    }

    public void Submit()
    {
        bool result = true;
        for(int i=0; i< Shapes.Length; i++)
        {
            if(SaveArray[i] != answer[i])
            {
                result = false;
            }
        }
        if(result == true)
        {
            //UI 띄운다.
            //Debug.Log("성공");
            FinshUI[1].SetActive(true);
        }
        else
        {
            //UI 지운다.
            Debug.Log("실패");
            FinshUI[0].SetActive(true);
        }
    }



    private void Update()
    {
        Vector3 turnUpVector3 = new Vector3(30, 0, 0);
        Vector3 turnRightVector3 = new Vector3(0, 30, 0);
        if (shapeState == 1)
        {
            Shapes[ShapeIndex].transform.Rotate(turnUpVector3 * Time.deltaTime);
        }
        else if (shapeState == 2)
        {
            Shapes[ShapeIndex].transform.Rotate(turnRightVector3 * Time.deltaTime);
        }
    }

}
