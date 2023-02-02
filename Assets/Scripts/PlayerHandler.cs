using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerHandler : MonoBehaviour
{
    public int health;
    public int damage;
    public int armor;
    public int speed;

    private Gamemode gamemode;
    private Animator firstDoorAnimator;
    private Animator secondDoorAnimator;

    // Start is called before the first frame update
    void Start()
    {
        gamemode = GameObject.Find("SceneManager").GetComponent<Gamemode>();
        firstDoorAnimator = GameObject.Find("FirstDoor").GetComponent<Animator>();
        secondDoorAnimator = GameObject.Find("SecondDoor").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitStats()
    {
        health = Random.Range(5, 10);
        damage = Random.Range(2, 4);
        armor = Random.Range(0, 1);
        speed = Random.Range(1, 6);
    }

    public void kill()
    {
        Destroy(this);
    }

    void onMovedToCombat()
    {
        firstDoorAnimator.SetTrigger("close");
        gamemode.nextRound();
    }
    void onMovedToPickItems()
    {
        gamemode.showPickItems();
    }
    
    void onMovedToPickEnemies()
    {
        gamemode.showPickEnemies();
    }
    
    void onMovedToEnd()
    {
        secondDoorAnimator.SetTrigger("close");
    }
    
}
