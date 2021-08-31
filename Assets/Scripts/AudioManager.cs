using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] soundclips;
    void Awake()
    {
        foreach (Sound s in soundclips)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }
    void Start()
    {
        PlayMusic("GameMusic");
    }

    // Update is called once per frame
    public void PlayMusic(string name)
    {
        Sound s = Array.Find(soundclips, sound => sound.name == name);
        if (s == null)
        {
            return;

        }
        else
        {
            s.source.Play();

        }

    }
    public void StopMusic(string name)
    {
        Sound s = Array.Find(soundclips, sound => sound.name == name);
        if (s == null)
        {
            return;

        }
        else
        {
            s.source.Stop();

        }
    }

}
