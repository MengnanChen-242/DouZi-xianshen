using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scorefollow : MonoBehaviour
{
    public int score = 0;
    // Start is called before the first frame update
    public void addscore()
    {
        score += 100;
    } 
}
