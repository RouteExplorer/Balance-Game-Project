using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    public GameObject plank;
    public Text LengthText;
    public Text WidthText;

    private void Update()
    {
        //if button press then check reverse the state of the canvas (if false make it true)

        
        //pauseMenu.SetActive(false);
    }

    public void showLength(float value) 
    {
        LengthText.text = Mathf.Round((value/2) * 100f) / 100f + "m";
    }
    public void showWidth(float value)
    {
        WidthText.text = Mathf.Round(value*100) + "cm";
    }
    public void Length(float value)
    {
        plank.transform.localScale = new Vector3((value/2),plank.transform.localScale.y, plank.transform.localScale.z);
    }
    public void Width(float value)
    {
        plank.transform.localScale = new Vector3(plank.transform.localScale.x, plank.transform.localScale.y, value);
    }
}
