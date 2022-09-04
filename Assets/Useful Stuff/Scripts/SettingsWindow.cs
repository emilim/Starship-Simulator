using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsWindow : MonoBehaviour
{
    public bool t = true;
    public AudioMixer audioMixer;

    void Start()
    {
        if (t)
            transform.localScale = Vector2.zero;
    }

    public void Open()
    {
        transform.LeanScale(Vector2.one, 0.8f);
    }

    public void Close()
    {
        transform.LeanScale(Vector2.zero, 1f).setEaseInBack();
    }
    public void setVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }
}
