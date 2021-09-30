using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool hasKey;
    public bool isDoorLocked;

    // Start is called before the first frame update
    void Start()
    {
        hasKey = false;
        isDoorLocked = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Player unlocks the door and exits the room
        if(hasKey && isDoorLocked == false) // or you could doo if(hasKey && !isDoorLocked)
        {
            print("You open the door and leave the room!");
        }
    }
}
