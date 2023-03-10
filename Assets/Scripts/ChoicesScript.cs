using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChoicesScript : MonoBehaviour
{
    
    public TMP_Text text_entity_type;
    public Button button_1;
    public Button button_2;
    public Button button_3;
    
    private GameObject choicesPanel;
    public GameObject entity_panel;
    public TMP_Text entity_name;
    public TMP_Text entity_description;

    private int current_choice;

    private DataScript[] choices;
    private string type;
    public Animator playerAnimator;
    private Animator secondDoorAnimator;
    private PlayerHandler playerHandler;
    
    // Start is called before the first frame update
    void Start()
    {
        choicesPanel = GameObject.Find("ChoicesCanvas");
        secondDoorAnimator = GameObject.Find("SecondDoor").GetComponent<Animator>();
        playerHandler = GameObject.Find("Player").GetComponent<PlayerHandler>();
        
        choicesPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update() {}

    public void ShowChoicesScreen(string type)
    {
        Debug.Log("Level " + PlayerPrefs.GetInt("current_level"));
        
        if (type == "enemy" && PlayerPrefs.GetInt("current_level") == 4) {
            PlayerPrefs.SetString("next_enemy", "BossPrefab");
            playerAnimator.SetTrigger("enemy_picked");
            secondDoorAnimator.SetTrigger("open");

            return;
        }
        
        this.type = type;

        this.text_entity_type.text = type == "enemy" ? "Who will you find in the next room?" : "What loot are you going to find?";

        this.generateChoices();

        
        
        choicesPanel.SetActive(true);
        
        button_1.GetComponent<Image>().sprite = choices[0].Esprite;
        button_2.GetComponent<Image>().sprite = choices[1].Esprite;
        button_3.GetComponent<Image>().sprite = choices[2].Esprite;
    }

    void generateChoices()
    {
        if (this.type == "enemy") this.choices = getRandomEnemies();
        if (this.type == "item") this.choices = getRandomItems();
    }

    DataScript[] getRandomEnemies()
    {
        return new DataScript[3]
        {
            GameObject.Find("Goblin").GetComponent<DataScript>(),
            GameObject.Find("Worm").GetComponent<DataScript>(),
            GameObject.Find( Random.Range(0, 3) == 1 ? "Stump" : "Egg" ).GetComponent<DataScript>(),
        };
    }
    DataScript[] getRandomItems()
    {
        return new DataScript[3]
        {
            GameObject.Find("Apple").GetComponent<DataScript>(),
            GameObject.Find("Vaccine").GetComponent<DataScript>(),
            GameObject.Find("Peps").GetComponent<DataScript>(),
        };
    }

    public void ShowChoiceInfo(int choice)
    {
        Debug.Log(choice);
        current_choice = choice;
        Debug.Log(current_choice);
        Debug.Log(choices);
        Debug.Log(choices[current_choice]);
        Debug.Log(choices[current_choice].name);
        Debug.Log(choices[current_choice].description);
        entity_name.text = choices[current_choice].name;
        entity_description.text = choices[current_choice].description;

        this.entity_panel.SetActive(true);
    }

    public void PickChoice()
    {
        Debug.Log("Your choice is: " + this.choices[this.current_choice]);

        this.entity_panel.SetActive(false);
        
        if ( type == "enemy" ) {
            PlayerPrefs.SetString("next_enemy", choices[current_choice].name + "Prefab");
            choicesPanel.SetActive(false);
            playerAnimator.SetTrigger("enemy_picked");
            secondDoorAnimator.SetTrigger("open");
        }

        if (type == "item") {
            choicesPanel.SetActive(false);
            playerAnimator.SetTrigger("item_picked");

            string item_name = this.choices[this.current_choice].name;
            if ( item_name == "Apple" ) {
                playerHandler.health += 3;
                playerHandler.max_health += 3;
                PlayerPrefs.SetInt("player_health", playerHandler.health);
                PlayerPrefs.SetInt("player_max_health", playerHandler.max_health);
                PlayerPrefs.SetInt("player_damage", playerHandler.damage);
            } else if ( item_name == "Vaccine" ) {
                playerHandler.max_health += 5;
                PlayerPrefs.SetInt("player_max_health", playerHandler.max_health);
                PlayerPrefs.SetInt("player_damage", playerHandler.damage);
                PlayerPrefs.SetInt("player_health", playerHandler.health);
            } else if ( item_name == "Peps" ) {
                playerHandler.damage += 5;
                PlayerPrefs.SetInt("player_damage", playerHandler.damage);
                PlayerPrefs.SetInt("player_health", playerHandler.health);
                PlayerPrefs.SetInt("player_max_health", playerHandler.max_health);
            }
            
        }
    }
    
}
