using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{

    private Animator playerAnimator;
    private Animator firstDoorAnimator;
    
    public bool starter_door = false;
    
    void Start()
    {
        playerAnimator = GameObject.Find("Player").GetComponent<Animator>();
        firstDoorAnimator = GameObject.Find("FirstDoor").GetComponent<Animator>();

        if (starter_door) {
            firstDoorAnimator.SetTrigger("open");
        }
    }

    void onDoorOpen(string trigger)
    {
        Debug.Log(trigger);
        playerAnimator.SetTrigger(trigger);
    }

}
