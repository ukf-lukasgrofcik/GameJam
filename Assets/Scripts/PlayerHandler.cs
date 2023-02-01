using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    private float health;
    private float damage;
    private int armor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitStats()
    {
        health = Random.Range(5f, 10f);
        damage = Random.Range(2f, 4f);
        armor = Random.Range(0, 1);
    }

    public float getHealth()
    {
        return health;
    }
    
    public float getDamage()
    {
        return damage;
    }
    
    public int getArmor()
    {
        return armor;
    }
}
