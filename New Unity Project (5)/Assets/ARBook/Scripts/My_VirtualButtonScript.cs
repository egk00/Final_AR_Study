using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class My_VirtualButtonScript : MonoBehaviour, IVirtualButtonEventHandler {

    public bool[] stateONOff;

    public GameObject[] shapeArray;

    // Use this for initialization
    void Start()
    {
        //가상 버튼
        VirtualButtonBehaviour []vrb = GetComponentsInChildren<VirtualButtonBehaviour>();
        for(int i=0; i< vrb.Length; i++)
        {
            vrb[i].RegisterEventHandler(this);
        }
        //가상 1버튼, 2버튼 상태
        stateONOff = new bool[] { false, false };


    }

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {

        if (vb.VirtualButtonName == "VBBig1" && stateONOff[0] == false)
        {
            //이전 모든것들 끄기
            for(int i=0; i<shapeArray.Length; i++)
            {
                shapeArray[i].SetActive(false);
            }
            Debug.Log("가상버튼 1 클릭");

            //전체 켜기
            shapeArray[0].SetActive(true);
            shapeArray[1].SetActive(true);
        }
        else if (vb.VirtualButtonName == "VBBig1" && stateONOff[0] == true)
        {
            //전체 끄기
            shapeArray[0].SetActive(false);
            shapeArray[1].SetActive(false);
        }
        else if (vb.VirtualButtonName == "VBBig2" && stateONOff[1] == false)
        {
            //이전 모든것들 끄기
            for (int i = 0; i < shapeArray.Length; i++)
            {
                shapeArray[i].SetActive(false);
            }
            Debug.Log("가상버튼 2 클릭");
            //UI 키기
            shapeArray[2].SetActive(true);
            shapeArray[3].SetActive(true);
        }
        else if (vb.VirtualButtonName == "VBBig2" && stateONOff[1] == true)
        {
            //UI 키기
            shapeArray[2].SetActive(false);
            shapeArray[3].SetActive(false);
        }
        else
        {
            throw new UnityException(vb.VirtualButtonName + " Virtual Button not supported");
        }
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        if (vb.VirtualButtonName == "VBBig1" && stateONOff[0] == false)
        {
            stateONOff[0] = true;
        }
        else if (vb.VirtualButtonName == "VBBig1" && stateONOff[0] == true)
        {
            stateONOff[0] = false;
        }
        if (vb.VirtualButtonName == "VBBig2" && stateONOff[1] == false)
        {
            stateONOff[1] = true;
        }
        else if (vb.VirtualButtonName == "VBBig2" && stateONOff[1] == true)
        {
            stateONOff[1] = false;
        }
        else
        {
            throw new UnityException(vb.VirtualButtonName + " Virtual Button not supported");
        }
    }

    
}
