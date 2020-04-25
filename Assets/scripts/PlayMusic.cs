using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusic : MonoBehaviour
{
    public AudioClip clip;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    void playmusic()
    {
        GetComponent<AudioSource>().clip = clip;
        GetComponent<AudioSource>().Play();
    }
   
}
