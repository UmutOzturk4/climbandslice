using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deneme : MonoBehaviour
{
    public GameObject boss;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(boss, GameObject.FindGameObjectWithTag("lastfloor").transform.position + new Vector3(2.5f, 0.5f, 0.4f), Quaternion.Euler(0, 90, 0));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
