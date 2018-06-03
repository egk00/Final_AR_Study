using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeOnOff : MonoBehaviour {

    public GameObject[] Shapes;
    //현재 클릭중 인 도형 저장
    int ShapeIndex = 0;

    //오디오 소스
    public AudioSource ARBookAudioSource;
    //오디오 클립
    public AudioClip [] audioClipArray;

    //도형 상태 0 중지 1 위로 회전 2 우회전
    public int shapeState = 0;

    public void PyramidTriOn()
    {
        //클릭 중인 도형 1
        ShapeIndex = 0;
        Shapes[0].SetActive(true);
        Shapes[1].SetActive(false);
        Shapes[2].SetActive(false);

        if(Shapes.Length >= 4)
            Shapes[3].SetActive(false);

        if (Shapes.Length >= 5)
            Shapes[4].SetActive(false);

        //클릭 소리
        ARBookAudioSource.PlayOneShot(audioClipArray[0]);
    }

    public void PyramidOn()
    {
        //클릭 중인 도형 2
        ShapeIndex = 1;

        Shapes[0].SetActive(false);
        Shapes[1].SetActive(true);
        Shapes[2].SetActive(false);

        if (Shapes.Length >= 4)
            Shapes[3].SetActive(false);

        if (Shapes.Length >= 5)
            Shapes[4].SetActive(false);

        //클릭 소리
        ARBookAudioSource.PlayOneShot(audioClipArray[0]);
    }

    public void CubeOn()
    {
        //클릭 중인 도형 3
        ShapeIndex = 2;

        Shapes[0].SetActive(false);
        Shapes[1].SetActive(false);
        Shapes[2].SetActive(true);

        if (Shapes.Length >= 4)
            Shapes[3].SetActive(false);

        if (Shapes.Length >= 5)
            Shapes[4].SetActive(false);

        //클릭 소리
        ARBookAudioSource.PlayOneShot(audioClipArray[0]);
    }

    public void ShapeOnOF4()
    {
        //클릭 중인 도형 4
        ShapeIndex = 3;

        Shapes[0].SetActive(false);
        Shapes[1].SetActive(false);
        Shapes[2].SetActive(false);

        if (Shapes.Length >= 4)
            Shapes[3].SetActive(true);

        if (Shapes.Length >= 5)
            Shapes[4].SetActive(false);

        //클릭 소리
        ARBookAudioSource.PlayOneShot(audioClipArray[0]);
    }

    public void ShapeOnOF5()
    {
        //클릭 중인 도형 4
        ShapeIndex = 4;

        Shapes[0].SetActive(false);
        Shapes[1].SetActive(false);
        Shapes[2].SetActive(false);

        if (Shapes.Length >= 4)
            Shapes[3].SetActive(false);

        if (Shapes.Length >= 5)
            Shapes[4].SetActive(true);

        //클릭 소리
        ARBookAudioSource.PlayOneShot(audioClipArray[0]);
    }

    public void TurnUp()
    {
        //클릭 소리
        ARBookAudioSource.PlayOneShot(audioClipArray[0]);

        shapeState = 1;
    }

    public void TurnRight()
    {
        //클릭 소리
        ARBookAudioSource.PlayOneShot(audioClipArray[0]);

        shapeState = 2;
    }

    public void TurnStop()
    {
        //클릭 소리
        ARBookAudioSource.PlayOneShot(audioClipArray[0]);

        shapeState = 0;
    }

    public void DescriptionSound()
    {
        //클릭 소리
        ARBookAudioSource.PlayOneShot(audioClipArray[0]);
        //설명 설명 시작
        ARBookAudioSource.PlayOneShot(audioClipArray[1]);
    }



    private void Update()
    {
        Vector3 turnUpVector3 = new Vector3(30, 0, 0);
        Vector3 turnRightVector3 = new Vector3(0, 30, 0);
        if (shapeState == 1)
        {
            Shapes[ShapeIndex].transform.Rotate(turnUpVector3 * Time.deltaTime);
        }
        else if(shapeState == 2)
        {
            Shapes[ShapeIndex].transform.Rotate(turnRightVector3 * Time.deltaTime);
        }
    }

}
