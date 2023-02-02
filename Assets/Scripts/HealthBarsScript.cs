using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarsScript : MonoBehaviour
{
    
    public GameObject currentBar;
    public PlayerHandler playerHandler;
    private EnemyHandler enemyHandler;
    private bool is_enemy = false;
    
    // Start is called before the first frame update
    void Start()
    {
        enemyHandler = gameObject.GetComponent<EnemyHandler>();

        if (enemyHandler != null)
        {
            currentBar = GameObject.Find("EnemyHealthBarCurrent");
            is_enemy = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float current = 1;

        if (playerHandler != null) current = (0f + playerHandler.health) / playerHandler.max_health;
        if (enemyHandler != null) current = (0f + enemyHandler.health) / enemyHandler.max_health;
        
        currentBar.GetComponent<RectTransform>().sizeDelta = new Vector2 (200 * current, 30);
    }

    public void GotKilled()
    {
        currentBar.GetComponent<RectTransform>().sizeDelta = new Vector2 (0, 30);
    }

}
