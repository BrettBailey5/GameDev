using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public ObjectPool bulletPool;
    
    public Transform muzzle;
    [Header ("Ammunition")]
    public int curAmmo;
    public int maxAmmo;
    public int mag;
    public bool infiniteAmmo;
    [Header ("Bullet Speed")]
    public float bulletSpeed;
    [Header ("Other")]
    public float shootRate;
    public float lastShootTime;
    private bool isPlayer;


    void Awake()
    {
        // Check to see if we're attached to the player
        if(GetComponent<PlayerController>())
        {
            isPlayer = true;
        }
    }
    // Can we shoot a bullet
    public bool CanShoot() //Using this as a checking device and returning a value (you can't return a value on void) 
    {
        if(Time.time - lastShootTime >= shootRate)
        {
            if(curAmmo > 0 || infiniteAmmo == true) // || means OR
            {
                return true;
            }
        }
        return false;
    }

    public void Shoot()
    {
        // Adjust shoot time and reduce ammo by one
        lastShootTime = Time.time;
        curAmmo --;
        // Create projectile
        GameObject bullet = bulletPool.GetObject();
        bullet.transform.position = muzzle.position;
        bullet.transform.rotation = muzzle.rotation;

        // Set Velocity of bulletProjectile
        bullet.GetComponent<Rigidbody>().velocity = muzzle.forward * bulletSpeed;
    }
}
