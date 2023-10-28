using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Serialization;

public class GroundGenerator : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject groundPrefab;
    [SerializeField] private GameObject groundParent;
    
    private GameObject _currentGround;
    private GameObject _nextGround;
    private int _groundOffset = 0;
    private GameManager _gameManager;
    
    private void Start()
    {
        _currentGround = GameObject.FindWithTag("Ground");
    }

    private void Update()
    {
        GenerateNewGround();
        DeleteOldGround();
    }

    private void GenerateNewGround()
    {
        if (player.transform.position.x >= 300f + _groundOffset)
        {
            _groundOffset += 1000;
            _nextGround = Instantiate(groundPrefab, new Vector3(_groundOffset, 0f, 0f), Quaternion.Euler(90, 0, 0),
                groundParent.transform);
        }
    }

    private void DeleteOldGround()
    {
        if (player.transform.position.x - _currentGround.transform.position.x >= 800f)
        {
            Destroy(_currentGround);
            _currentGround = _nextGround; 
        }
    }
}
