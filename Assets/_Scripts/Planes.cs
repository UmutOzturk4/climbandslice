using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Planes : MonoBehaviour
{
    public GameObject[] planes;
    GameObject theplane;
    float speed = 40;
    float sayac = 0;
    bool pc=true;
    Vector3 startpos0= new Vector3(-250,120,600);
    Vector3 startpos1 = new Vector3(200, 120, 600);
    void Update()
    {
        if (sayac<=0)
        {
            planeinstantiate();
        }
        sayac -= Time.deltaTime;
        if (pc)
        {
            theplane.transform.position -= transform.right * speed * Time.deltaTime;
        }
        else if (!pc)
        {
            theplane.transform.position += transform.right * speed * Time.deltaTime;
        }
        
    }
    public void planeinstantiate()
    {
        if (pc)
        {
            Destroy(theplane);
            theplane = Instantiate(planes[Random.Range(0, 3)], startpos0, Quaternion.Euler(0, 90, 0));
            pc=false;
        }
        else if (!pc)
        {
            Destroy(theplane);
            theplane = Instantiate(planes[Random.Range(0, 3)], startpos1, Quaternion.Euler(0, -90, 0));
            pc=true;
        }      
        sayac = 15;
    }
}
