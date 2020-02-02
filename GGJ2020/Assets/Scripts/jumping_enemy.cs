using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumping_enemy : MonoBehaviour
{
    public Transform player;
    private Rigidbody2D rb;
    public float life = 20f;
    PlayerScript playerScript;
    public GameObject Tuerca;
    bossfight bss;
    // Start is called before the first frame update
    void Start()
    {
        bss = bossfight.INSTANCE;
        player = GameObject.FindGameObjectsWithTag("Player")[0].transform;
        playerScript = PlayerScript.INSTANCE;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(life < 0)
        {
            if (transform.CompareTag("BossEnemie"))
            {
                bss.EnemiesCount--;
            }
            for (int i = 0; i <= 5; i++)
            {
                GameObject tuerca = Instantiate(Tuerca, transform.position, Quaternion.identity);
                Vector2 velocity = new Vector2(Random.Range(1.0f, 6.0f), Random.Range(1.0f, 6.0f));
                tuerca.GetComponent<Rigidbody2D>().AddForce(velocity * 20f);
            }
            Destroy(gameObject);
        }

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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerScript.getDamage(10, transform.gameObject);
        }
    }

}
