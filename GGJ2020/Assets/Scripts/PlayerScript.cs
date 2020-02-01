using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rg;
    private SpriteRenderer canvasRenderer;

    public Sprite Jump;
    public Sprite Idle;
    public GameObject cano;

    public Sprite laserRed;
    public Sprite laserBlue;
    public Sprite laserGreen;

    private bool isGrounded = false;

    [Range(0.0f, 1.0f)]
    public float speed = 1f;
    [Range(0.0f, 1.0f)]
    public float jumpForce = 1.0f;

    private float lowJumpMultiplier = 2f;
    private float fallMultiplier = 2.5f;

    void Awake()
    {
        rg = GetComponent<Rigidbody2D>();
        canvasRenderer = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        //Debug.Log(rg.velocity.y);
        

        if (Input.GetAxis("Horizontal") > 0)
        {
            //canvasRenderer.flipX = false;
            transform.rotation = Quaternion.Euler(0, 0, 0);
            rg.velocity = new Vector2(transform.localScale.x * speed, rg.velocity.y);//Vector2.right * speed;
        }
        
        if (Input.GetAxis("Horizontal") < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180f, 0);
            //canvasRenderer.flipX = true;
            rg.velocity = new Vector2(-(transform.localScale.x * speed), rg.velocity.y);//Vector2.left * speed;
        }

        if (Input.GetButton("ButtonAXbox"))
        {
            if (isGrounded)
            {
                canvasRenderer.sprite = Jump;
                isGrounded = false;
                rg.velocity = new Vector2(rg.velocity.x, transform.localScale.x * jumpForce);//Vector2.up * speed;
            }
        }
        //Debug.Log(Input.GetAxis("ButtonRTXbox"));
        if(Input.GetAxis("ButtonRTXbox") > 0)
        {
            RaycastHit2D hit = Physics2D.Raycast(cano.transform.position, Vector2.right);
            if(hit.collider != null)
            {
                float distance = Mathf.Abs(hit.point.x - cano.transform.position.x);
                GL.PushMatrix();
                GL.LoadOrtho();

                GL.Begin(GL.LINES);

                GL.Color(Color.red);
                GL.Vertex(cano.transform.position);
                GL.Vertex(hit.point);
                GL.End();

                GL.PopMatrix();
            }
        }

        

    }

     void Update()
    {
        if (isGrounded)
        {
            canvasRenderer.sprite = Idle;
        }
        /*if (rg.velocity.y <= 0)
        {
            canvasRenderer.sprite = Idle;
        }*/
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
           isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }
}
