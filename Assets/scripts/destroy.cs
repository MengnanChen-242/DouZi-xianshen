using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy : MonoBehaviour
{
    public AudioClip[] lalala;
    public GameObject good;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void destroyGameObject()
    {
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void hello()
    {
        good.GetComponent<Scorefollow>().score += 100;
        int i = Random.RandomRange(0, lalala.Length);
        GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>().clip = lalala[i];
        GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>().Play();
    }
}
