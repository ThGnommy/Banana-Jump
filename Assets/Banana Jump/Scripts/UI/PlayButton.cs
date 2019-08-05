using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButton : MonoBehaviour
{
    public Animator anim;
    GameManager gameManager;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        anim.GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    public void StartTheGame()
    {
        StartCoroutine(PlayTheGame());
        audioSource.Play();
    }

    public void DisableMenu()
    {
        anim.SetBool("Visible", false);
    }

    public IEnumerator PlayTheGame()
    {
        yield return new WaitForSeconds(.5f);
        DisableMenu();
        yield return new WaitForSeconds(2);
        GameManager.instance.LoadGame();
    }
}
