using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    public int toUnlock;
    public bool isLocked;
    PlayerScript playerScript;

    private void Start()
    {
        playerScript = PlayerScript.INSTANCE;
        if (!isLocked)
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && isLocked)
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && isLocked && Input.GetKeyDown(KeyCode.Return) && playerScript.life >= toUnlock)
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            isLocked = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
