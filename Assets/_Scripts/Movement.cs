using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    GameObject scriptholder;
    Movement movement;

    public GameObject char1;
    public GameObject char2;
    public GameObject player;
    public GameObject movementui;
    public GameObject restartui;
    public GameObject playerWeapon;
    GameObject playerfoot;

    public bool inAir;
    public bool canPass;
    public bool playerdead;

    public Slider slider;
    public Text timer;
    public Animator animator;

    int playerHealth=100;
    private int hitcount=1;
    private bool timerstart;
    
    private float time;
    public float speed=1;
    private float horizontalmvmt = 0;
    
    public Rigidbody rb;
    Vector3 pos = new Vector3(-16, 0.90f, 0.3f);
    void Start()
    {      
        player = Instantiate(char1, pos, Quaternion.Euler(0, 90, 0));
        playerfoot= GameObject.FindGameObjectWithTag("foot");
        rb = player.GetComponent<Rigidbody>();
        animator = player.GetComponent<Animator>();
        playerfoot.AddComponent<Jump>();
        scriptholder = GameObject.FindGameObjectWithTag("playerhealth");
        slider =scriptholder.GetComponent<Slider>();
        playerWeapon = GameObject.FindGameObjectWithTag("playerweapon");
        playerdead = false;
    }
    void Update()
    {
        slider.value = playerHealth;
        Input.GetAxis("Horizontal");
        if (time >= 1.5f)
        {
            timerstart = false;
            hitcount = 1;
            time = 0;
        }
        if (timerstart)
        {
            time += Time.deltaTime;
        }
        player.transform.Translate(0, 0, horizontalmvmt * Time.deltaTime);
        if (playerHealth<=0)
        {
            animator.Play("Death");
            playerdead = true;
            Invoke("afterdeath",4);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
    }
    public void Goleft()
    {
        if (!animator.GetBool("hit3") && !playerdead)
        {
            player.transform.rotation = Quaternion.Euler(0, -90, 0);
            horizontalmvmt = 2;
            animator.SetBool("isWalking", true);
        }
    }
    public void Goright()
    {
        if (!animator.GetBool("hit3") && !playerdead)
        {
            player.transform.rotation = Quaternion.Euler(0, 90, 0);
            horizontalmvmt = 2;
            animator.SetBool("isWalking", true);
        }
    }
    public void Stop()
    {
        horizontalmvmt = 0;
        animator.SetBool("isWalking", false);
        
    }
    public void jump()
    {

        if (rb.velocity.y == 0 && !playerdead)
        {
            canPass = true;
            animator.SetBool("jump", true);
            rb.AddForce(0, 400, 0);                 
        }

    }
    public void hit()
    {
        if (!playerdead)
        {
            playerWeapon.GetComponent<BoxCollider>().enabled = true;
            timerstart = true;
            if (hitcount == 1)
            {
                animator.SetBool("hit1", true);
                Invoke("hitstop", 1f);
                hitcount++;
                time = 0;
            }
            else if (hitcount == 2)
            {
                animator.SetBool("hit2", true);
                Invoke("hitstop", 1f);
                hitcount++;
                time = 0;
            }
            else if (hitcount == 3)
            {
                animator.SetLayerWeight(1, 0);
                animator.SetBool("hit3", true);
                Invoke("hitstop", 1f);
                hitcount = 1;
                time = 0;
                timerstart = false;
                Invoke("fullcombohit", 1f);
            }
        }
    }
    public void hitstop()
    {
        animator.SetBool("hit1", false);
        animator.SetBool("hit2", false);
        
    }
    public void shield()
    {
        if (!playerdead)
        {
            animator.SetBool("block", true);
            speed = 0.1f;
        }
    }
    public void shieldlower()
    {
        animator.SetBool("block", false);
        speed = 1 ;
    }
    public void fullcombohit()
    {
        animator.SetLayerWeight(1, 1);
        animator.SetBool("hit3", false);
    }
    public void hittaken()
    {
        if (!playerdead)
        {
            if (animator.GetBool("block"))
            {
                animator.SetBool("Blocked", true);
                Invoke("cancel", 0.3f);
                // enemy stun
            }
            else if (!animator.GetBool("block"))
            {
                playerHealth -= 30;
                animator.SetBool("hittaken", true);
                Invoke("cancel", 0.2f);
            }
        }
    }
    public void cancel()
    {
        animator.SetBool("Blocked", false);
        animator.SetBool("hittaken", false);
    }
    public void afterdeath()
    {
        movementui.SetActive(false);
        restartui.SetActive(true);
    }
}
