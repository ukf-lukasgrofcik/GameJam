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

    // Start is called before the first frame update
    void Start()
    {
        choicesPanel = GameObject.Find("ChoicesCanvas");
        secondDoorAnimator = GameObject.Find("SecondDoor").GetComponent<Animator>();
        
        choicesPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update() {}

    public void ShowChoicesScreen(string type)
    {
        this.type = type;

        this.text_entity_type.text = type == "enemy" ? "Who will you find in the next room?" : "What loot are you going to find?";

        this.generateChoices();

        /*
        Debug.Log(button_1.GetComponentInChildren<Image>().material);
        Debug.Log(choices[0].material);

        GameObject image_1 = Instantiate(enemy[0], enemyLoc.transform);
        image_1.transform.parent = button_1.transform;
        GameObject image_2 = Instantiate(enemy[0], enemyLoc.transform);
        image_2.transform.parent = button_2.transform;
        GameObject image_3 = Instantiate(enemy[0], enemyLoc.transform);
        image_3.transform.parent = button_3.transform;
        
        button_1.GetComponentInChildren<Image>().material.SetTexture(choices[0].texture);
        button_2.GetComponentInChildren<Image>().material.SetTexture(choices[1].texture);
        button_3.GetComponentInChildren<Image>().material.SetTexture(choices[2].texture);
        
        Debug.Log(button_1.GetComponentInChildren<Image>().material);
        Debug.Log(choices[0].material);
        */
        
        choicesPanel.SetActive(true);
    }

    void generateChoices()
    {
        if (this.type == "enemy") this.choices = getRandomEnemies();
        if (this.type == "item") this.choices = getRandomItems();
    }

    DataScript[] getRandomEnemies()
    {
        string[] enemies = { "Goblin", "Worm", "Stump", "Egg" };
        
        /*
        string randA = enemies[Random.Range(0, enemies.Length - 1)];
        string randB = enemies[Random.Range(0, enemies.Length - 1)];
        while (randB == randA) randB = enemies[Random.Range(0, enemies.Length - 1)];
        string randC = enemies[Random.Range(0, enemies.Length - 1)];
        while (randC == randA || randC == randB) randC = enemies[Random.Range(0, enemies.Length - 1)];
        */
        string randA = enemies[0];
        string randB = enemies[1];
        string randC = enemies[2];
        
        return new DataScript[3]
        {
            GameObject.Find("Goblin").GetComponent<DataScript>(),
            GameObject.Find("Worm").GetComponent<DataScript>(),
            GameObject.Find("Stump").GetComponent<DataScript>(),
        };
    }
    DataScript[] getRandomItems()
    {
        string[] items = { "Apple", "Vaccine", "Peps" };

        /*
        string randA = items[Random.Range(0, items.Length - 1)];
        string randB = items[Random.Range(0, items.Length - 1)];
        while (randB == randA) randB = items[Random.Range(0, items.Length - 1)];
        string randC = items[Random.Range(0, items.Length - 1)];
        while (randC == randA || randC == randB) randC = items[Random.Range(0, items.Length - 1)];
        */
        
        string randA = items[0];
        string randB = items[1];
        string randC = items[2];

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
        
        // set prefs by choice

        if ( type == "enemy" ) {
            choicesPanel.SetActive(false);
            playerAnimator.SetTrigger("enemy_picked");
            secondDoorAnimator.SetTrigger("open");
        }

        if (type == "item") {
            choicesPanel.SetActive(false);
            playerAnimator.SetTrigger("item_picked");
        }
    }
    
}
