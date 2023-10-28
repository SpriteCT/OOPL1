using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float jumpForce;
    [SerializeField] private float moveSpeed;
    [SerializeField] private Vector3 rotationDirection; 
    
    private Rigidbody _rb;
    private bool _onGround;
    private GameManager _gameManager;
    private void Jump()
    {
        if (_onGround){
            _rb.AddForce(Vector2.up * jumpForce, ForceMode.VelocityChange);
            _rb.AddTorque(rotationDirection);
            _onGround = false;
        }
    }

    private void Move()
    {
        transform.position = new Vector3(moveSpeed * Time.deltaTime, 0f, 0f) + transform.position;
        if (_onGround)
        {
            transform.rotation = Quaternion.identity;
            transform.position = new Vector3(transform.position.x, transform.localScale.y / 2, 0f);
        }

    }

    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (_gameManager.IsGameStarted)
        {
            Move();
            if (Input.GetButtonDown("Jump"))
            {
                Jump();
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            _onGround = true;
        }

        if (other.gameObject.tag == "Obstacle")
        {
            StartCoroutine(_gameManager.EndGame());
            _rb.AddForce(other.contacts[0].normal * 1000);
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            _onGround = false;
        }
    }
    
}
