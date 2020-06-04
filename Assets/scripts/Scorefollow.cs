using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scorefollow : MonoBehaviour
{
    public int score = 0;
    public Text scoretext;
    public string str;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {

        str = scoretext.text;
    }
}
