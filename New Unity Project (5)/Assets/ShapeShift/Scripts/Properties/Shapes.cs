using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum shape
{
    Cube, Sphere, Triangularprism, l, Cone, Cuboid , Torus , Diamond , Hexagonalprism, Hemisphere// shape names
}
//[System.Serializable]
public class Shapes
{
    public GameObject ShapeObj;
    public shape type;
    public bool beingUsed;
    public Shapes(GameObject shapeObj, shape Type , bool BeingUsed)
    {
        ShapeObj = shapeObj;
        type = Type;
        beingUsed = BeingUsed;

    }
}
