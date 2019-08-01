using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MusicController : MonoBehaviour
{
    public AudioMixerSnapshot MenuSnapshot;
    public AudioMixerSnapshot InGameSnapshot;

    public bool inMenu, inGame;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        inMenu = false;
        inGame = false;
        FindObjectOfType<AudioManager>().Play("Jungle Amb");
        FindObjectOfType<AudioManager>().Play("Monkeys");
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Menu")
        {
            if(!inMenu)
            {
                MenuSnapshot.TransitionTo(1f);
                StartCoroutine(StopMusic());
                inMenu = true;
                inGame = false;
            }
        }

        if (SceneManager.GetActiveScene().name == "Game")
        {
            if (!inGame)
            {
                InGameSnapshot.TransitionTo(.1f);
                FindObjectOfType<AudioManager>().Play("Marimba");
                FindObjectOfType<AudioManager>().Play("Shakers");
                inGame = true;
                inMenu = false;
            }
        }
    }

    public IEnumerator StopMusic()
    {
        yield return new WaitForSeconds(1f);
        FindObjectOfType<AudioManager>().Stop("Marimba");
        FindObjectOfType<AudioManager>().Stop("Shakers");
    }
}
