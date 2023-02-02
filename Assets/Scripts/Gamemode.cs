using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemode : MonoBehaviour
{

    private GameObject player;
    private GameObject enemyLoc;
    private PlayerHandler pScript;
    private ChoicesScript choicesManager;

    public Animator playerAnimator;
    public GameObject endGamePanel;

    public GameObject[] enemy;
    private GameObject[,] characters;
    private GameObject[] enemies;

    public int roomCount;
    public int roundCount;
    public int enemyCount;
    
    private int eDMG;
    private int eHP;
    
    
    // Start is called before the first frame update
    void Start()
    {
        endGamePanel.SetActive(false);
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
        
        //nextRound();
    }
    
    public void nextRound()
    {

        Debug.Log("nextRound");
        
        if (enemyCount > 0)
        {
            roundCount++;
            
            eHP = enemies[0].GetComponent<EnemyHandler>().health;
            Debug.Log(eHP);

            if (eHP - pScript.damage <= 0)
            {
                enemyCount--;
                Destroy(enemies[0]);
                Debug.Log("player killed enemy");
            }
            else
            {
                enemies[0].GetComponent<EnemyHandler>().health = eHP - pScript.damage;
            }

            ///later cycle through enemies
            ///animation for attacking enemy

            for (int i = 0; i < enemyCount; i++)
            {
                eDMG = enemies[i].GetComponent<EnemyHandler>().damage;
                pScript.health = pScript.health - eDMG;
                if (pScript.health <= 0)
                {
                    pScript.kill();
                    gameOver();
                    return;
                }
            }
            
            StartCoroutine(wait());

            return;
        }
        
        endCombat();
    }

    void spawnEnemies()
    {
        /*for (int i = 0; i < 4; i++)
        {
            
        }*/
        
        ///make look
        enemies = new GameObject[]
        {
            Instantiate(enemy[0],enemyLoc.transform)
        };

        enemyCount++;
    }

    void endCombat()
    {
        playerAnimator.SetTrigger("combat_ended");
    }

    public void showPickItems()
    {
        choicesManager.ShowChoicesScreen("item");
    }
    
    public void showPickEnemies()
    {
        choicesManager.ShowChoicesScreen("enemy");
    }

    void setActionOrder()
    {
        ///for later
    }

    void gameOver()
    {
        ///ui for losing
    }

    public void endLevel()
    {
        endGamePanel.SetActive(true);
        endGamePanel.GetComponent<Animator>().SetTrigger("end");
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(1);

        nextRound();
    }
}
