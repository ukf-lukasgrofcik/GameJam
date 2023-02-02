using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{

    private GameObject player;
    private Animator playerAnimator;
    private Animator firstDoorAnimator;
    
    public bool starter_door = false;
    
    void Start()
    {
		player = GameObject.Find("Player");
        playerAnimator = GameObject.Find("Player").GetComponent<Animator>();
        firstDoorAnimator = GameObject.Find("FirstDoor").GetComponent<Animator>();

        if (starter_door) {
            firstDoorAnimator.SetTrigger("open");
        }
    }

    void onDoorOpen(string trigger)
    {
		if ( trigger == "first_door_open" ) {
			player.GetComponent<AudioScript>().Play();
		}

        playerAnimator.SetTrigger(trigger);
    }

}
