using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;


public class CharacterMovementHelper : MonoBehaviour
{
    // Start is called before the first frame update

    public static Vector3 plankSize;


    private XROrigin xROrigin;
   
    private CharacterController characterController;
    private CharacterControllerDriver driver;

    [SerializeField] private InputActionReference resetPositionActionReference;


    void Start()
    {
        xROrigin = GetComponent<XROrigin>();
        characterController = GetComponent<CharacterController>();
        driver = GetComponent<CharacterControllerDriver>();
        //plank.transform.localScale = plankSize;
        resetPositionActionReference.action.performed += resetPostion;

    }
  
    
private void resetPostion(InputAction.CallbackContext obj)
{

        Debug.Log("before " + characterController.transform.position);
        Debug.Log("before " + characterController.gameObject.transform.position);
        Debug.Log("before " + Camera.main.transform.localPosition);
        Debug.Log("before " + Camera.main.transform.position);
        Debug.Log("before " + xROrigin.CameraInOriginSpacePos);

        Debug.Log("before " + xROrigin.Camera.transform.position);
        Debug.Log("before " + xROrigin.transform.position);
        Debug.Log("before " + driver.transform.position);


        characterController.transform.position = new Vector3(0, 0, 0);
        characterController.gameObject.transform.position = new Vector3(0, 0, 0);
        Camera.main.transform.localPosition = new Vector3(0, 0, 0);
        Camera.main.transform.position = new Vector3(0, 0, 0);
        xROrigin.Camera.transform.position = new Vector3(0, 0, 0);
        xROrigin.transform.position = new Vector3(0, 0, 0);
        driver.transform.position = new Vector3(0, 0, 0);

        //Debug.Log(characterController.);

        Debug.Log(characterController.transform.position);
        Debug.Log(characterController.gameObject.transform.position);
        Debug.Log(Camera.main.transform.localPosition);
        Debug.Log(Camera.main.transform.position);
        Debug.Log(xROrigin.CameraInOriginSpacePos);
        Debug.Log(xROrigin.Camera.transform.position);
        Debug.Log(xROrigin.transform.position);
        Debug.Log(driver.transform.position);




    }
void Update()
    {
        UpdateCharacterController();
    }

    /// <summary>
    /// Updates the <see cref="CharacterController.height"/> and <see cref="CharacterController.center"/>
    /// based on the camera's position.
    /// </summary>
    protected virtual void UpdateCharacterController()
    {
        if (xROrigin == null || characterController == null)
            return;

        var height = Mathf.Clamp(xROrigin.CameraInOriginSpaceHeight, driver.minHeight, driver.maxHeight);

        Vector3 center = xROrigin.CameraInOriginSpacePos;
        center.y = height / 2f + characterController.skinWidth;

        characterController.height = height;
        characterController.center = center;

      

    }


}
