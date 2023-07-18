using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    GameObject scriptholder;
    Movement movement;
    public bool hittaken=false;
    void Start()
    {
        scriptholder = GameObject.FindGameObjectWithTag("GameController");
        movement = scriptholder.GetComponent<Movement>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            movement.hittaken();
            hittaken = true;
            GetComponent<BoxCollider>().enabled = false;
            Invoke("weaponcollider",1f);
        }
    }
    public void weaponcollider()
    {
       // GetComponent<BoxCollider>().enabled = true; 
        hittaken = false;
    }
}
