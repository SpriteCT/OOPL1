using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Vector3 cameraOffset;

    private void Update()
    {
        transform.position = new Vector3(player.transform.position.x, 0f, 0f) + cameraOffset;
    }
}
