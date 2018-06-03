using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjColor : MonoBehaviour
{
    public static GameObjColor Instance;
    public Color [] obstaclecolors;
    public Color[] shapecolor;
    public Color[] backgroundcolor;
    private int color;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        InvokeRepeating("changebackgroundcolors", 0, 10);
    }
    public void obstaclecolor(GameObject obstacle)
    {
       obstacle.gameObject.GetComponent<Renderer>().material.SetColor("_Color", obstaclecolors[Random.Range(0, obstaclecolors.Length)]);
    }
    private void changebackgroundcolors()
    {
        color = Random.Range(0, backgroundcolor.Length);
        CameraController.Instance.maincamera.backgroundColor = backgroundcolor[color];
    }
    public void setshapecolor()
    {
        for(int x = 0; x < InfiniteGameObjManager.Instance.inGameObstacleSpawnIndex.Count; x++)
        {
            SaveLoad.Instance.shapes[InfiniteGameObjManager.Instance.inGameObstacleSpawnIndex[x]].ShapeObj.gameObject.GetComponent<Renderer>().material.SetColor("_Color", shapecolor[Random.Range(0, shapecolor.Length)]);
        }
       
    }

}
