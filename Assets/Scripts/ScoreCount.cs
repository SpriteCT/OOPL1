using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreCount : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    private GameManager _gameManager;
    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }
    private void Update()
    {
        scoreText.text = $"Score: {_gameManager.Score.ToString()}";
    }
}
