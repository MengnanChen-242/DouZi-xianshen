using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickButton : MonoBehaviour
{
    private bool State = true;
    public GameObject lala;
    // Start is called before the first frame update
   
    
    public void click()
    {
        if(State == false)
        {
            lala.SetActive(true);
            State = true;
        }
        else
        {
            lala.SetActive(false);
            State = false;
        }
    }
}
