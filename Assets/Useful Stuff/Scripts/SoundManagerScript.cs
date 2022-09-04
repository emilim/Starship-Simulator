using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip engineSound;
    
    public static AudioClip btClick;
    static AudioSource audioSrc;

    void Start()
    {
        engineSound = Resources.Load<AudioClip>("StarshipSound");
        btClick = Resources.Load<AudioClip>("clickButton");
        audioSrc = GetComponent<AudioSource>();
    }
    public void btClicked()
    {
        audioSrc.clip = btClick;
        audioSrc.Play();
    }
    public static void playEngineSound(float volume)
    {
        if (!isExploded)
        {
            audioSrc.volume = volume;
            audioSrc.PlayOneShot(engineSound);
            t = false;
        }
    }
    static bool t = false;
    public static void stopplaySound()
    {
        if (t == false)
        {
            audioSrc.Stop();
            t = true;
        }    
    }
    static bool isExploded = false;
    public static void exploded()
    {
        audioSrc.volume = 0;
    }
}
