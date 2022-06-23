using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class finishCollison : MonoBehaviour

{
    public MenuScript menu;
    public GameObject plank;
    private CharacterController characterController;
    private void Start()
    {
        //characterController = GetComponent<CharacterController>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "XR Origin") 
        {

            //teleport to next level

            Debug.Log("collided");
            if (SceneManager.GetActiveScene().buildIndex != 3)
            {
                MenuScript.SaveScene = SceneManager.GetActiveScene().buildIndex;
                MenuScript.plank = plank.transform.localScale;
                menu.Save();
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                
                characterController.gameObject.transform.position = new Vector3(0, 0, 0) ;

                //reset player position to 0,0,0 
                Debug.Log("WORKS!!!!");
            }
            else
            {
                SceneManager.LoadScene(4);
                //game finished
            }
            

        }
        
        
    }
}
