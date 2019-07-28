using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartButton : MonoBehaviour
{
    public GameObject restartButton;
    WaitForSeconds wait = new WaitForSeconds(2);
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
    }
}
