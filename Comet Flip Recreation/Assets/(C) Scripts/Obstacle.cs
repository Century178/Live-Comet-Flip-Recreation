using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public Vector2[] path;
    private int pos = 0;

    [SerializeField] private float moveSpeed;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (path == null)
        {
            return;
        }

        if (pos >= path.Length)
        {
            pos = 0;
        }

        rb.velocity /= 2;

        rb.position = Vector2.MoveTowards(transform.position, path[pos], moveSpeed * Time.fixedDeltaTime);

        if (Vector3.Distance(transform.position, path[pos]) < 0.1f)
        {
            pos++;
        }
    }
}
