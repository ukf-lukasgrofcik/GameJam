using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHandler : MonoBehaviour
{
    public float health;
    public float damage;
    public int armor;
    public int speed;
    
    // Start is called before the first frame update
    void Start()
    {
        health = Random.Range(5f, 10f);
        damage = Random.Range(2f, 4f);
        armor = Random.Range(0, 1);
        speed = Random.Range(1, 6);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void kill()
    {
        Destroy(this);
    }

}
