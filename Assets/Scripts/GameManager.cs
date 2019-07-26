using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void RestartGame()
    {
        Invoke("LoadGame", 2f);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
    }

}
