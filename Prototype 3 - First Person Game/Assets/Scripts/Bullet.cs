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
