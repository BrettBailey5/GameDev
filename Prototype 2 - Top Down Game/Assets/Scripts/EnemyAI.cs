using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //Trying to filter it out so only the projectile will destroy the object(enemey)
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameobject.CompareTag("Projectile"))
        {
            Destroy(gameObject);
        }
        
    }
}
