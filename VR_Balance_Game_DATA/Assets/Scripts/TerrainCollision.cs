using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 


public class TerrainCollision : MonoBehaviour
{
    public MenuScript menu;
    void Update()
    {
        MenuScript.SaveScene = SceneManager.GetActiveScene().buildIndex;
       
        var height = Camera.main.transform.position.y;
       
        if (height <= -40)
        {
            Debug.Log(height);
            Debug.Log("game OVer");
            menu.Save();

            SceneManager.LoadScene("GameOver");
        }
    }
}
