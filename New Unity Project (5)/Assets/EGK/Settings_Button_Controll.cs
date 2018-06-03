using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings_Button_Controll : MonoBehaviour {

    public GameObject Settings_Panel;

    public static bool On_Off_Bool = false;

    public void Settings_Button_Click()
    {
        if(On_Off_Bool)
        {
            On_Off_Bool = false;
            Settings_Panel.SetActive(false);
        }
        else
        {
            On_Off_Bool = true;
            Settings_Panel.SetActive(true);
            
        }
    }
}
