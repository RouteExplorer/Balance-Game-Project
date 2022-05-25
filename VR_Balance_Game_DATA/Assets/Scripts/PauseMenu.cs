using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject plank;
    public Text LengthText;
    public Text WidthText;
    public GameObject menu;
    [SerializeField] private InputActionReference pauseActionReference;

    private void Start()
    {
        pauseActionReference.action.performed += OnPause;
    }
    private void OnPause(InputAction.CallbackContext obj)
    {
        menu.SetActive(!menu.activeSelf);
        Vector3 vHeadPos = Camera.main.transform.position;
        Vector3 vGazeDir = Camera.main.transform.forward;
        menu.transform.position = (vHeadPos + vGazeDir * 3.0f) + new Vector3(0.0f, -.40f, 0.0f);
        Vector3 vRot = Camera.main.transform.eulerAngles; vRot.z = 0;
        menu.transform.eulerAngles = vRot;
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
        plank.transform.localScale = new Vector3(plank.transform.localScale.x, plank.transform.localScale.y, value);
    }
    public void Width(float value)
    {
        plank.transform.localScale = new Vector3((value / 2), plank.transform.localScale.y, plank.transform.localScale.z);
        
    }
}
