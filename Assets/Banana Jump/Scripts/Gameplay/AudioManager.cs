using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public static AudioManager instance;

    [HideInInspector]
    float index;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip[(int)index];
            s.source.loop = s.loop;
            s.source.outputAudioMixerGroup = s.mixerGroup;

            //Seek only the clip within the Ambience MixerGroup
            if (s.loop && s.mixerGroup.name == "Ambience")
            {
                float randomStart = UnityEngine.Random.Range(0, s.clip[0].length);
                s.source.time = randomStart;
                Debug.Log(randomStart);
            }
        }
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
        }

        s.source.Play();
    }

    public void PlayOneShot(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if(s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
        }

        index = UnityEngine.Random.Range(0, s.clip.Length);
        s.source.PlayOneShot(s.clip[(int)index]);

        Debug.Log(s.source.loop);
    }


    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Stop();
    }

}