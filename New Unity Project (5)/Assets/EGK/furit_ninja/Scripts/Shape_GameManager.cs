using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public enum GameState
{
    Circle,
    Triangle,
    Oval,
    Rectangle,
    Pause,
    CircleTube
}

public enum ShapeGameState
{
    Ready,
    Play,
    End
}



public class Shape_GameManager : MonoBehaviour {

    public GameState GS;                //게임매니져의 상태관리.

    public ShapeGameState SGS;          //게임 상태 표시

    public float LimitTime;             //게임 제한시간.

    public float delay = 3f;            //변경 시간

    public Text TimeText;               //UI 텍스트

    public GameObject[] shapes;         //shape 모양
    private GameObject currentObj;      //현재 모양

    public int Count_Bed;               //나쁜두더지를 잡은 횟수.
    public int Count_Good;              //착한 두더지를 잡은 횟수.
    public int Count_Score;             //점수

    public Text Text_Score;             //텍스트로 표시할 점수
    public Text Final_Score;            //마지막 점수

    public GameObject FinishGUI;        //결과화면을 보여주기 위한 오브젝트.

    public GameObject StartGUI;         //시작화면 GUI

    public AudioClip GoSound;           //고! 하 는경우에 플레이 할 사운드.
    public AudioClip FinishSound;       //끝나고 결과화면이 나올 경우에 플레이 할 사운드.

    private AudioSource shape_audio;

    void Start()
    {
        shape_audio = gameObject.GetComponent<AudioSource>();
    }

	public void GO(){
        //시작화면 비활성화
        StartGUI.SetActive(false);

        SGS= ShapeGameState.Play;
        shape_audio.clip = GoSound;
        shape_audio.Play();

        //처음 오브젝트를 원형으로 한다.
        currentObj = shapes[0];
        currentObj.SetActive(true);
        StartCoroutine(SpawnShapes());
    }

    void End()
    {
        SGS = ShapeGameState.End;
        FinishGUI.SetActive(true);
        Final_Score.text = string.Format("{0}", Count_Score);
        shape_audio.clip = FinishSound;
        shape_audio.Play();
    }

    void Update()
    {
        if (SGS == ShapeGameState.Play)
        {
            LimitTime -= Time.deltaTime;
            if (LimitTime <= 0)
            {
                LimitTime = 0;
				//게임이 끝나는 시점.
				End();
            }
        }
        TimeText.text = string.Format("{0:N2}", LimitTime);

        //점수 매기기
        Count_Score = Count_Good * 10 - Count_Bed * 100;
        Text_Score.text = Count_Score.ToString();
    }



    // 코루틴 함수 적용
    IEnumerator SpawnShapes()
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);

            // 다양한 도형을 스폰합니다.
            int ShapeIndex = Random.Range(0, shapes.Length);

            //도형 이름 설정
            switch (ShapeIndex)
            {
                case 0:
                    GS = GameState.Circle;
                    //이전 도형 끄기
                    currentObj.SetActive(false);
                    //세로운 도형 켜기
                    currentObj = shapes[ShapeIndex];
                    currentObj.SetActive(true);
                    break;
                case 1:
                    GS = GameState.CircleTube;
                    //이전 도형 끄기
                    currentObj.SetActive(false);
                    //세로운 도형 켜기
                    currentObj = shapes[ShapeIndex];
                    currentObj.SetActive(true);
                    break;
                case 2:
                    GS = GameState.Oval;
                    currentObj.SetActive(false);
                    //세로운 도형 켜기
                    currentObj = shapes[ShapeIndex];
                    currentObj.SetActive(true);
                    break;
                case 3:
                    GS = GameState.Pause;
                    currentObj.SetActive(false);
                    //세로운 도형 켜기
                    currentObj = shapes[ShapeIndex];
                    currentObj.SetActive(true);
                    break;
                case 4:
                    GS = GameState.Rectangle;
                    currentObj.SetActive(false);
                    //세로운 도형 켜기
                    currentObj = shapes[ShapeIndex];
                    currentObj.SetActive(true);
                    break;
                case 5:
                    GS = GameState.Triangle;
                    currentObj.SetActive(false);
                    //세로운 도형 켜기
                    currentObj = shapes[ShapeIndex];
                    currentObj.SetActive(true);
                    break;
            }
        }
    }
}
