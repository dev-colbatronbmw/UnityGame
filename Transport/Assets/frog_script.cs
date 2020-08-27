using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frog_script : Enemy
{
    [SerializeField] private float leftStop;
    [SerializeField] private float rightStop;
    [SerializeField] private float jumpLength = .75f;
    [SerializeField] private float jumpHeight = 2f;
    [SerializeField] private LayerMask ground;
    private Collider2D coll;
     [SerializeField]private bool facingLeft = true;
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

        // transition from animation
        if (anim.GetBool("jump"))
        {
            anim.SetBool("idle", false);
            if (rb.velocity.y < .01)
            {
                anim.SetBool("fall", true);
                anim.SetBool("jump", false);   
            }
        }
        if (coll.IsTouchingLayers(ground) && anim.GetBool("fall"))
        {
            anim.SetBool("fall", false);
            anim.SetBool("idle", true);
        }


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
                }

                if (coll.IsTouchingLayers(ground))
                {
                    anim.SetBool("jump", true);
                    rb.velocity = new Vector2(-jumpLength, jumpHeight);
                    
                    anim.SetBool("idle", false);
                }

                // test to see movement available
              
            }
            else
            {




                //transform.localScale = new Vector3(-1, 1);
                facingLeft = false;
                //anim.SetBool("jump", true);



                if (transform.localScale.x != -1)
                {
                    transform.localScale = new Vector3(-1, 1);
                }

                // test to see movement available
                if (coll.IsTouchingLayers(ground))
                {
                    rb.velocity = new Vector2(jumpLength, jumpHeight);
                    anim.SetBool("jump", true);
                    anim.SetBool("idle", false);
                }

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
                }

                // test to see movement available
                if (coll.IsTouchingLayers(ground))
                {
                    rb.velocity = new Vector2(jumpLength, jumpHeight);
                    anim.SetBool("jump", true);
                    anim.SetBool("idle", false);
                }
            }
            else
            {
                //transform.localScale = new Vector3(1, 1);
                facingLeft = true;
                //anim.SetBool("jump", true);
                if (transform.localScale.x != 1)
                {
                    transform.localScale = new Vector3(1, 1);
                }

                if (coll.IsTouchingLayers(ground))
                {
                    anim.SetBool("jump", true);
                    rb.velocity = new Vector2(-jumpLength, jumpHeight);

                    anim.SetBool("idle", false);
                }
            }
        }
    }

    private void idle()
    {
        anim.SetBool("idle", true);
        anim.SetBool("jump", false);
        anim.SetBool("fall", false);
    }
   

   

}
