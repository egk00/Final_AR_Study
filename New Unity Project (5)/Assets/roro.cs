using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roro : MonoBehaviour {

    public Transform target;     
    public float dist = 100.0f;     
    public float height = 5.0f;     
    public float dampRotate = 5.0f;     
    public float TurnSpeed;
    public float camPos;

    //public float minVertical = 20.0f;
    //public float maxVertical = 85.0f;


    //Vector3 V3;

    private Transform tr;
    // Use this for initialization
    void Start()
    {
        tr = GetComponent<Transform>();
        TurnSpeed = 2f;
        camPos = 2f;
    }

    void Update()
    {
        Vector3 PositionInfo = tr.position - target.position;
        //PositionInfo = Vector3.Normalize(PositionInfo);     //너무 크면 안되니 정규화 주석해도 상관없음

        target.transform.Rotate(0, Input.GetAxis("Horizontal") * TurnSpeed, 0);

        transform.RotateAround(target.position, Vector2.right, Input.GetAxis("Mouse Y") * TurnSpeed);     //위 아래 제한을 아직 못검

        transform.RotateAround(target.position, Vector3.up, Input.GetAxis("Mouse X") * TurnSpeed);

        tr.position = tr.position - (PositionInfo * Input.GetAxis("Mouse ScrollWheel") * TurnSpeed);

        /*   위 아래 회전 조건을 걸때 아직 구현이 이상함
            static float ClampAngle(float angle, float min, float max)
            {
                if (angle < -360)
                {
                    angle += 360;
                }
                if (angle > 360)
                {
                    angle -= 360;
                }
                return Mathf.Clamp(angle, min, max);
            }*/
    }
}