using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;
    public float turnSpeed = 150.0f;

    private float hInput;
    private float vInput;

    public float xRange = 10.5f;
    public float yRange = 4.5f;

    public GameObject projectile;
    public Transform firePoint;

    // Update is called once per frame
    void Update()
    {
        //Setup input connections to keymaps
        vInput = Input.GetAxis("Vertical");
        hInput = Input.GetAxis("Horizontal");
        // Move and rotate player
        transform.Translate(Vector3.up * speed * Time.deltaTime * vInput);
        transform.Rotate(Vector3.back, turnSpeed * hInput * Time.deltaTime);
        // Creates wall on Left Side
        if(transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange,transform.position.y,transform.position.z);
        }
        //Creates wall on Right Side
        if(transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y,transform.position.z);
        }
         // Creates wall on Top
        if(transform.position.y > yRange)
        {
            transform.position = new Vector3(transform.position.x,yRange,transform.position.z);
        }
        //Creates wall on Bottom
        if(transform.position.y < -yRange)
        {
            transform.position = new Vector3(transform.position.x,-yRange,transform.position.z);
        }
        //Hit Spacebar to shoot projectile
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectile, firePoint.transform.position, firePoint.transform.rotation);
        }
    }
}
