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

    private string[,] choices;
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

        this.text_entity_type.text = type == "enemy" ? "Pick enemy" : "Pick item";

        this.generateChoices();

        // set images of buttons
        choicesPanel.SetActive(true);
    }

    void generateChoices()
    {
        if (this.type == "enemy") {
            this.choices = new string[3,2]
            {
                { "John Doe", "Normálny človek\nŠpeciálne schopnosti:\nŽiadne" },
                { "Lukáš Grofčík", "Tlstý človek\nŠpeciálne schopnosti:\nVeľké brucho +5 health" },
                { "Lukáš Hajda", "Tlstý človek\nŠpeciálne schopnosti:\nVeľké brucho +5 health\nVeľké prsia +5 strength" }
            };
        }
        
        if (this.type == "item") {
            this.choices = new string[3,2]
            {
                { "A", "AA" },
                { "B", "BB" },
                { "C", "CC" },
            };
        }
    }

    public void ShowChoiceInfo(int choice)
    {
        this.current_choice = choice;
        
        this.entity_name.text = this.choices[this.current_choice,0];
        this.entity_description.text = this.choices[this.current_choice,1];

        this.entity_panel.SetActive(true);
    }

    public void PickChoice()
    {
        Debug.Log("Your choice is: " + this.choices[this.current_choice, 0]);

        // set prefs by choice

        if ( type == "enemy" ) {
            // change scene
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
