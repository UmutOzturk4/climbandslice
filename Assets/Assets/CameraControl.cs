using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    private float speed;
    float timer = 10;
    public GameObject scriptholder;
    private void Start()
    {
        speed = 0.2f;
    }
    void Update()
    {      
            if (!scriptholder.GetComponent<Movement>().playerdead && !scriptholder.GetComponent<restartControl>().gameEnded)
            {
                transform.position += transform.up * speed * Time.deltaTime;
            }
            timer -= Time.deltaTime;
            if (timer < 0 && speed < 0.5F)
            {
                timer = 8;
                speed += 0.1f;
            }
    }
}
