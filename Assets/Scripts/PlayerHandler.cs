using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerHandler : MonoBehaviour
{

	public GameObject __POOF__;

    public int health;
    public int max_health;
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
		if ( PlayerPrefs.HasKey("player_health") ) health = PlayerPrefs.GetInt("player_health");
		if ( PlayerPrefs.HasKey("player_max_health") ) max_health = PlayerPrefs.GetInt("player_max_health");
		if ( PlayerPrefs.HasKey("player_damage") ) damage = PlayerPrefs.GetInt("player_damage");

		PlayerPrefs.SetInt("player_health", health);
		PlayerPrefs.SetInt("player_max_health", max_health);
		PlayerPrefs.SetInt("player_damage", damage);
    }

    public void kill()
    {
		gameObject.GetComponent<HealthBarsScript>().GotKilled();
		GameObject poof = Instantiate (__POOF__, gameObject.transform.position, gameObject.transform.rotation);
		poof.transform.localScale = gameObject.transform.localScale;
        Destroy(gameObject);
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
        gamemode.endLevel();
    }
    
}
