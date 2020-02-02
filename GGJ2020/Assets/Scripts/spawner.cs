using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{

    public List<GameObject> spawnpoints;
    public List<GameObject> temp;
    public GameObject bomb_planted;
    public GameObject Enemy;
    public GameObject Enemy3;
    public GameObject enemy_roof;
    public GameObject orb_plant;

    // Start is called before the first frame update
    /*void Start()
    {
        for (int i = 0; i < spawnpoints.Count; i++)
        {

            if (spawnpoints[i].gameObject.name.Contains("bomb_planted"))
            {
                temp.Add(Instantiate(bomb_planted, spawnpoints[i].transform, true));
                temp[temp.Count - 1].transform.position = spawnpoints[i].transform.position;
            }
            if (spawnpoints[i].gameObject.name.Contains("Enemy"))
            {
                temp.Add(Instantiate(Enemy, spawnpoints[i].transform, true));
                temp[temp.Count - 1].transform.position = spawnpoints[i].transform.position;
            }
            if (spawnpoints[i].gameObject.name.Contains("Enemy3"))
            {
                temp.Add(Instantiate(Enemy3, spawnpoints[i].transform, true));
                temp[temp.Count - 1].transform.position = spawnpoints[i].transform.position;
            }
            if (spawnpoints[i].gameObject.name.Contains("enemy_roof"))
            {
                temp.Add(Instantiate(enemy_roof, spawnpoints[i].transform, true));
                temp[temp.Count - 1].transform.position = spawnpoints[i].transform.position;
            }
            if (spawnpoints[i].gameObject.name.Contains("orb_plant"))
            {
                temp.Add(Instantiate(orb_plant, spawnpoints[i].transform, true));
                temp[temp.Count - 1].transform.position = spawnpoints[i].transform.position;
            }
        }
    }*/
    void OnEnable()
    {
        for (int i = 0; i < spawnpoints.Count; i++)
        {
           
            if (spawnpoints[i].gameObject.name.Contains("bomb_planted"))
            {
                temp.Add(Instantiate(bomb_planted, spawnpoints[i].transform, true));
                temp[temp.Count - 1].transform.position = spawnpoints[i].transform.position;
            }
            if (spawnpoints[i].gameObject.name.Contains("Enemy"))
            {
                temp.Add(Instantiate(Enemy, spawnpoints[i].transform, true));
                temp[temp.Count - 1].transform.position = spawnpoints[i].transform.position;
            }
            if (spawnpoints[i].gameObject.name.Contains("Enemy3"))
            {
                temp.Add(Instantiate(Enemy3, spawnpoints[i].transform, true));
                temp[temp.Count - 1].transform.position = spawnpoints[i].transform.position;
            }
            if (spawnpoints[i].gameObject.name.Contains("enemy_roof"))
            {
                temp.Add(Instantiate(enemy_roof, spawnpoints[i].transform, true));
                temp[temp.Count - 1].transform.position = spawnpoints[i].transform.position;
            }
            if (spawnpoints[i].gameObject.name.Contains("orb_plant"))
            {
                temp.Add(Instantiate(orb_plant, spawnpoints[i].transform, true));
                temp[temp.Count - 1].transform.position = spawnpoints[i].transform.position;
            }
        }
    }

    private void OnDisable()
    {
        for (int i = 0; i < temp.Count; i++)
        {
            Destroy(temp[i]);
        }
    }
    // Update is called once per frame

}
