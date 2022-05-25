using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class finishCollison : MonoBehaviour

{
    public MenuScript menu;
    //public GameObject plank;
    private void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.name == "XR Origin")
        {


            Debug.Log("collided");

            if (SceneManager.GetActiveScene().buildIndex != 3)
            {
                MenuScript.SaveScene = SceneManager.GetActiveScene().buildIndex;
                menu.Save();
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                Debug.Log("saved");
            }
            else
            {
                MenuScript.SaveScene = SceneManager.GetActiveScene().buildIndex;
                menu.Save();
                Debug.Log("saved last");
                SceneManager.LoadScene(5);
                //game finished
            }
        }
        else if (collision.gameObject.name =="Asteroid")
        {
            //allows the asteroid to go throgh
            Physics.IgnoreCollision(collision.gameObject.GetComponent<Collider>(), GetComponent<Collider>());
        }
        
        
    }
}
