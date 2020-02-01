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

    public static PlayerScript INSTANCE;

    bool lSound = false;
    bool canJump = false;

    void Awake()
    {
        
        INSTANCE = this;

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
        if(!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D)) 
        {
            rg.velocity = new Vector2(0, rg.velocity.y);
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


        if (Input.GetKey(KeyCode.Space) && canJump)
        {
            if (isGrounded)
            {
                canvasRenderer.sprite = Jump;
                isGrounded = false;

                rg.velocity = new Vector2(rg.velocity.x, transform.localScale.x * (jumpForce * 3.5f));//Vector2.up * speed;
            }
        }
        //Debug.Log(Input.GetAxis("ButtonRTXbox"));
        if(Input.GetKey(KeyCode.LeftShift))
        {
            RaycastHit2D hit = Physics2D.Raycast(laserLargo.transform.position, laserLargo.transform.right);
            if(hit.collider != null)
            {
                //1 - 5
                //hit - x
                /*string x = hit.collider.gameObject.name;
                if (x != "Tilemap") Debug.Log("ENEMY");*/
                //Debug.DrawRay(laserLargo.transform.position, laserLargo.transform.right, Color.black);


                Vector2 vectorLargo = new Vector2(0.0f, 0.1f);
                vectorLargo.x = hit.distance / 2f;
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
                if (hit.collider.gameObject.CompareTag("Enemy_Plant"))
                {
                    hit.collider.gameObject.GetComponent<plant_enemy>().life -= 0.1f;
                }
                if (hit.collider.gameObject.CompareTag("Enemy_Jump"))
                {
                    hit.collider.gameObject.GetComponent<jumping_enemy>().life -= 0.1f;
                }

            }
            /*else
            {

                Vector2 vectorLargo = new Vector2(0.0f, 0.1f);
                vectorLargo.x = 100;
                laserLargo.transform.localScale = vectorLargo;
                //Debug.Log(hit.distance / 0.5 );
                //laserLargoLine.SetPosition(1, new Vector2(hit.distance, 0));
                laserInicio.SetBool("Atacando", true);
                laserLargo.SetBool("Atacando", true);
                
            }*/

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

        RaycastHit2D hit2 = Physics2D.Raycast(transform.position, Vector2.up, 4f);

        if (hit2 && hit2.collider.gameObject.CompareTag("Ground"))
        {
            canJump = false;
            rg.velocity = new Vector2(rg.velocity.x, rg.velocity.y-1);
        }
        else
        {
            canJump = true;
        }

        if (rg.velocity.y != 0) isGrounded = false;
        else isGrounded = true;

        Debug.Log(isGrounded);
        gameObject.GetComponent<Animator>().SetBool("EnPiso", isGrounded);
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

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        /*if (collision.gameObject.tag == "Ground")
        {
           isGrounded = true;
        }*/

        if(collision.gameObject.tag == "Coin")
        {
            life++;
            TextoVida.text = life.ToString();
            Destroy(collision.gameObject);
        }

        if(collision.gameObject.tag == "Enemy")
        {
            //tira tuercas
            int rndNumber = Random.Range(1, 4);
            List<GameObject> TuercasCaidas = new List<GameObject>();
            life = life - rndNumber;
            TextoVida.text = life.ToString();
            for (int i = 0; i <= rndNumber; i++)
            {
                GameObject tuerca = Instantiate(Tuerca, collision.gameObject.transform.position, Quaternion.identity);
                Vector2 velocity = new Vector2(Random.Range(1.0f, 6.0f), Random.Range(1.0f, 6.0f));
                tuerca.GetComponent<Rigidbody2D>().AddForce(velocity * 20f);
                Destroy(tuerca, 10f);
            }
            Vector2 JumpVel = new Vector2();
            if (_right)
            {
                JumpVel = new Vector2(-75f, 50f);
            }
            else
            {
                JumpVel = new Vector2(75f, 50f);
            }
            rg.AddForce(JumpVel * 25f);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            TextoVida.text = life.ToString();
            life--;
            

        }

        if(collision.gameObject.tag == "Enemy_Roof")
        {
            getDamage(10, collision.gameObject);
        }

        
    }

    public void getDamage(int damage, GameObject gmO)
    {
        life -= damage;
        //tira tuercas
        int rndNumber = Random.Range(1, 4);
        List<GameObject> TuercasCaidas = new List<GameObject>();
        life = life - rndNumber;
        TextoVida.text = life.ToString();
        for (int i = 0; i <= rndNumber; i++)
        {
            GameObject tuerca = Instantiate(Tuerca, gmO.transform.position, Quaternion.identity);
            Vector2 velocity = new Vector2(Random.Range(1.0f, 6.0f), Random.Range(1.0f, 6.0f));
            tuerca.GetComponent<Rigidbody2D>().AddForce(velocity * 20f);
            Destroy(tuerca, 10f);
        }
        Vector2 JumpVel = new Vector2();
        if (_right)
        {
            JumpVel = new Vector2(-75f, 35f);
        }
        else
        {
            JumpVel = new Vector2(75f, 35f);
        }
        rg.AddForce(JumpVel * 25f);
    }


    /*private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }*/
}
