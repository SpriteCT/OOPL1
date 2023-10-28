using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;
public class ObstacleGenerator : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject obstacles_parent;
    [SerializeField] private GameObject[] obstaclesTypes;
    
    private GameObject obstacle;
    private bool _isJumped = false;
    private GameManager _gameManager;
    private void Start()
    {
        obstacle = CreateObstacle();
        _gameManager = FindObjectOfType<GameManager>();
        _isJumped = false;
    }
    private void Update()
    {
        if (player.transform.position.x - obstacle.transform.position.x >= 10)
        {
            ReplaceObstacle();
        }
        CountJumpOver();
    }

    private GameObject CreateObstacle()
    {
        int obstacleType = Random.Range(0, obstaclesTypes.Length);
        Vector3 obstaclePos = new Vector3(player.transform.position.x + Random.Range(25, 30), 1f, 0f);
        if (obstaclesTypes[obstacleType].name == "Flying Obstacle")
        {
            obstaclePos += new Vector3(0f, 2f, 0f);
        }
        GameObject newObstacle = Instantiate(obstaclesTypes[obstacleType], obstaclePos, Quaternion.identity, obstacles_parent.transform);
        return newObstacle;
    }

    private void CountJumpOver()
    {
        if (player.transform.position.x > obstacle.transform.position.x && !_isJumped)
        {
            _gameManager.Score += 1;
            _gameManager.IncreaseSpeed();
            _isJumped = true;
        }
    }

    public void ReplaceObstacle()
    {
        Destroy(obstacle);
        obstacle = CreateObstacle();
        _isJumped = false;
    }
}
