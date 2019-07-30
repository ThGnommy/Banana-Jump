using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Score : MonoBehaviour
{
    internal TextMeshProUGUI scoreText;
    public GameObject player;

    public static int score = 0;
    int currentScore;
    Vector2 _lastPos;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        score = 0;
        _lastPos = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if((player.transform.position.y - _lastPos.y) > 0)
        {
            score++;
            _lastPos = player.transform.position;
            PlayerPrefs.SetInt("score", score);
        }
    }

    private void OnGUI()
    {
        scoreText.text = "Score: " + score;
    }
}
