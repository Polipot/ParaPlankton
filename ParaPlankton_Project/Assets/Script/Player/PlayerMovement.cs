using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MovementSituation { Idle, Moving };
public enum SpeedSituation { Crouch, Walking, Running };

public class PlayerMovement : MonoBehaviour
{
    Player _player;

    [Header("Internal Components")]
    Rigidbody2D _rigidbody;

    [Header("Movement Values")]
    [HideInInspector] public MovementSituation PlayerMovementSituation;
    [HideInInspector] public SpeedSituation PlayerSpeedSituation;
    public float SpeedCrouch = 0.25f;
    public float SpeedWalk = 0.5f;
    public float SpeedRun = 1;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _player = Player.Instance;
    }

    private void Update()
    {
        DetermineMovement();
        Movement();
        LookAt();
    }

    /// <summary>
    /// Determine the type of movement of the player
    /// </summary>
    private void DetermineMovement() 
    {
        if (Input.GetKey(KeyCode.LeftShift))
            PlayerSpeedSituation = SpeedSituation.Running;
        else if (Input.GetKey(KeyCode.LeftControl))
            PlayerSpeedSituation = SpeedSituation.Crouch;
        else
            PlayerSpeedSituation = SpeedSituation.Walking;
    }

    /// <summary>
    /// Move the player with the attributed keys
    /// </summary>
    private void Movement() 
    {
        float speed = 0;
        if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) + Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0) 
        {
            speed = 1;
            PlayerMovementSituation = MovementSituation.Moving;
        }
        else
            PlayerMovementSituation = MovementSituation.Idle;

        switch (PlayerSpeedSituation)
        {
            case SpeedSituation.Crouch:
                speed *= SpeedCrouch;
                break;
            case SpeedSituation.Walking:
                speed *= SpeedWalk;
                break;
            case SpeedSituation.Running:
                speed *= SpeedRun;
                break;
            default:
                speed = 0;
                break;
        }

        _rigidbody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed, Input.GetAxisRaw("Vertical") * speed);
    }

    /// <summary>
    /// Make the player look at the mouse position
    /// </summary>
    private void LookAt() 
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float angle = 0;

        Vector2 relative = transform.InverseTransformPoint(mousePosition);
        angle = Mathf.Atan2(relative.x, relative.y) * Mathf.Rad2Deg;

        transform.Rotate(0, 0, -angle);
    }
}
