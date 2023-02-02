using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControllerScript : MonoBehaviour
{

    public TMP_Text tutorialText;
    bool yes = true;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startGame()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("current_level", 1);
        PlayerPrefs.SetString("next_enemy", "GoblinPrefab");
        SceneManager.LoadScene("SampleScene");
    }

    public void tutorial()
    {
        
        if (yes)
        {
            tutorialText.alpha = 1;
            yes = false;
        }
        else
        {
            tutorialText.alpha = 0;
            yes = true;
        }

        
    }

    public void exit()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        ///Application.Quit(); ///for built game
    }
}
