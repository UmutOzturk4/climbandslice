using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.LowLevel;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public GameObject sliderobj;
    public GameObject weapon;
    public GameObject weapon1;
    public GameObject scriptholder;
    Slider slider;
    Animator animator;
    bool invoked = false;
    int health=100;
    private string randomnmbr="1";
    private string randomhit;

    void Start()
    {
        animator = GetComponent<Animator>();
        slider = sliderobj.GetComponent<Slider>();
        scriptholder = GameObject.FindGameObjectWithTag("GameController");
    }
    void Update()
    {
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
                   Invoke("cancel", 1.5f);
                   invoked = true;
                }
                
              
            }          
        }
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }     
    }
    public void cancel()
    {
        animator.SetBool(randomhit, false);
        randomnmbr = "" + Random.Range(1, 3);
        invoked = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("playerweapon"))
        {
            health -= 50;
            scriptholder.GetComponent<Movement>().playerWeapon.GetComponent<BoxCollider>().enabled=false;
        }
    }
}
