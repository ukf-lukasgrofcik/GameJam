using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{

    public bool playOnStart = false;
    
    private AudioSource audioData;
    
    // Start is called before the first frame update
    void Start()
    {
        audioData = GetComponent<AudioSource>();

        if ( playOnStart ) {
            audioData.Play(0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play()
    {
        audioData.Play(0);
    }
    
}
