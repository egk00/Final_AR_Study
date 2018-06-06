using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ARVideo_Cylinder : MonoBehaviour, IVirtualButtonEventHandler {

    public GameObject CylinderVD;

    public bool stateONOff = false;

    public GameObject[] shapeArray;
    public GameObject ARUI;

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        if (vb.VirtualButtonName == "CylinderVB" && stateONOff == false)
        {
            CylinderVD.SetActive(true);

            //이전 모든것들 끄기
            for(int i=0; i<shapeArray.Length; i++)
            {
                shapeArray[i].SetActive(false);
            }
            //UI 끄기
            ARUI.SetActive(false);
        }
        else if (vb.VirtualButtonName == "CylinderVB" && stateONOff == true)
        {
            CylinderVD.SetActive(false);
            //UI 키기
            ARUI.SetActive(true);
        } else
        {
            throw new UnityException(vb.VirtualButtonName + " Virtual Button not supported");
        }
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        if (vb.VirtualButtonName == "CylinderVB" && stateONOff == false)
        {
            stateONOff = true;
        }
        else if (vb.VirtualButtonName == "CylinderVB" && stateONOff == true)
        {
            stateONOff = false;
        }
        else
        {
            throw new UnityException(vb.VirtualButtonName + " Virtual Button not supported");
        }
    }

    // Use this for initialization
    void Start () {
        CylinderVD.SetActive(false);

        //가상 버튼
        VirtualButtonBehaviour vrb = GetComponentInChildren<VirtualButtonBehaviour>();
        vrb.RegisterEventHandler(this);

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
