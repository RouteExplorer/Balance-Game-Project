using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour

{
    public Rigidbody rb;
    public float horizontalInput;
    public float verticalInput;
    public float speed = 6f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        //rb.AddForce(Vector3.right);
        Vector3 movement = new Vector3(horizontalInput, 0.0f, verticalInput);
        rb.AddForce(movement * speed);

        //rb.AddForce(new Vector3(horizontalInput, 0.0f, verticalInput) * speed);
    }
}
