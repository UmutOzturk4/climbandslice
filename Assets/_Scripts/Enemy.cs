using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.LowLevel;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public GameObject FloatingHealth;
    public GameObject sliderobj;
    public GameObject weapon;
    public GameObject weapon1;
    public GameObject scriptholder;
    Movement movement;

    Slider slider;
    Animator animator;

    bool invoked = false;
    int health=100;
    private string randomnmbr="1";
    private string randomhit;
    private int damageTaken;

    void Start()
    {
        animator = GetComponent<Animator>();
        slider = sliderobj.GetComponent<Slider>();
        scriptholder = GameObject.FindGameObjectWithTag("GameController");
        movement = scriptholder.GetComponent<Movement>();
    }
    void Update()
    {
        Physics.IgnoreLayerCollision(9, 4, true);
        if (movement.rb.velocity.y > 1)
        {
            Physics.IgnoreLayerCollision(9, 7, true);
        }
        else if (movement.rb.velocity.y < 1)
        {
            Physics.IgnoreLayerCollision(9, 7, false);
        }
        slider.value = health;
        randomhit = "hit" + randomnmbr;
        Ray ray = new Ray(transform.position, transform.TransformDirection(Vector3.forward));
        if (Physics.Raycast(ray, out RaycastHit hitInfo, 1.2f))
        {
            if (hitInfo.collider.gameObject.tag.Equals("Player"))
            {
                if (randomnmbr == "1" && !weapon.GetComponent<Weapon>().hittaken)
                {
                    weapon.GetComponent<BoxCollider>().enabled = true;
                }
                if (randomnmbr == "2" && !weapon1.GetComponent<Weapon1>().hittaken)
                {
                    weapon1.GetComponent<BoxCollider>().enabled = true;
                }
                animator.SetBool(randomhit, true);
                if (!invoked)
                {
                    invoked = true;
                    Invoke("cancel", 3f);
                }                              
            }          
        }
        if (health <= 0)
        {
            Destroy(this.gameObject);
            movement.score += 10;
        }            
    }
    public void cancel()
    {
        animator.SetBool(randomhit, false);
        randomnmbr = "" + Random.Range(1, 3);
        invoked = false;
    }
    public void ShowDamage()
    {
        var go = Instantiate(FloatingHealth,transform.position,Quaternion.identity);
        go.GetComponent<TextMesh>().text = damageTaken.ToString();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("playerweapon"))
        {
            
            TakeDamage(movement.hitcount);

            movement.rage += 15;
            movement.playerWeapon.GetComponent<BoxCollider>().enabled=false;
            if (FloatingHealth)
            {
                ShowDamage();
            }
        }
    }
    public void TakeDamage(int hit)
    {
        if (hit == 2)
        {
            damageTaken = 40;
            movement.score += 80;
        }
        else if (hit == 3)
        {
            damageTaken = 60;
            movement.score += 120;
        }
        else if (hit == 1)
        {
            damageTaken = 100;
            movement.score += 200;
        }
        health -= damageTaken;
    }
}
