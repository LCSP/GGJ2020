using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rg;
    [Range(1, 10)]
    public float speed = 5f;
    [Range(1, 10)]
    public float jumpForce = 10f;

    private float lowJumpMultiplier = 2f;
    private float fallMultiplier = 2.5f;

    void Awake()
    {
        rg = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (rg.velocity.y < 0)
        {
            rg.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rg.velocity.y > 0 && Input.GetKeyDown(KeyCode.Space))
        {
            rg.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            rg.velocity.x += Vector2.right * speed;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            rg.velocity.x -= Vector2.right * speed;
        }

    }
}
