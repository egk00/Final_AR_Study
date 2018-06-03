using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour {

    //3. 슬라이스 된 과일
    public GameObject fruitSlicedPrefab;

    public float startForce = 15f;
    Rigidbody2D rb;

    //4. 회전하는 방향 및 힘
    public float torque = 5f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * startForce, ForceMode2D.Impulse);

        //Use Impulse mode as a force on the RigidBody
        rb.AddTorque(torque, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Blade")
        {
            // 4. 잘리는 방향 설정
            Vector3 direction = (collision.transform.position - transform.position).normalized;
            Quaternion rotation = Quaternion.LookRotation(direction);

            //3. 제거 하고 과일 생성
            Instantiate(fruitSlicedPrefab, gameObject.transform.position, rotation);

            //5.2 게임 매니져에서 현재의 도형 상태 찾기
            GameObject tempObj = GameObject.Find("Shape_GameManager");
            Shape_GameManager tempGM = tempObj.GetComponent<Shape_GameManager>();
            GameState ShapeState = tempGM.GS;
            //Debug.Log("도형 상태 : " + ShapeState);

            //현재 도형의 이름
            string currentShapeName = this.gameObject.name;
            //Debug.Log("도형 이름 : " + this.gameObject.name);

            //2. 블레이드 테그 충돌 시 게임 오브젝트 제거
            //Debug.Log("Destroy");
            Destroy(this.gameObject);

            //터지는 소리
            FindObjectOfType<AudioManager>().Play("Cut");

            //게임 규칙
            switch (ShapeState)
            {
                case GameState.Circle :
                    if (currentShapeName == "Circle_Prefab(Clone)")
                        tempGM.Count_Good++;
                    else if (currentShapeName == "Cone_Prefab(Clone)")
                        tempGM.Count_Good++;
                    else if (currentShapeName == "Cylinder_Prefab(Clone)")
                        tempGM.Count_Good++;
                    else if (currentShapeName == "CylinderTube_Prefab(Clone)")
                        tempGM.Count_Bed++;
                    return;
                case GameState.CircleTube:
                    if (currentShapeName == "Circle_Prefab(Clone)")
                        tempGM.Count_Bed++;
                    else if (currentShapeName == "Cone_Prefab(Clone)")
                        tempGM.Count_Bed++;
                    else if (currentShapeName == "Cylinder_Prefab(Clone)")
                        tempGM.Count_Bed++;
                    else if (currentShapeName == "CylinderTube_Prefab(Clone)")
                        tempGM.Count_Good++;
                    return;
                case GameState.Oval:
                    if (currentShapeName == "Circle_Prefab(Clone)")
                        tempGM.Count_Bed++;
                    else if (currentShapeName == "Cone_Prefab(Clone)")
                        tempGM.Count_Good++;
                    else if (currentShapeName == "Cylinder_Prefab(Clone)")
                        tempGM.Count_Good++;
                    else if (currentShapeName == "CylinderTube_Prefab(Clone)")
                        tempGM.Count_Bed++;
                    return;
                case GameState.Pause:
                    if (currentShapeName == "Circle_Prefab(Clone)")
                        tempGM.Count_Bed++;
                    else if (currentShapeName == "Cone_Prefab(Clone)")
                        tempGM.Count_Bed++;
                    else if (currentShapeName == "Cylinder_Prefab(Clone)")
                        tempGM.Count_Bed++;
                    else if (currentShapeName == "CylinderTube_Prefab(Clone)")
                        tempGM.Count_Good++;
                    return;
                case GameState.Rectangle:
                    if (currentShapeName == "Circle_Prefab(Clone)")
                        tempGM.Count_Bed++;
                    else if (currentShapeName == "Cone_Prefab(Clone)")
                        tempGM.Count_Bed++;
                    else if (currentShapeName == "Cylinder_Prefab(Clone)")
                        tempGM.Count_Good++;
                    else if (currentShapeName == "CylinderTube_Prefab(Clone)")
                        tempGM.Count_Bed++;
                    return;
                case GameState.Triangle:
                    if (currentShapeName == "Circle_Prefab(Clone)")
                        tempGM.Count_Bed++;
                    else if (currentShapeName == "Cone_Prefab(Clone)")
                        tempGM.Count_Good++;
                    else if (currentShapeName == "Cylinder_Prefab(Clone)")
                        tempGM.Count_Bed++;
                    else if (currentShapeName == "CylinderTube_Prefab(Clone)")
                        tempGM.Count_Bed++;
                    return;
            }
        }
    }
}
