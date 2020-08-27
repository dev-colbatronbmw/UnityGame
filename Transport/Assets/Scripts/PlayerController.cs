using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D player;
    private Animator anim;
    private Collider2D coll;
    [SerializeField] private AudioSource footsteps;
    [SerializeField] private AudioSource keyPickUp;
    [SerializeField] private AudioSource lockOpen;
    public float velosity;
    [SerializeField] private LayerMask ground;
    [SerializeField] private float speed = 4.5f;
    [SerializeField] private float jumpForce = 12f;
    [SerializeField] private bool hasRedKey = false;
    [SerializeField] private bool hasYellowKey = false;
    [SerializeField] private float redflag = 0f;
    public float redKey = 0f;
    public float yellowKey = 0f;
    private AudioSource pickedUp;
    private AudioSource unlocked;
    private int locks = 2;
    [SerializeField] private float hurtForce = 5;
    //[SerializeField] private Image RedKeyFilled;
    private enum State { idle, walking, jumping, falling, hurt, swimming, climbing }
    private State state = State.idle;
    private bool isTheDoorOpen;


    private void Start()
    {
        player = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
        isTheDoorOpen = GameObject.Find("DoorOpen").GetComponent<Exit>().isDoorOpen;
        redKey = 0f;
       yellowKey = 0f;


       //GameObject ship = GameObject.Find("shipGreen").GetComponent<winning>().shipGreen;

    }




    private void Update()
    {

        if(state != State.hurt)
        {
            Movement();
        }

       
        VelocityState();
        anim.SetInteger("state", (int)state); // based on enumorator
        velosity = player.velocity.x;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Enemy")
        {

            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
       

            if (state == State.falling)
            {

                 Jump(jumpForce / 2);

                enemy.JumpedOn();    
                //Destroy(collision.gameObject);

            }
            else
            {
                if (collision.gameObject.transform.position.x > transform.position.x)
                {
                    // enemy is to my right and I should move
                    player.velocity = new Vector2(-hurtForce, player.velocity.y);
                    state = State.hurt;
                }
                else
                {
                    // enemy is to my left and I whoufl move right
                    player.velocity = new Vector2(hurtForce, player.velocity.y);
                    state = State.hurt;
                }
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        GameObject lockedDoor = GameObject.FindGameObjectWithTag("LockedDoor");

        if (collision.tag == "RedKey")
        {
            hasRedKey = true;
            keyPickUp.Play();
            Destroy(collision.gameObject);
            redKey = redKey + 1f;


        }

        if (collision.tag == "YellowKey")
        {
            hasYellowKey = true;
            keyPickUp.Play();
            Destroy(collision.gameObject);
            yellowKey = yellowKey + 1f;


        }



        if (collision.tag == "RedLock")
        {
            if (hasRedKey)
            {
                //GameObject doorOpen = GameObject.Find("DoorOpen");
                //Exit exit = doorOpen.GetComponent<Exit>();
                //doorOpen.isDoorOpen = true;
                locks--;
                //Destroy(lockedDoor);
                lockOpen.Play();
                Destroy(collision.gameObject);
                redKey = redKey - 1f;
                hasRedKey = false;
                Destroy(GameObject.Find("RedKeyBackground"));
                if (locks == 0)
                {
                 
                    GameObject.Find("DoorOpen").GetComponent<Exit>().isDoorOpen = true;
                    Destroy(lockedDoor);
                    isTheDoorOpen = GameObject.Find("DoorOpen").GetComponent<Exit>().isDoorOpen;
                    print(isTheDoorOpen);
                }
               
            }
        }


        if (collision.tag == "YellowLock")
        {
            if (hasYellowKey)
            {
                //GameObject doorOpen = GameObject.Find("DoorOpen");
                //Exit exit = doorOpen.GetComponent<Exit>();
                //doorOpen.isDoorOpen = true;
                locks--;
                //Destroy(lockedDoor);
                lockOpen.Play();
                Destroy(collision.gameObject);
                yellowKey = yellowKey - 1f;
                hasYellowKey = false;
                Destroy(GameObject.Find("YellowKeyBackground"));
                if (locks == 0)
                {
                
                    GameObject.Find("DoorOpen").GetComponent<Exit>().isDoorOpen = true;
                    Destroy(lockedDoor);
                    isTheDoorOpen = GameObject.Find("DoorOpen").GetComponent<Exit>().isDoorOpen;
                    print(isTheDoorOpen);
                }
            }
        }





    }

    private void Movement()
    {
        float hDirection = Input.GetAxis("Horizontal");
        //float vDirection = Input.GetAxis("Vertical");
        //move left
        if (hDirection < 0)
        {
            player.velocity = new Vector2(-speed, player.velocity.y);
            transform.localScale = new Vector2(-1, 1);


        } // move right
        else if (hDirection > 0)
        {
            player.velocity = new Vector2(speed, player.velocity.y);

            transform.localScale = new Vector2(1, 1);

        }
        if (Input.GetButtonDown("Jump") && coll.IsTouchingLayers(ground))
        {
            
            Jump(jumpForce);
        }


      


    }


    private void Jump(float jumpForce)
    {
        //jumping
        player.velocity = new Vector2(player.velocity.x, jumpForce);
        state = State.jumping;
    }



    private void VelocityState()
    {


        if (state == State.jumping)
        {
            if (player.velocity.y < .1f)
            {
                state = State.falling;
            }
        }
        else if (state == State.falling)
        {
            if (coll.IsTouchingLayers(ground))
            {
                state = State.idle;
            }
        }
        else if (state == State.hurt)
        {

            if( Mathf.Abs( player.velocity.x) < .1f)
            {
                state = State.idle;
            } 

        }


        else if (Mathf.Abs(player.velocity.x) > 1f)
        {
            //moving right
            state = State.walking;

        }
        else
        {
            state = State.idle;
        }
    }


    private void Footstep()
    {
        footsteps.Play();
    }


}
