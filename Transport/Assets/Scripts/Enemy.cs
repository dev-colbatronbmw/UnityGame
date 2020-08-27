using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    protected Animator anim;
    protected AudioSource deathSound;


    // Start is called before the first frame update
    protected virtual void Start()
    {
        Animator anim = GetComponent<Animator>();
        deathSound = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void JumpedOn()
    {
        deathSound.Play();
        anim.SetTrigger("death");
       

    }

    private void Death()
    {
     
        Destroy(this.gameObject);
    }



}
