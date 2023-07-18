using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    GameObject player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        if (player.transform.position.x > this.transform.position.x && math.round(player.transform.position.y) == math.round(this.transform.position.y))
        {
            this.transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        if (player.transform.position.x < this.transform.position.x && math.round(player.transform.position.y) == math.round(this.transform.position.y))
        {
            this.transform.rotation = Quaternion.Euler(0, -90, 0);
        }
    }
}
