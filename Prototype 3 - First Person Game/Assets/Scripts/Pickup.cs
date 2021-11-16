using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PickupType // Only a few things will be outside the class & this is one of them.
{
    Health,
    Ammo
}

public class Pickup : MonoBehaviour
{
    public PickupType type;
    public int value;

    // Start is called before the first frame update
    void Start()
    {
        
    }



    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>(); //Player's gonna be stored in the variable 'player'

            switch(type)
            {
                case PickupType.Health:
                    player.GiveHealth(value);
                    break;
                case PickupType.Ammo:
                    player.GiveAmmo(value);
                    break;
            }

            Destroy(gameObject);
        }
    }

}
