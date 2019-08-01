using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{
    public string name;
    public bool loop;
    public AudioClip clip;

    [HideInInspector]
    public AudioSource source;
    public AudioMixerGroup mixerGroup;
}
