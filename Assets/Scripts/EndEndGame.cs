using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndEndGame : MonoBehaviour
{

    private Animator afterImageAnimator;

    void Start()
    {
        afterImageAnimator = GameObject.Find("AfterImage").GetComponent<Animator>();
    }
    
    void startAfterImage()
    {
        StartCoroutine(wait());
    }
    
    IEnumerator wait()
    {
        yield return new WaitForSeconds(2);

        afterImageAnimator.SetTrigger("fade");
    }
    
}
