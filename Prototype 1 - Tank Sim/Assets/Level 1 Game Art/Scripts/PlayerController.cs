using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;
    public float turnSpeed;
    // Left & Right Input
    public float hInput;
    // Forward & Backward Input
    public float vInput;
    // projectile

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        //Getting button press values for Horizontal & Vertical Inputs
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");

        // Makes the vehicle go Left & Right
        transform.Rotate(Vector3.up, turnSpeed * hInput * Time.deltaTime);
        // Makes the vehicle go Forward & Backward
        transform.Translate(Vector3.forward * speed * Time.deltaTime * vInput);
    }
}
