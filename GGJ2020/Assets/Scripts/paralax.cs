using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paralax : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;

    public GameObject layer1;
    public GameObject layer2;
    public GameObject layer3;
    public GameObject layer4;

    float playerDistanceTravelled = 0;
    float layer1DistanceTravelled = 0;
    float layer2DistanceTravelled = 0;
    float layer3DistanceTravelled = 0;
    float layer4DistanceTravelled = 0;

    Vector2 playerLastPosition;
    Vector2 layer1LastPosition;
    Vector2 layer2LastPosition;
    Vector2 layer3LastPosition;
    Vector2 layer4LastPosition;


    void Start()
    {
        playerLastPosition = player.transform.position;
        layer1LastPosition = layer1.transform.position;
        layer2LastPosition = layer2.transform.position;
        layer3LastPosition = layer3.transform.position;
        layer4LastPosition = layer4.transform.position;
    }


    void Update()
    {
        playerDistanceTravelled += Vector2.Distance(player.transform.position, playerLastPosition);
        playerLastPosition = player.transform.position;

        /*layer1DistanceTravelled += Vector2.Distance(player.transform.position, layer1LastPosition);
        layer1LastPosition = player.transform.position;

        layer2DistanceTravelled += Vector2.Distance(player.transform.position, layer2LastPosition);
        layer2LastPosition = player.transform.position;

        layer3DistanceTravelled += Vector2.Distance(player.transform.position, layer3LastPosition);
        layer3LastPosition = player.transform.position;

        layer4DistanceTravelled += Vector2.Distance(player.transform.position, layer4LastPosition);
        layer4LastPosition = player.transform.position;*/

        if(playerDistanceTravelled > 0)
        {
            Vector2 newPos = new Vector2(playerDistanceTravelled / 2, layer1.transform.position.y)  ;
            layer1.transform.position = newPos;

            Vector2 newPos1 = new Vector2(playerDistanceTravelled / 3, layer2.transform.position.y) ;
            layer2.transform.position = newPos;

            Vector2 newPos2 = new Vector2(playerDistanceTravelled / 4, layer3.transform.position.y);
            layer3.transform.position = newPos;

            Vector2 newPos3 = new Vector2(playerDistanceTravelled / 5, layer4.transform.position.y) ;
            layer4.transform.position = newPos;
        }




    }
}
