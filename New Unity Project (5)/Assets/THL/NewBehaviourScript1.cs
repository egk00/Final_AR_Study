using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript1 : MonoBehaviour {
    private bool isButtonVisible = true;
    bool showDialog;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnGUI()
    {
        DisplayButton();
    }

    void DisplayButton()
    {
        Rect buttonRect2 = new Rect(Screen.width * 0.35f, Screen.height * 0.45f, Screen.width * 0.30f, Screen.height * 0.1f);
        if (GUI.Button(buttonRect2, "Open Dialog"))
        {
            showDialog = true;
        }

        if (isButtonVisible)
        {
            Rect buttonRect = new Rect(Screen.width * 0.35f, Screen.height * 0.10f, Screen.width * 0.30f, Screen.height * 0.1f);
            if (GUI.Button(buttonRect, "Hide Me"))
            {
                isButtonVisible = false;
            }
        }

        Rect buttonRect3 = new Rect(Screen.width * 0.35f, Screen.height * 0.60f, Screen.width * 0.30f, Screen.height * 0.1f);

        if (GUI.Button(buttonRect3, "Quit"))
        {
            Application.Quit();
        }

        if (showDialog)
        {
            GUI.BeginGroup(new Rect(Screen.width / 2 - 150, 50, 300, 250));

            GUI.Box(new Rect(0, 0, 300, 250), "");

            GUI.Label(new Rect(15, 10, 300, 68), "Do you want to travel to?");

            if (GUI.Button(new Rect(55, 100, 180, 40), "Show Button"))
            {
                isButtonVisible = true;
            }

            if (GUI.Button(new Rect(55, 150, 180, 40), "Cancel"))
            {
                showDialog = false;
            }

            GUI.EndGroup();
        }
    }
}
