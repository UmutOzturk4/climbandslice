using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.VisualScripting;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject scriptholder;
    public GameObject player;
    public Movement movement;
    int randomnmbr;
    string hit;
    float horizontalmvmt;
    Animator animator;
    bool hitting;
    bool invoked;
    bool rushed;
    // Start is called before the first frame update
    void Start()
    {
        scriptholder = GameObject.FindGameObjectWithTag("GameController");
        movement = scriptholder.GetComponent<Movement>();
        player = movement.player;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, horizontalmvmt * Time.deltaTime);
        Move(Vector3.Distance(this.transform.position,player.transform.position));
        Debug.Log(Vector3.Distance(this.transform.position,player.transform.position));
        if (Vector3.Distance(this.transform.position, player.transform.position)<2 || !rushed)
        {
            rushed = true;
            RushBack();
        }
    }
    public void Move(float distance)  
    {
        if (distance>3 && !hitting && !rushed)
        {
            animator.SetBool("walkForward",true);
            horizontalmvmt = 1.8f;
            
        }
        else if (distance<2f && movement.animator.GetBool("block") && !hitting)
        {
            RushBack();
        }
        else if (distance < 1.8f && !invoked)
        {
            invoked = true;
            randomnmbr = Random.Range(0,2);
            hit = "hit" + randomnmbr.ToString();
            animator.SetBool(hit,true);
            hitting = true;
            Invoke("CancelAll", 2.7f);
        } 
        /*else 
        {
            CancelAll();
            animator.SetBool("walkBackwards", false);
            animator.SetBool("walkForward", false);
            horizontalmvmt = 0f;
        }*/
    }
    public void RushBack()
    {
        if (Vector3.Distance(this.transform.position, player.transform.position)<8)
        {
            animator.SetBool("walkBackwards", true);
            horizontalmvmt = -1.8f;
        }
        else
        {
            rushed = false;
            animator.SetBool("walkBackwards", false);
            horizontalmvmt = 0f;
        }

    }
    public void CancelAll()
    {
        invoked = false;
        hitting = false;
        animator.SetBool(hit, false);   
    }
}
