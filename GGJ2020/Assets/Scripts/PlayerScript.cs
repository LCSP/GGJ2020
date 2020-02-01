using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rg;
    private SpriteRenderer canvasRenderer;

    public Sprite Jump;
    public Sprite Idle;
    public GameObject cano;

    public Animator laserInicio;
    public Animator laserLargo;
    public GameObject brazo;

    public GameObject Tuerca;

    public Text TextoVida;

    public AudioClip LaserStart;
    public AudioClip LaserLoop;
    private AudioSource laserAudio;

    public GameObject laserLargoGO;
    public LineRenderer laserLargoLine;

    public int life = 100;

    private bool _right;
    private bool isGrounded = false;

    [Range(0.0f, 1.0f)]
    public float speed = 1f;
    [Range(0.0f, 1.0f)]
    public float jumpForce = 1.0f;


    private float lowJumpMultiplier = 2f;
    private float fallMultiplier = 2.5f;

    bool lSound = false;

    void Awake()
    {
        TextoVida.text = life.ToString();
        rg = GetComponent<Rigidbody2D>();
        canvasRenderer = GetComponent<SpriteRenderer>();
        laserAudio = transform.GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        //Debug.Log(rg.velocity.y);



        if (Input.GetKey(KeyCode.D))
        {
            //canvasRenderer.flipX = false;
            transform.rotation = Quaternion.Euler(0, 0, 0);
            _right = true;
            rg.velocity = new Vector2(transform.localScale.x * speed, rg.velocity.y);//Vector2.right * speed;
        }

        if (Input.GetKey(KeyCode.A))
        {
            
            transform.rotation = Quaternion.Euler(0, 180f, 0);

            _right = false;
            //canvasRenderer.flipX = true;
            rg.velocity = new Vector2(-(transform.localScale.x * speed), rg.velocity.y);//Vector2.left * speed;
        }

        if (rg.velocity.x != 0)
        {
            transform.GetComponent<Animator>().SetBool("Caminar", true);
        }
        else
        {
            transform.GetComponent<Animator>().SetBool("Caminar", false);
        }

        if ((Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.LeftArrow)) || (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.RightArrow)))
        {
            brazo.transform.localRotation = Quaternion.Euler(0, 0, 45);
        }
        else if(Input.GetKey(KeyCode.UpArrow))
        {
            brazo.transform.localRotation = Quaternion.Euler(0, 0, 90);
        }
        else
        {
            brazo.transform.localRotation = Quaternion.Euler(0, 0, 0);
        }


        if (Input.GetKey(KeyCode.Space))
        {
            if (isGrounded)
            {
                canvasRenderer.sprite = Jump;
                isGrounded = false;
                rg.velocity = new Vector2(rg.velocity.x, transform.localScale.x * jumpForce);//Vector2.up * speed;
            }
        }
        //Debug.Log(Input.GetAxis("ButtonRTXbox"));
        if(Input.GetKey(KeyCode.LeftShift))
        {
            RaycastHit2D hit = Physics2D.Raycast(laserLargo.transform.position, transform.right);
            if(hit.collider != null)
            {
                //1 - 5
                //hit - x
                //Debug.Log(hit.collider.gameObject.name);


                Vector2 vectorLargo = new Vector2(0.0f, 0.1f);
                vectorLargo.x = hit.distance * 0.5f;
                laserLargo.transform.localScale = vectorLargo;
                //Debug.Log(hit.distance / 0.5 );
                //laserLargoLine.SetPosition(1, new Vector2(hit.distance, 0));
                laserInicio.SetBool("Atacando", true);
                laserLargo.SetBool("Atacando", true);
                if(hit.collider.gameObject.tag == "Enemy")
                {
                    EnemyScript eScript = hit.collider.gameObject.GetComponent<EnemyScript>();
                    eScript.life--;
                }
            }
            else
            {

                Vector2 vectorLargo = new Vector2(0.0f, 0.1f);
                vectorLargo.x = 100;
                laserLargo.transform.localScale = vectorLargo;
                //Debug.Log(hit.distance / 0.5 );
                //laserLargoLine.SetPosition(1, new Vector2(hit.distance, 0));
                laserInicio.SetBool("Atacando", true);
                laserLargo.SetBool("Atacando", true);
                
            }

            if (!lSound) StartCoroutine(LaserSound());

        }
        else
        {
            laserInicio.SetBool("Atacando", false);
            laserLargo.SetBool("Atacando", false);
            laserAudio.Stop();
            lSound = false;
        }

      

        /*if(Input.GetAxis("ButtonRTXbox") < 0)
        {
            RaycastHit2D hit = Physics2D.Raycast(laserLargo.transform.position, -Vector2.right);
            if (hit.collider != null)
            {
                //1 - 5
                //hit - x


                Vector2 vectorLargo = new Vector2(0.0f, 0.1f);
                vectorLargo.x = hit.distance * 0.5f;
                laserLargo.transform.localScale = vectorLargo;
                //Debug.Log(hit.distance / 0.5 );
                //laserLargoLine.SetPosition(1, new Vector2(hit.distance, 0));
                laserInicio.SetBool("Atacando", true);
                laserLargo.SetBool("Atacando", true);
            }
        }
        else
        {
            laserInicio.SetBool("Atacando", false);
            laserLargo.SetBool("Atacando", false);
        }*/


    }
    IEnumerator LaserSound()
    {
        lSound = true;
        laserAudio.clip = LaserStart;
        laserAudio.Play();
        yield return new WaitForSeconds(LaserStart.length);
        laserAudio.clip = LaserLoop;
        laserAudio.Play();
    }

    

    void Update()
    {
        if (isGrounded)
        {
            canvasRenderer.sprite = Idle;
        }
        

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
           isGrounded = true;
        }

        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            TextoVida.text = life.ToString();
            life--;
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
