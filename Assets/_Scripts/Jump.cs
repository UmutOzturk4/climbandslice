using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    GameObject scriptholder;
    Movement movement;
    // Start is called before the first frame update
    void Start()
    {
        scriptholder = GameObject.FindGameObjectWithTag("GameController");
        movement = scriptholder.GetComponent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag.Equals("floor")|| other.gameObject.tag.Equals("mainfloor"))
        {
            movement.animator.SetBool("jump", false); 
        }
    }
}
