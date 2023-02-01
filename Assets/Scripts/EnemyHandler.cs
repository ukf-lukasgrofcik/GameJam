using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyHandler : MonoBehaviour
{
    public int health;
    public int damage;
    public int armor;
    public int speed;
    
    // Start is called before the first frame update
    void Start()
    {
        health = Random.Range(5, 10);
        damage = Random.Range(2, 4);
        armor = Random.Range(0, 1);
        speed = Random.Range(1, 6);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void kill()
    {
        Destroy(this);
    }
    

}
