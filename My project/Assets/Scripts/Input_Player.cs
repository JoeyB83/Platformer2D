using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Input_Player : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float jumpForce;
    [SerializeField] float rayLength;
    [SerializeField] float shootForce;
    [SerializeField] LayerMask ground;
    [SerializeField] GameObject bullet;
    Vector3 orPos;
    bool isRight = true;

    Rigidbody2D rb_Player;

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb_Player = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        orPos = transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        Jump();
        PlayerShoot();
    }
    void FixedUpdate()
    {
        PlayerMovement();        
    }

    public void PlayerMovement()
    {
        float input = Input.GetAxisRaw("Horizontal");       
        rb_Player.velocity = new Vector2(input * moveSpeed, rb_Player.velocity.y);
        if (input < -0.1f)
        {
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
            anim.SetInteger("Run", 1);
            isRight = false;
        }
        else if(input > 0.1f) 
        {
            gameObject.transform.localScale = Vector3.one;
            anim.SetInteger("Run", 1);
            isRight = true;
        }
        else
        {
            anim.SetInteger("Run", 0);
        }        
    }

    bool OnGround()
    {
        Vector3 origin = transform.position;
        Vector3 down = transform.up * -1;
        RaycastHit2D hit = Physics2D.Raycast(origin, down, rayLength, ground);
        bool onGround = hit.collider != null;
        anim.SetBool("onGround", onGround);
        return onGround;
    }

     public void Jump()
    {
        if (OnGround() && Input.GetButtonDown("Jump"))
        {
            rb_Player.velocity = new Vector2(rb_Player.velocity.x, jumpForce);
            anim.SetTrigger("Jump");            
        }                   
    }

    public void PlayerShoot()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject newBullet = Instantiate(bullet, transform.position, Quaternion.identity);
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                newBullet.GetComponent<Rigidbody2D>().AddForce(Vector2.right * shootForce);
            }
            else if (Input.GetAxisRaw("Horizontal") < 0)
            {
                newBullet.GetComponent<Rigidbody2D>().AddForce(Vector2.right * shootForce * -1);
            }else
            {
                if (isRight)
                {
                    newBullet.GetComponent<Rigidbody2D>().AddForce(Vector2.right * shootForce);
                }
                else
                {
                    newBullet.GetComponent<Rigidbody2D>().AddForce(Vector2.right * shootForce * -1);
                }                
            }           
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        PlayThroughtData.instance.LostLive();
        int GO = PlayThroughtData.instance.lives;
        rb_Player.velocity = Vector2.zero;
        rb_Player.angularVelocity = 0f;
        transform.position = orPos;
        gameObject.transform.localScale = Vector3.one;
        if (GO == 0) 
        { 
            ManageScenes.instance.FinalScreen();
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            PlayThroughtData.instance.LostLive();
            int GO = PlayThroughtData.instance.lives;
            rb_Player.velocity = Vector2.zero;
            rb_Player.angularVelocity = 0f;
            transform.position = orPos;
            gameObject.transform.localScale = Vector3.one;
            if (GO == 0)
            {
                ManageScenes.instance.FinalScreen();
            }
        }
    }

}
