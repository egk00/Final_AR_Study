using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {

    private GameObject tempObj; //게임 오브젝트

    private Shape_GameManager tmeGM; // 게임 메니져

    public int count_Score = 0;

    // Use this for initialization
    void Start () {
        tempObj = GameObject.Find("Shape_GameManager");
        tmeGM = tempObj.GetComponent<Shape_GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
        count_Score = tmeGM.Count_Good * 100 - tmeGM.Count_Bed * 10;

    }
}
