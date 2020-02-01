using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject cam;
    void Start()
    {
        GameObject[] player_obj = GameObject.FindGameObjectsWithTag("Player");
        player_obj[0].transform.position = transform.position;
        Instantiate(cam, player_obj[0].transform.position, Quaternion.identity).GetComponent<CameraFollow>().target = player_obj[0].transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
