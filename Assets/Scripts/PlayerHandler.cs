using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    public float health;
    public float damage;
    public int armor;
    public int speed;

    private Gamemode gamemode;

    // Start is called before the first frame update
    void Start()
    {
        gamemode = GameObject.Find("SceneManager").GetComponent<Gamemode>();
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
        speed = Random.Range(1, 6);
    }

    public void kill()
    {
        Destroy(this);
    }

    void onMovedToPickItems()
    {
        gamemode.showPickItems();
    }
    
    void onMovedToPickEnemies()
    {
        gamemode.showPickEnemies();
    }
    
}
