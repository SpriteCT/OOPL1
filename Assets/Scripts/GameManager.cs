using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject startPanel;
    [SerializeField] private GameObject endGamePanel;
    [SerializeField] private GameObject scorePanel;

    public bool IsGameStarted { get; private set; }
    public int HighScore { get; private set; }
    
    public int Score { get; set; }
    public bool EndGameState { get; set; }
    
    private float _gameSpeed = 1f;
    private ObstacleGenerator _obstacleGenerator;
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        EndGameState = false;
        _obstacleGenerator = FindObjectOfType<ObstacleGenerator>();
        
    }

    private void Update()
    {
        if (!EndGameState)
        {
            if (Input.GetButtonDown("Jump") && !IsGameStarted)
            {
                IsGameStarted = true;
                startPanel.SetActive(false);
                scorePanel.SetActive(true);
                endGamePanel.SetActive(false);
            }

            if (Input.GetButtonDown("Cancel") && IsGameStarted)
            {
                IsGameStarted = false;
                startPanel.SetActive(true);
                scorePanel.SetActive(true);
            }
        }

        Time.timeScale = MathF.Sqrt(_gameSpeed);
    }

    public void IncreaseSpeed()
    {
        _gameSpeed += 0.1f;
    }
    public IEnumerator EndGame()
    {
        _gameSpeed = 1f;
        IsGameStarted = false;
        EndGameState = true;
        yield return new WaitForSecondsRealtime(3f); //Момент откидывания кубика от препятствий
        
        HighScore = HighScore < Score ? Score : HighScore;
        endGamePanel.SetActive(true);
        scorePanel.SetActive(false);
        _obstacleGenerator.ReplaceObstacle();
        yield return new WaitForSecondsRealtime(3f); //Экран END GAME
        
        EndGameState = false;
        startPanel.SetActive(true);
        endGamePanel.SetActive(false);
        Score = 0; //Экран START GAME
    }
}
