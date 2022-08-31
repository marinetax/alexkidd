using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newscript : MonoBehaviour
{

    public float speed;
    public float jump;
    public GameObject ghost;
    public GameObject punch;

    private Animator m_Animator;
    private Rigidbody2D rb2d;
    private AudioSource audiojump;
    private int coins;
    private bool isJumping;
    private int Terrain;

    // Use this for initialization
    void Start()
    {

        m_Animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        audiojump = GetComponent<AudioSource>();
        m_Animator.SetInteger("TOT", 0);

        coins = 0;
        isJumping = false;
    }

    // Update is called once per frame
    void Update()
    {


        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        float atack = Input.GetAxis("Fire1");

        if (isJumping == false)
        {
            m_Animator.SetInteger("TOT", 0);
        }
        else
        {
            m_Animator.SetInteger("TOT", 2);

        }

        punch.SetActive(false);

        if (moveHorizontal > 0)
        {

            if (!isJumping)
            {
                m_Animator.SetInteger("TOT", 1);
            }

            transform.rotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
            rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
        }
        else if (moveHorizontal < 0)
        {
            if (!isJumping)
            {
                m_Animator.SetInteger("TOT", 1);
            }
            transform.rotation = new Quaternion(0.0f, 180.0f, 0.0f, 0.0f);
            rb2d.velocity = new Vector2(-speed, rb2d.velocity.y);
        }
        else
        {
            if (!isJumping)
            {
                m_Animator.SetInteger("TOT", 0);
            }
        }

        if (!isJumping)
        {

            if (moveVertical > 0)
            {
                m_Animator.SetInteger("TOT", 2);
                rb2d.AddForce(new Vector2(0, jump));
                audiojump.Play();
            }
        }

        if (atack > 0)
        {
            m_Animator.SetInteger("TOT", 3);
            punch.SetActive(true);
        }

        //Debug.Log(coins);
        if(Terrain == 1)
        {
            m_Animator.SetInteger("TOT", 4);

            if (atack > 0)
            {
                m_Animator.SetInteger("TOT", 5);
            }
            if(moveVertical > 0)
            {
                rb2d.velocity = new Vector2(0.0f, speed);
                
            }
            else if (moveVertical < 0)
            {
                rb2d.velocity = new Vector2(0.0f, -speed);
                
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Money"))
        {
            coins = coins + 100;
            Destroy(collision.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Suelo");
        isJumping = false;

        

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("Saltar");
        isJumping = true;
        m_Animator.SetInteger("TOT", 2);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Aigua"))
        {
            Debug.Log("Aigua");
            rb2d.gravityScale = 0.0f;
            rb2d.velocity = new Vector2(0.0f, 0.0f);
            speed = speed / 2;
            collision.isTrigger = false;
            Terrain = 1;
            
        }
    }
}