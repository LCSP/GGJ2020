﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TP : MonoBehaviour
{
    level_manager levelManager;
    public Vector2 otra_puerta;
    public int Index_del_otro_level;

    private void Awake()
    {
        levelManager = level_manager.INSTANCE;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            levelManager.SetLevel(Index_del_otro_level, otra_puerta);
        }
    }
}
