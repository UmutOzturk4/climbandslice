using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    GameObject scriptholder;
    Movement movement;
    void Start()
    {
        scriptholder = GameObject.FindGameObjectWithTag("GameController");
        movement = scriptholder.GetComponent<Movement>();
    }
    void Update()
    {
        if (movement.rb.velocity.y>1)
        {
            Physics.IgnoreLayerCollision(6,7,true);
        }
        else if (movement.rb.velocity.y < 1)
        {
            Physics.IgnoreLayerCollision(6, 7, false);
        }
    }
}
