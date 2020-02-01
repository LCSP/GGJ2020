using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumping_enemy : MonoBehaviour
{

    private bool isJumping = false;
    public Transform player;
    public Rigidbody2D rb;
    public float life = 20f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isJumping)
        {
           
            if (Vector2.Distance(transform.position, player.position) < 20)
            {
                Debug.Log("In range");
                isJumping = true;
                transform.GetComponent<Animator>().SetBool("jumping", true);
                rb = transform.GetComponent<Rigidbody2D>();
                int randomNumber = Random.Range(1, 3);
                if(randomNumber > 1)
                {
                    rb.AddForce(new Vector3(-600.0f, 400.0f, 0f));
                }
                else
                {
                    rb.AddForce(new Vector3(600.0f, 400.0f, 0f));
                }

            }
        }
        if(rb.velocity == Vector2.zero)
        {
            isJumping = false;
        }
    }

    
}
