using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    int hit = 10;

    Rigidbody2D rb_Enemy;
    

    // Start is called before the first frame update
    void Start()
    {
        rb_Enemy = GetComponent<Rigidbody2D>();        
    }

    // Update is called once per frame
    void Update()
    {
        if (IsFacingRight())
        {
            rb_Enemy.velocity = new Vector2(moveSpeed, 0f);
        }
        else
        {
            rb_Enemy.velocity = new Vector2(moveSpeed * -1, 0f);
        }
    }

    private bool IsFacingRight()
    {
        return transform.localScale.x > Mathf.Epsilon;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.localScale = new Vector2(-(Mathf.Sign(rb_Enemy.velocity.x)), transform.localScale.y);
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.tag == "Bullet")
        {
            PlayThroughtData.instance.ScoreKill();
            Destroy(gameObject);               
        }
    }
}
