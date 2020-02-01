using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    [Range(0, 10)]
    public int movementSpeed = 1;
    [Range(0, 10)]
    public int range = 5;

    //public Text lifeText;

    public List<Vector2> points;
    public int currentPos = 0;

    public int life = 100;

    // Start is called before the first frame update

    private Vector2 initialPos;

    void Start()
    {
        initialPos = (Vector2)transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position += new Vector3(Mathf.PingPong(Time.time *  movementSpeed, range), 0, 0);
        if(Vector2.Distance(transform.position, new Vector2(points[currentPos].x, points[currentPos].y) + initialPos) < 0.1f){
            if(currentPos == points.Count - 1)
            {
                currentPos = 0;
            }
            else
            {
                currentPos++;
            }
        }
        
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(points[currentPos].x, points[currentPos].y) + initialPos, movementSpeed * Time.deltaTime);

        //lifeText.text = life.ToString();

        
    }

    private void OnDrawGizmos()
    {
        if (points.Count > 0)
        {
            for (int i = 0; i < points.Count - 1; i++)
            {
                Gizmos.color = Color.blue;
                Gizmos.DrawLine((Vector2)transform.position + points[i], (Vector2)transform.position + points[i + 1]);
            }
            Gizmos.DrawLine((Vector2)transform.position + points[points.Count - 1], (Vector2)transform.position + points[0]);
        }
    }


    

}
