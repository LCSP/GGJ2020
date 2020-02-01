using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roof_enemy : MonoBehaviour
{
    public GameObject bullet;
    private Collider2D objs;
    public Transform player;
    public float BulletSpeed = 10.0f;
    private float t1=0;

    // Start is called before the first frame update
    void Start()
    {
        player = PlayerScript.INSTANCE.transform;
    }

    // Update is called once per frame
    void Update()
    {
        float t = Time.time;
        /*objs = Physics2D.OverlapCircle(transform.position, 30);
        if (objs != null && objs.gameObject.CompareTag("Player"))
        {
            Debug.Log("DETECTED");
            InvokeRepeating("shoot", 0f, 3f);
        }
        else
        {
            CancelInvoke("shoot");
        }*/
        if(Vector2.Distance(transform.position, player.position) < 20 && t-t1 >= 3f)
        {
            shoot();
            t1 = t;
        }
    }

    void OnTriggerEnter2D(Collider2D collision){
        
    }


    void shoot()
    {
        Debug.Log("test2");
        GameObject _bullet = Instantiate(bullet,transform.position, Quaternion.identity);
        float step = BulletSpeed * Time.deltaTime;
        _bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(player.position.x - transform.position.x, player.position.y - transform.position.y);
        //_bullet.GetComponent<Rigidbody2D>().velocity.magnitude = 1;
        _bullet.transform.up = new Vector2(player.position.x - transform.position.x, player.position.y - transform.position.y);

    }
}
