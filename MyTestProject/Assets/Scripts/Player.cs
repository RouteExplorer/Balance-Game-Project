using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour

{
    public Rigidbody rb; // instantiates the balls physics property
    public float horizontalInput; //
    public float verticalInput; // 
    public float speed = 6f; // sets ball speed

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); // initailies the ball first
    }

    //updates every frame
    private void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal"); // takes the horizontal input
        verticalInput = Input.GetAxis("Vertical"); // takes the vertical input into the function

        Vector3 movement = new Vector3(horizontalInput, 0.0f, verticalInput); // creates a new function of the horizontal and vertical position movement
        rb.AddForce(movement * speed); // force is added to the ball at each coodinate and multipled by the speed to add the movement

    }
}
