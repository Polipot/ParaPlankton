using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    Player _player;

    [Header("Seek interaction")]
    public LayerMask OnlyInteractors;
    public LayerMask Obstacles;
    private Collider2D _foundInteraction;

    private void Start()
    {
        _player = Player.Instance;
    }

    private void Update()
    {
        DetectInteractiveObject();
    }

    /// <summary>
    /// Detect a usable interactive object around the player
    /// </summary>
    private void DetectInteractiveObject() 
    {
        RaycastHit2D hit = Physics2D.CircleCast(transform.position, 2, Vector2.zero, 0, OnlyInteractors);
        Collider2D newInteraction = null;

        if (!hit) 
        {
            newInteraction = null;
        }
        else 
        {
            float distance = Vector2.Distance(transform.position, hit.collider.transform.position);
            RaycastHit2D[] obstacles = Physics2D.RaycastAll(transform.position, hit.collider.transform.position, distance, Obstacles);

            if (obstacles.Length == 0)
                newInteraction = hit.collider;
            else
                newInteraction = null;
        }

        if (newInteraction) 
        {
            if(_foundInteraction && _foundInteraction != newInteraction) 
            {

            }
        }
    }
}
