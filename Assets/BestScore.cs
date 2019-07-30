﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BestScore : MonoBehaviour
{
    TextMeshProUGUI _text;

    // Start is called before the first frame update
    void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
        Score.score = PlayerPrefs.GetInt("score", 0);
        _text.text = "Score: " + Score.score;
    }
}
