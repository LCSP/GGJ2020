using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_starter : MonoBehaviour
{
    // Start is called before the first frame update
    bossfight bss;
    void Start()
    {
        bss = bossfight.INSTANCE;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            bss.startBossfight();
            Destroy(gameObject);
        }
    }
}
