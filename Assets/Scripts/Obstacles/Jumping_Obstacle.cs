using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Random = UnityEngine.Random;

public class Jumping_Obstacle : MonoBehaviour
{
    [SerializeField] private float jumpForce = 8f;
    
    private bool _onGround;
    private Rigidbody _rb;
    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            _onGround = true;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            _onGround = false;
        }
    }

    private void FixedUpdate()
    {
        Jump();
    }

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Jump()
    {
        if (_onGround)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 0f);
            transform.rotation = Quaternion.identity;
            _rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}