using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : Enemy
{
    [SerializeField] private float leftStop;
    [SerializeField] private float rightStop;
    [SerializeField] private float moveLength = 1f;
    [SerializeField] private float jumpHeight = 0f;
    [SerializeField] private LayerMask ground;
    private Collider2D coll;

    private bool facingLeft = true;
    private Rigidbody2D rb;
    //private Animator anim; 

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        coll = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {


    }

    private void move()
    {

        if (facingLeft)
        {
            // test to see if beyond left start
            // if beyond turn right
            if (transform.position.x > leftStop)
            {
                if (transform.localScale.x != 1)
                {
                    transform.localScale = new Vector3(1, 1);
                    anim.SetBool("walking", true);
                    anim.SetBool("idle", false);
                }

                // test to see movement available
                rb.velocity = new Vector2(-moveLength, jumpHeight);
                anim.SetBool("walking", true);
                anim.SetBool("idle", false);

            }
            else
            {
                facingLeft = false;
                anim.SetBool("walking", true);
                anim.SetBool("idle", false);
            }
        }
        else
        {
            // test to see if beyond left start
            // if beyond turn right
            if (transform.position.x < rightStop)
            {
                if (transform.localScale.x != -1)
                {
                    transform.localScale = new Vector3(-1, 1);
                    anim.SetBool("walking", true);
                    anim.SetBool("idle", false);
                }

                // test to see movement available
                rb.velocity = new Vector2(moveLength, jumpHeight);
                anim.SetBool("walking", true);
                anim.SetBool("idle", false);
            }
            else
            {
                facingLeft = true;
                anim.SetBool("walking", true);
                anim.SetBool("idle", false);
            }
        }
    }



    private void idle()
    {
        anim.SetBool("idle", true);
        anim.SetBool("walking", false);
    }




    //public void JumpedOn()
    //{
    //    //Destroy(this);

    //    anim.SetTrigger("death");
    //    //Death();
    //}

    //private void Death()
    //{
    //    Destroy(this.gameObject);
    //}


}
