using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level_manager : MonoBehaviour
{
    Vector2 PlayerSpawn;
    public static level_manager INSTANCE;
    PlayerScript playerScript;

    public GameObject[] Levels;

    private void Awake()
    {
        PlayerSpawn = new Vector2(-23, -5.5f);
        playerScript = PlayerScript.INSTANCE;
        INSTANCE = this;
        SetLevel(0, PlayerSpawn);
    }
    public void SetLevel(int index, Vector2 otra_puerta)
    {
        playerScript.transform.position = otra_puerta;
        for(int i=0; i<Levels.Length; i++)
        {
            bool active = i == index;
            if (Levels[i].activeSelf != active) Levels[i].SetActive(active);
        }
    }
}
