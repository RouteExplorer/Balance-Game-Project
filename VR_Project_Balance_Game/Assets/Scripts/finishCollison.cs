using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class finishCollison : MonoBehaviour

{
    private void OnCollisionEnter(Collision collision)
    {
   
        
        if (collision.gameObject.name == "XR Origin") 
        {
            //play level complete sound
            //teleport to next level
            MenuScript.SaveScene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Debug.Log("WORKS!!!!");

        }
        
        
    }
}
