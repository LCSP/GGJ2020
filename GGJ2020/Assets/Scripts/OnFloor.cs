using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnFloor : MonoBehaviour
{
    public bool onFloor;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onFloor = true;
        }
        else
        {
            onFloor = false;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onFloor = false;
        }
    }
}
