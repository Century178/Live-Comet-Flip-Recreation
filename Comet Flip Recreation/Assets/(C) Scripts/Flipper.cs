using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipper : MonoBehaviour
{
    private Player player;

    [SerializeField] private bool horizontal;

    private void Awake()
    {
        player = GetComponentInParent<Player>();
    }

    private void OnTriggerStay2D(Collider2D collision) //OnTriggerStay is used to ensure the player doesn't slide along a wall.
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            if (horizontal)
            {
                player.Direction.x *= -1f;
                return;
            }
            player.Direction.y *= -1f;
        }
    }
}
