using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Camera cam;
    private float speed;
    float timer = 10;
    public GameObject scriptholder;
    public GameObject bottomBorder;
    public GameObject topBorder;
    private void Start()
    {
        speed = 0.2f;
    }
    void Update()
    {
     /* if (!IsTargetVisible(cam, scriptholder.GetComponent<Movement>().player.transform.GetChild(5).gameObject))
        {
            scriptholder.GetComponent<Movement>().afterdeath();
            scriptholder.GetComponent<Movement>().playerdead = true;
        }*/
      //if (cam.transform.position.y>=GameObject.FindGameObjectWithTag("lastfloor").transform.position.y)
        //{ }
      if (!scriptholder.GetComponent<Movement>().playerdead && !scriptholder.GetComponent<nextLevelControl>().gameEnded)
      {
            transform.position += speed * Time.deltaTime * transform.up;
            bottomBorder.transform.position += speed * Time.deltaTime * transform.up;
            topBorder.transform.position += speed * Time.deltaTime * transform.up;
        }
      timer -= Time.deltaTime;
      if (timer < 0 && speed < 0.5F)
      {
           timer = 8;
           speed += 0.1f;
      }
    }
    bool IsTargetVisible(Camera c, GameObject go)
    {
        var planes = GeometryUtility.CalculateFrustumPlanes(c);
        var point = go.transform.position;
        foreach (var plane in planes)
        {
            if (plane.GetDistanceToPoint(point) < 0)
            return false;
        }
        return true;
    }
}
