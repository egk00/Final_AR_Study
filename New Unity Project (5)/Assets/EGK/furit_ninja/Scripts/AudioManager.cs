using UnityEngine.Audio;
using System; //람다식을 사용하기 위해 사용
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public Sound[] sounds;

    //Audio
    public static AudioManager instance;

	//Sound Play function, start method와 비슷하다.
    void Awake()
    {
        // ??
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loof;
        }
    }

    private void Start()
    {
        Play("Theme");
    }

    public void Play (string name)
    {
        Sound s = Array.Find(sounds, sounds => sounds.name == name);

        //예외 처리 소리 이름을 찾을수 없을 경우
        if (s == null)
        {
            Debug.LogWarning("Sound : " + name + " not found!");
            return;
        }
            

        s.source.Play();
    }
}
