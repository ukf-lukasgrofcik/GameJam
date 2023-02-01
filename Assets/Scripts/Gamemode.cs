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
    private GameObject[,] characters;
    
    
    public int roomCount;
    public int roundCount;
    public int enemyCount;
    
    private int eDMG;
    private int eHP;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        enemyLoc = GameObject.Find("chooseEnemyPosition");
        choicesManager = GameObject.Find("ChoicesManager").GetComponent<ChoicesScript>();
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

        while (enemyCount > 0)
        {
            
            roundCount++;
            Debug.Log("round number>" + roundCount);

            ///player first
            /// maybe attack animation

            StartCoroutine(wait());
            
            
            eHP = enemy[0].GetComponent<EnemyHandler>().health;
            if (eHP - pScript.damage <= 0)
            {
                enemyCount--;
                enemy[0].GetComponent<EnemyHandler>().kill();
                Debug.Log("player killed enemy");
            }
            else
            {
                enemy[0].GetComponent<EnemyHandler>().health = eHP - pScript.damage;
                Debug.Log("player dealt " + pScript.damage + " to first enemy");
                Debug.Log("enemy has now " + (eHP - pScript.damage) + " health");
            }

            ///later cycle through enemies
            ///animation for attacking enemy

            for (int i = 0; i < enemyCount; i++)
            {
                eDMG = enemy[i].GetComponent<EnemyHandler>().damage;
                pScript.health = pScript.health - eDMG;
                if (pScript.health <= 0)
                {
                    pScript.kill();
                    gameOver();
                    return;
                }
            }
        }
        
        
    }

    void spawnEnemies()
    {
        /*for (int i = 0; i < 4; i++)
        {
            
        }*/
        
        ///make look 
        Instantiate(enemy[0],enemyLoc.transform);
        enemyCount++;
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

    IEnumerator wait()
    {
        yield return new WaitForSeconds(1);
    }
}
