using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TP : MonoBehaviour
{
    public level_manager levelManager;
    public Vector2 otra_puerta;
    public int Index_del_otro_level;

    private void OnEnable()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            levelManager.SetLevel(Index_del_otro_level, otra_puerta);   //INDEX DEL OTRO NIVEL SEGUN EL ARREGLO DE LEVEL MANAGER
        }
    }
}
