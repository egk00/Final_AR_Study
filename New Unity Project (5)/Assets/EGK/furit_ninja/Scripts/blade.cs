using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blade : MonoBehaviour {

    //5. 칼 잔상 프리팹
    public GameObject bladeTrailPrefab;

    
    GameObject currentBladeTrail;

    //2. 마우스 상태를 저장하는 bool 변수 up일 경우 false down일 경우 
    bool isCutting = false;

    //8. 이전 위치 벡터
    Vector2 previousPosition;
    public float minCuttingVelocity = .001f;

    //3. 마우스의 위치로 이동시키기 위해 Rigidbody와 World의 위치를 찾기 위해 Camera 변수 선언
    Rigidbody2D rb;
    Camera cam;

    //7. 칼날이 적용할 콜라이더 생성
    CircleCollider2D circleCollider;

    private void Start()
    {
        //3. 카메라를 메인 카메라로, rb를 자신의 Rigidbody로 설정
        cam = Camera.main;
        rb = GetComponent<Rigidbody2D>();

        //7. 칼날의 콜라이더 찾기
        circleCollider = GetComponent<CircleCollider2D>();
    }

    
    void Update () {
        //1. 왼쪽 마우스 Down 시 자르기 시작 Up일경우 중단 
		if(Input.GetMouseButtonDown(0))
        {
            StartCutting();
        } else if (Input.GetMouseButtonUp(0))
        {
            StopCutting();
        }

        //3. 현재 왼쪽 마우스가 Down 상태일 경우 진행
        if (isCutting)
        {
            UpdateCut();
        }
	}

    void StartCutting()
    {
        //2. 현재 왼쪽 마우스 Down으로 누를 시 IsCutting을 true로 저장
        isCutting = true;

        //10. 위치로 이동
        Vector2 newPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        transform.position = newPosition;

        //5. 칼 잔상 프리 팹을 인스턴스로 만들어 위치 시킴
        currentBladeTrail = Instantiate(bladeTrailPrefab, transform);
        
        //7. 콜라이더 적용
        circleCollider.enabled = true;

        //9. 처음 CutTrail을 만들때 위치 마우스 위치로 초기화 
        previousPosition = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    void StopCutting()
    {
        //2. 현재 왼쪽 마우스가 Down으로 누를 시 IsCutting을 false로 저장
        isCutting = false;

        //5. 부모로부터 변환을 분리한다.
        currentBladeTrail.transform.SetParent(null);

        //6. 2초뒤 제거
        Destroy(currentBladeTrail, 2f);

        //7. 콜라이더 끄기
        circleCollider.enabled = false;
    }

    void UpdateCut()
    {
        //3. 카메라에서 본 World 좌표를 저장 후 rb.postion에 설정
        Vector2 newPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        rb.position = newPosition;

        //8. 자르기 속도가 더 크다 면 칼의 콜라이더 활성화 아닐경우 비 활성화
        float velocity = (newPosition - previousPosition).magnitude * Time.deltaTime;
        if(velocity > minCuttingVelocity)
        {
            circleCollider.enabled = true;
        }
        else
        {
            circleCollider.enabled = false;
        }
        previousPosition = newPosition;
    }
}
