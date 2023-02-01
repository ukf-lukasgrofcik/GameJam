using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemode : MonoBehaviour
{

    private GameObject player;
    private GameObject enemyLoc;
    private PlayerHandler pScript;
    private ChoicesScript choicesManager;
    
    public Animator anim;

    public GameObject[] enemy;
    
    public int roomCount;
    public int roundCount;
    public int enemyCount;
    
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        enemyLoc = GameObject.Find("enemy1Pos");
        choicesManager = GameObject.Find("ChoicesManager").GetComponent<ChoicesScript>();
        pScript = player.GetComponent<PlayerHandler>();
        pScript.InitStats();
        Debug.Log("health/damage/armor "+pScript.getHealth()+"/"+pScript.getDamage()+"/"+pScript.getArmor());
        startRoom();

        ///anim = player.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void startRoom()
    {
        ///
        ///
        ///
        
        spawnEnemies();
        nextRound();
    }
    
    void nextRound()
    {
        if (enemyCount==0)
        {
            //end-go to door  
            roundCount = 0;
          
          
            ///later add animation for going to door
            ///anim.Play();
            player.transform.position = enemyLoc.transform.position;

            choicesManager.ShowChoicesScreen("enemy");
        }
        
        
        
        
        
    }

    void spawnEnemies()
    {
        /*for (int i = 0; i < 4; i++)
        {
            
        }*/
        ///make look 
        //Instantiate(enemy,enemyLoc.transform);
    }

}
