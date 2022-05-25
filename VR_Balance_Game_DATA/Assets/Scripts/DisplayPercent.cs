using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;
using Unity.XR.CoreUtils;
using UnityEngine.SceneManagement;

public class DisplayPercent : MonoBehaviour
{

    public GameObject display;
    public Text textDisplay;
    public GameObject end;
    public GameObject tp;
    public GameObject plank;
    private bool displayOn;

    void Update()
    {

        Vector3 camFloor = new Vector3(0.0f, 0.0f, Camera.main.transform.position.z);
        Vector3 tpFloor = new Vector3(0.0f, 0.0f, tp.transform.position.z);
        Vector3 endFloor = new Vector3(0.0f, 0.0f, tp.transform.position.z + plank.transform.localScale.z);
        Text ButtonText = display.GetComponentInChildren<Text>();


        Vector3 vHeadPos = Camera.main.transform.position;
        Vector3 vGazeDir = Camera.main.transform.forward;
        display.transform.position = (vHeadPos + vGazeDir * 3.0f) + new Vector3(0.0f, -.40f, -0.3f);


        Vector3 vRot = Camera.main.transform.eulerAngles;
        vRot.z = 0;
        display.transform.eulerAngles = vRot;

        float d = Vector3.Distance(camFloor, tpFloor);
        if (d < 0.5)
        { displayOn = true; }

        else if (displayOn != true && SceneManager.GetActiveScene().buildIndex == 1)
        {
            ButtonText.text = "Aim Controller Near The Sqaure And Press To Teleport";
            ButtonText.fontSize = 50;
        }

        if (displayOn == true)
        {
            
            float dist = Mathf.Round((Vector3.Distance(camFloor, endFloor)) / 2 * 100f) / 100f;
            dist.ToString();
            ButtonText.text = dist + "m";
            ButtonText.fontSize = 100;
        }
    }
}
