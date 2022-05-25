using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3_satilite : MonoBehaviour
{
    public Transform[] target;
    public float speed;
    private int current;
    public GameObject satalite;
    public float damping = 6.0f;
 
    void Update()
    {
        if (satalite.transform.position != target[current].position)
        {
            Vector3 pos = Vector3.MoveTowards(satalite.transform.position, target[current].position, speed * Time.deltaTime);
            GetComponent<Rigidbody>().MovePosition(pos);
        }
        else
        {
            current = (current + 1) % target.Length;
        }
    }
}
