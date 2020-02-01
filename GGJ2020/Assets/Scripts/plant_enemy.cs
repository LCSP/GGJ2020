using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plant_enemy : MonoBehaviour
{
    public float life = 10f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     if(life <= 0)
        {
            transform.GetComponent<Animator>().SetBool("Muere", true);
            Destroy(gameObject, 2f);
        }   
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("test");
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerScript>().getDamage(5, transform.gameObject);
            transform.GetComponent<Animator>().SetBool("Muere", true);
            transform.GetComponent<BoxCollider2D>().enabled = false;
            Destroy(gameObject, 2f);
        }
    }
}
