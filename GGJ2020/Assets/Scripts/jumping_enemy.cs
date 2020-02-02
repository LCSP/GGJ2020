using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumping_enemy : MonoBehaviour
{

    private bool isJumping = false;
    public Transform player;
    private Rigidbody2D rb;
    public float life = 20f;
    PlayerScript playerScript;
    // Start is called before the first frame update
    void Start()
    {
        playerScript = PlayerScript.INSTANCE;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsJumping())
        {
            Debug.Log("NO saltando");
            if (Vector2.Distance(transform.position, player.position) < 20)
            {
                Debug.Log("In range");
                transform.GetComponent<Animator>().SetBool("jumping", true);
                rb = transform.GetComponent<Rigidbody2D>();
                if(playerScript.transform.position.x > transform.position.x)
                {
                    rb.AddForce(new Vector3(200.0f, 300.0f, 0f));
                }
                else
                {
                    rb.AddForce(new Vector3(-200.0f, 300.0f, 0f));
                }

            }
        }
        if(rb.velocity.y == 0)
        {
            transform.GetComponent<Animator>().SetBool("jumping", false);
        }
    }

    bool IsJumping()
    {
        return !gameObject.GetComponentInChildren<OnFloor>().onFloor;
    }
    
}
