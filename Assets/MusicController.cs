using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MusicController : MonoBehaviour
{
    public AudioMixerSnapshot MainMenu;
    public AudioMixerSnapshot Game;
    public AudioMixerSnapshot Death;

    private AudioSource audioSource;

    public AudioClip[] track;


}
