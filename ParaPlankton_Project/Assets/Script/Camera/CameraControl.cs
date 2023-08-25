using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public static CameraControl Instance;

    [Header("External References")]
    Transform _target;

    [Header("Movement")]
    public int SmoothSpeed = 1;

    private void Awake()
    {
        if (!Instance)
            Instance = this;
    }

    private void Start()
    {
        _target = Player.Instance.transform;
    }

    private void FixedUpdate()
    {
        FollowPlayer();
    }

    /// <summary>
    /// Make the camera follow the player with a certain smooth
    /// </summary>
    private void FollowPlayer() 
    {
        Vector3 direction = (_target.position - transform.position);
        transform.position += direction / 20f * SmoothSpeed;
    }
}
