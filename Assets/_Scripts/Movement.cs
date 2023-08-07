using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    GameObject scriptholder;
    Movement movement;

    public GameObject FloatingHealth;
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

    public Slider secondSlider;
    public Slider slider;
    public Text timer;
    public Animator animator;

    public int rage = 0;
    int playerHealth=100;
    public int hitcount=1;
    private bool timerstart;
    
    private float time;
    public float speed=1;
    private float horizontalmvmt = 0;
    
    public Rigidbody rb;
    Vector3 pos = new Vector3(-16, 0.90f, 0);
    void Start()
    {      
        player = Instantiate(char1, pos, Quaternion.Euler(0, 90, 0));
        playerfoot= GameObject.FindGameObjectWithTag("foot");
        rb = player.GetComponent<Rigidbody>();
        animator = player.GetComponent<Animator>();
        playerfoot.AddComponent<Jump>();
        playerWeapon = GameObject.FindGameObjectWithTag("playerweapon");
        scriptholder = GameObject.FindGameObjectWithTag("playerhealth");
        slider = scriptholder.GetComponent<Slider>();
        secondSlider = GameObject.FindGameObjectWithTag("rage").GetComponent<Slider>();
        
        playerdead = false;
    }
    void Update()
    {
        slider.value = playerHealth;
        secondSlider.value = rage;
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
            player.GetComponent<BoxCollider>().enabled = false;
            rb.constraints = RigidbodyConstraints.FreezeAll;
            Invoke("afterdeath",4);
        }
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
                hitcount++;
                animator.SetBool("hit1", true);
                Invoke("hitstop", 1f);
                time = 0;
            }
            else if (hitcount == 2)
            {
                hitcount++;
                animator.SetBool("hit2", true);
                Invoke("hitstop", 1f);
                time = 0;
            }
            else if (hitcount == 3 && secondSlider.value>=50)
            {
                hitcount = 1;
                rage = 0;
                animator.SetLayerWeight(1, 0);
                animator.SetBool("hit3", true);
                Invoke("hitstop", 1f);
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
        playerWeapon.GetComponent<BoxCollider>().enabled = false;
        
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
                rage += 15;
                Invoke("cancel", 0.3f);
                // enemy stun
            }
            else if (!animator.GetBool("block"))
            {
                playerHealth -= 30;
                rage += 10;
                animator.SetBool("hittaken", true);                
                Invoke("cancel", 0.2f);
                ShowDamage();
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
    public void ShowDamage()
    {
        var go = Instantiate(FloatingHealth,player.transform.position, Quaternion.identity);
        go.GetComponent<TextMesh>().text = "-30";
    }
}
