using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orb : MonoBehaviour
{
    PlayerScript playerScript;
    private void Awake()
    {
        playerScript = PlayerScript.INSTANCE;
        if(playerScript.transform.position.x > transform.position.x)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.right * 5;
        }
        if (playerScript.transform.position.x < transform.position.x)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.left * 5;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerScript.getDamage(20, transform.gameObject);
            Destroy(gameObject);
        }
    }
}
