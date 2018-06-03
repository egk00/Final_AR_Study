using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static SoundManager Instance;
    public AudioSource audioSource;
    public AudioClip hitshape, gameover, collectible;
    public float volume;
    private void Awake()
    {
        Instance = this;
        audioSource = GetComponent<AudioSource>();
    }
    void Start ()
    {
        // Get audio source component
        //audioSource = GetComponent<AudioSource>();
    }
    public void PlaySound(AudioClip sound)
    {
        audioSource.PlayOneShot(sound, volume);
    }
}
