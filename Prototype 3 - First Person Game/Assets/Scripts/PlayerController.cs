using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
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

    void Awake()
    {
        // Get the components
        cam = Camera.main; // Grabbed object, put in a variable
        rb = GetComponent<Rigidbody>();
    }
   
    // Update is called once per frame
    void Update()
    {
        Move();
        CamLook();
        if(Input.GetButtonDown("Jump"))
            Jump();
    }
    void Move()
    {   //Get Keyboard input with move speed
        float x = Input.GetAxis("Horizontal") * moveSpeed;
        float z = Input.GetAxis("Vertical") * moveSpeed;
        // Applying velocity/movement to the rigidbody
        Vector3 dir = transform.right * x + transform.forward * z;
        // Jump direction
        dir = rb.velocity.y;
        // Apply direction to camera movement
        rb.velocity = dir;
    }

    void Jump()
    {
        // Cast ray to ground
        Ray ray = new Ray(transform.position, Vector3.down);
        // Check Ray length to jump
        if(Physics.Raycast(ray, 1.1f))
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
    void CamLook()
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
