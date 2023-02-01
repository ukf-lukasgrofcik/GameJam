using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemode : MonoBehaviour
{
    private GameObject player;
    private GameObject enemyLoc;
    private PlayerHandler pScript;
    
    public Animator anim;

    public GameObject[] enemy;
    private GameObject[,] characters;
    
    
    public int roomCount;
    public int roundCount;
    public int enemyCount;
    
    private float eDMG;
    
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        enemyLoc = GameObject.Find("enemy1Pos");
        pScript = player.GetComponent<PlayerHandler>();
        pScript.InitStats();
        Debug.Log("health/damage/armor "+pScript.health+"/"+pScript.damage+"/"+pScript.armor);
        startRoom();

        ///anim = player.GetComponent<Animator>();
    }
    
    void startRoom()
    {
        ///
        ///
        ///
        
        spawnEnemies();
        setActionOrder();
        
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
            roomEnd();
        }

        roundCount++;

        ///player first
        /// maybe attack animation
        
        enemy[0].GetComponent<EnemyHandler>().health = enemy[0].GetComponent<EnemyHandler>().health - pScript.damage;
        
        
        ///later cycle through enemies
        ///animation for attacking enemy

        for (int i = 0; i < enemyCount; i++)
        {
            eDMG = enemy[1].GetComponent<EnemyHandler>().damage;
            pScript.health = pScript.health - eDMG ;
            if (pScript.health <= 0)
            {
                pScript.kill();
                gameOver();
            }
        }

         

    }

    void spawnEnemies()
    {
        /*for (int i = 0; i < 4; i++)
        {
            
        }*/
        
        ///make look 
        Instantiate(enemy[1],enemyLoc.transform);
    }

    void roomEnd()
    {
        ///getting rewards
    }

    void setActionOrder()
    {
        ///for later
    }

    void gameOver()
    {
        ///ui for losing
    }
}
