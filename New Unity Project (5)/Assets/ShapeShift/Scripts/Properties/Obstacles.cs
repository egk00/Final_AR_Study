using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[System.Serializable]
public class Obstacles
{
    public GameObject obstacleObj;
    public bool beingUsed;
    public shape type;
    public Obstacles(GameObject obstacles, bool BeingUsed, shape Type)
    {
        obstacleObj = obstacles;
        beingUsed = BeingUsed;
        type = Type;
    }

}
