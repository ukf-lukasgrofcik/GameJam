using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameScript : MonoBehaviour
{

    void onEndScreenEnd()
    {
        SceneManager.LoadScene("SampleScene");
    }

}
