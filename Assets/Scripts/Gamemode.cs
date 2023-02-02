using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemode : MonoBehaviour
{

	public GameObject __POOF__;

	private GameObject endEndGameCanvas;
	private GameObject winGame;
	private GameObject loseGame;

    private GameObject player;
    private GameObject enemyLoc;
    private PlayerHandler pScript;
    private ChoicesScript choicesManager;

    public Animator playerAnimator;
    public GameObject endGamePanel;

    public GameObject goblinPrefab;
    public GameObject stumpPrefab;
    public GameObject eggPrefab;
    public GameObject wormPrefab;
    public GameObject bossPrefab;

    private GameObject[,] characters;
    private GameObject[] enemies;

	private bool is_boss_fight = false;
    public int roomCount;
    public int roundCount;
    public int enemyCount;
    
    private int eDMG;
    private int eHP;
    
    
    // Start is called before the first frame update
    void Start()
    {
		endEndGameCanvas = GameObject.Find("EndEndGameCanvas");
		winGame = GameObject.Find("WinImage");
		loseGame = GameObject.Find("LoseImage");
		endEndGameCanvas.SetActive(false);

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
				GameObject destruct = enemies[0];
				destruct.GetComponent<HealthBarsScript>().GotKilled();
				GameObject poof = Instantiate (__POOF__, destruct.transform.position, destruct.transform.rotation);
				poof.transform.localScale = destruct.transform.localScale;
                Destroy(destruct);
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

		GameObject enemy = null;
		if ( PlayerPrefs.GetString("next_enemy") == "GoblinPrefab" ) enemy = goblinPrefab;
		if ( PlayerPrefs.GetString("next_enemy") == "StumpPrefab" ) enemy = stumpPrefab;
		if ( PlayerPrefs.GetString("next_enemy") == "EggPrefab" ) enemy = eggPrefab;
		if ( PlayerPrefs.GetString("next_enemy") == "WormPrefab" ) enemy = wormPrefab;
		if ( PlayerPrefs.GetString("next_enemy") == "BossPrefab" ) {
			is_boss_fight = true;
			enemy = bossPrefab;
		}

		if ( enemy == null ) enemy = goblinPrefab;

        enemies = new GameObject[]
        {
            Instantiate(enemy, enemyLoc.transform)
        };

        enemyCount++;
    }

    void endCombat()
    {
		if ( is_boss_fight ) { // WIN
			endEndGameCanvas.SetActive(true);
			loseGame.SetActive(false);
        	winGame.GetComponent<Animator>().SetTrigger("fade");
        	winGame.GetComponent<AudioScript>().Play();
			return;
		}

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
		endEndGameCanvas.SetActive(true);
		winGame.SetActive(false);
        loseGame.GetComponent<Animator>().SetTrigger("fade");
        loseGame.GetComponent<AudioScript>().Play();
    }

    public void endLevel()
    {
		int current_level = PlayerPrefs.GetInt("current_level");
		PlayerPrefs.SetInt("current_level", current_level + 1);

        endGamePanel.SetActive(true);
        endGamePanel.GetComponent<Animator>().SetTrigger("end");
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(1);

        nextRound();
    }
}
