using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround : MonoBehaviour {

    //이동할 회전축
    Transform Rotating_Axis;

    Vector3 velocity;

    int flag;

    // Use this for initialization
    void Start () {
        //회전축을 찾는다.
        Rotating_Axis = GameObject.Find("A_Rotating_Axis").transform;

        //velocity 속도 생성
        velocity = new Vector3(0,0.5f,0);

        flag = 0;
	}

    public void Click_Btn()
    {
        if (flag == 0)
        {
            flag = 1;
            Rotate_Shape();
        }
        else
        {
            flag = 0;
            CancelInvoke();
        }
    }

    //코루틴 사용a
    public void Rotate_Shape()
    {
        //회전축, 어떻게 돌을 것인가, 속도
        transform.RotateAround(Rotating_Axis.position, velocity, 1000 * Time.deltaTime);
        Invoke("Rotate_Shape", 0.1f);
    }

    // Update is called once per frame
    void Update () {
    }
}
