using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingHealth : MonoBehaviour
{
    float DestroyTime = 2f;
    Vector3 Offset= new Vector3 (0,1.7f,0);
    void Start()
    {
        Destroy(this.gameObject,DestroyTime);
        transform.localPosition += Offset;
    }
}
