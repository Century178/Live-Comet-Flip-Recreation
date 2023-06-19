using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    [SerializeField] private Vector2 startDirection;
    [HideInInspector] public Vector2 direction;

    [SerializeField] private Vector2 spawnPoint;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        Spawn();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            direction.x *= -1f;
        }

        if (Input.GetMouseButtonDown(1))
        {
            direction.y *= -1f;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = direction * moveSpeed; //'direction' does not need to be normalized since the player only ever goes diagonally.
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Spawn();
        }
    }

    private void Spawn()
    {
        transform.position = spawnPoint;
        direction = startDirection;
    }
}
