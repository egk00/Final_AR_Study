using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIOnOff : MonoBehaviour {

    public GameObject[] GameUI_G;

    //오디오 소스
    public AudioSource ARBookAudioSource;
    //오디오 클립
    public AudioClip [] audioClipArray;


    public void OneUI()
    {
        GameUI_G[0].SetActive(true);
        GameUI_G[1].SetActive(true);
        GameUI_G[2].SetActive(false);
        GameUI_G[3].SetActive(false);

        //클릭 소리
        ARBookAudioSource.PlayOneShot(audioClipArray[0]);
    }

    public void TwoUI()
    {
        GameUI_G[0].SetActive(false);
        GameUI_G[1].SetActive(false);
        GameUI_G[2].SetActive(true);
        GameUI_G[3].SetActive(true);
        //클릭 소리
        ARBookAudioSource.PlayOneShot(audioClipArray[0]);
    }
}
