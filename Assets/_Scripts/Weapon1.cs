using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon1 : MonoBehaviour
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
            GetComponent<BoxCollider>().enabled = false;
            movement.hittaken();
            hittaken = true;
            Invoke("weaponcollider",3f);
        }
    }
    public void weaponcollider()
    {
        hittaken = false;
    }
}
