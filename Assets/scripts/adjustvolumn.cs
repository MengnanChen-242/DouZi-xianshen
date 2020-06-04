using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class adjustvolumn : MonoBehaviour
{
    public Slider volumeslider;
    public AudioMixer adMixer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void turnVolume()
    {
        adMixer.SetFloat("MasterVolume", volumeslider.value);
    }
}
