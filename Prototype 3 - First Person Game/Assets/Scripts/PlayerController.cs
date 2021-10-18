using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
// Declaring variables
    // Movement
    public float moveSpeed; // How fast the player moves
    public float jumpForce; // How high the player jumps
    // Camera
    public float lookSensitivity; // Mouse movement sensitivity
    public float maxLookX; // How low we can look 81
    public float minLookX; // How high we can look 75
    private float rotX; // Current x rotation of the camera
    //Components
    private Camera cam; // 
    private Rigidbody rb; // 
    private Weapon weapon;

    void Awake()
    {
        // Get the components
        cam = Camera.main; // Grabbed object, put in a variable
        rb = GetComponent<Rigidbody>();
        weapon = GetComponent<Weapon>();
    }
   
    // Update is called once per frame
    void Update()
    { 
        Move();
        CamLook(); //Call in you're variables to run them per frame in the game
        // Jump Button
        if(Input.GetButtonDown("Jump")) // When using an If statement, you don't need {} if it's just 1 line of code.
            Jump();
        // Fire Button
        if(Input.GetButton("Fire1"))
        {
            if(weapon.CanShoot())
                weapon.Shoot();
        }
    }
    void Move()
    {   //Get Keyboard input with move speed
        float x = Input.GetAxis("Horizontal") * moveSpeed;
        float z = Input.GetAxis("Vertical") * moveSpeed;
        // Applying velocity/movement to the rigidbody
        Vector3 dir = transform.right * x + transform.forward * z;
        // Jump direction
        dir.y = rb.velocity.y;
        // Apply direction to camera movement
        rb.velocity = dir;
    }
    void Jump()
    {
        // Cast ray to ground
        Ray ray = new Ray(transform.position, Vector3.down);
        // Check Ray length to jump
        if(Physics.Raycast(ray, 1.1f))
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); //ForceMode means we're applying all force at once, NOT gradually
    }
    private void CamLook() //if you don't pick an access motifier, it's private by default.
    {  
        //Get mouse input so we can look around with the mouse
        float y = Input.GetAxis("Mouse X") * lookSensitivity;
        rotX += Input.GetAxis("Mouse Y") * lookSensitivity;

        // Clamp/Limit the vertical rotation of the camera
        rotX = Mathf.Clamp(rotX, minLookX, maxLookX);

        // Applying the rotation to Camera
        cam.transform.localRotation = Quaternion.Euler(-rotX, 0, 0);
        transform.eulerAngles += Vector3.up * y;
    }
}
