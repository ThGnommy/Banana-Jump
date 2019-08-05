using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartButton : MonoBehaviour
{
    public GameObject restartButton;
    AudioSource audioSource;

    WaitForSeconds wait = new WaitForSeconds(2);

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void ShowRestart()
    {
        StartCoroutine(WaitForRestart());
    }

    public IEnumerator WaitForRestart()
    {
        yield return wait;
        restartButton.SetActive(true);
    }

    public void RestartTheGame()
    {
        GameManager.instance.LoadGame();
        audioSource.Play();
    }

    public void GoHome()
    {
        GameManager.instance.MainMenu();
        audioSource.Play();
    }
}
