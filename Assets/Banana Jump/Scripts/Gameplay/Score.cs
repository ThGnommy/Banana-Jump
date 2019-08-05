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
    bool highScoreSound = false;

    Vector2 lastPosition;

    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.DeleteAll();
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

                if (PlayerController.instance.HasPlayed == 1 && !highScoreSound)
                {
                    highScoreSound = true;
                    FindObjectOfType<AudioManager>().Play("High Score");
                }
            }
        }
    }

    private void OnGUI()
    {
        scoreText.text = "Score: " + tempValue;
    }
}