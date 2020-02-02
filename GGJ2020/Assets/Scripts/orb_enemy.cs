using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orb_enemy : MonoBehaviour
{

    public Transform player;
    public GameObject orb;
    public GameObject tiro;
    private bool isAttacking;
    public float life = 50;

    public static orb_enemy INSTANCE;
    // Start is called before the first frame update

    private void Awake()
    {
        INSTANCE = this;
    }
    void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player")[0].transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(life <= 0)
        {

            Destroy(gameObject);
        }
        
        if (!isAttacking)
        {
            if (Vector2.Distance(transform.position, player.position) < 20)
            {
                isAttacking = true;

                StartCoroutine(Attack());
            }
        }

    }

    IEnumerator Attack()
    {
        transform.GetComponent<Animator>().SetBool("attack", true);
        yield return new WaitForSecondsRealtime(0.267f);
        Instantiate(orb, tiro.transform.position, Quaternion.identity);
        yield return new WaitForSecondsRealtime(3f);
        transform.GetComponent<Animator>().SetBool("attack", false);
        isAttacking = false;
    }
}
