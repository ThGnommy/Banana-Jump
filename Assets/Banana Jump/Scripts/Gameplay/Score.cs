using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Score : MonoBehaviour
{
    internal TextMeshProUGUI scoreText;
    public GameObject player;

    public static int score = 0;
    int tempValue = 0;

    Vector2 lastPosition;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        score = PlayerPrefs.GetInt("score", 0);
        lastPosition = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if ((player.transform.position.y - lastPosition.y) > 0)
        {
            tempValue++;
            lastPosition = player.transform.position;

            if (tempValue >= score)
            {
                score = tempValue;
                PlayerPrefs.SetInt("score", score);
                Debug.Log("Beeest Scooore!");
            }
        }
    }

    private void OnGUI()
    {
        scoreText.text = "Score: " + tempValue;
    }
}