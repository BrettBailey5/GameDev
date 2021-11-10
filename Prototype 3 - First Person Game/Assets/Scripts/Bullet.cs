using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;
    public float lifeTime;
    private float shootTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        //Did we hit the target aka player
        if(other.CompareTag("Player"))
            other.GetComponent<PlayerController>().TakeDamage(damage);
            else
                if(other.CompareTag("Enemy"))
                    other.GetComponent<Enemy>().TakeDamage(damage);
            //Disable Bullet
            gameObject.SetActive(false);
    }
    void OnEnable()
    {
        shootTime = Time.time;
    }
    // Update is called once per frame
    void Update()
    {
        if(Time.time - shootTime >= lifeTime)
            gameObject.SetActive(false);
            // Setting active true makes it visible and usable, THIS is saying "Make it false" meaning our shoot time is "We can't shoot yet

    }
}
