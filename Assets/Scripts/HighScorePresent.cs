using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class HighScorePresent : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI highScoreText;
    private GameManager _gameManager;
    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }
    private void Update()
    {
        if (_gameManager.HighScore == 0)
        {
            highScoreText.text = "";
        }
        else
        {
            highScoreText.text = $"HighScore: {_gameManager.HighScore}";
        }
    }
}
