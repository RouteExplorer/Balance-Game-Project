using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class level3_force : MonoBehaviour
{
    public GameObject obj;
    public GameObject start;
    public GameObject end;
    
    void Update()
    {
        movForward();
    }
    private void movForward() 
    {
       obj.transform.position += obj.transform.forward * Time.deltaTime * 4;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "endObj")
        {
            Vector3 center = start.transform.position;
            Vector3 size = start.transform.localScale;

            obj.transform.position = center + new Vector3(Random.Range(-size.x / 4, size.x / 4), Random.Range(-size.x / 4, size.x / 4), 1);

        }

        MenuScript.SaveScene = SceneManager.GetActiveScene().buildIndex;

        if (collision.gameObject.name == "XR Origin")
        {
            Debug.Log("crash");
            SceneManager.LoadScene("GameOver");
        }


    }
}
