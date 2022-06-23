using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 


public class TerrainCollision : MonoBehaviour
{
    // Start is called before the first frame update
 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MenuScript.SaveScene = SceneManager.GetActiveScene().buildIndex;
       
        var height = Camera.main.transform.position.y;
       
        if (height <= -40)
        {
            Debug.Log("game OVer");
            SceneManager.LoadScene("GameOver");
        }
    }
}
