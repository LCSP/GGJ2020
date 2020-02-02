using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    public int toUnlock;
    public bool isLocked;
    public Sprite SpritePuertaReparada;
    PlayerScript playerScript;

    private void Start()
    {
        playerScript = PlayerScript.INSTANCE;
        if (!isLocked)
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            transform.GetComponent<SpriteRenderer>().sprite = SpritePuertaReparada;
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
            transform.GetComponent<SpriteRenderer>().sprite = SpritePuertaReparada;
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
