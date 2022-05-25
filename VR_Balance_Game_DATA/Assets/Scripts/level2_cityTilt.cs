using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level2_cityTilt : MonoBehaviour
{
    public float speed;

    void Update()
    {
        float rY = Mathf.SmoothStep(-8, 8, Mathf.PingPong(Time.time * speed, 1));

        float rx = Mathf.SmoothStep(-3, 3, Mathf.PingPong(Time.time * speed, 1));

        transform.rotation = Quaternion.Euler(rx, -85, rY);
        
    }
}
