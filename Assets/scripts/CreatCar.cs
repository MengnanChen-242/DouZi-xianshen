using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatCar : MonoBehaviour
{
    int i;
    int y;
    bool active = false;
    public GameObject[] car;
    public int between = 3; 
    void Spawn()
    {
        if (i < 50)
        {
            Instantiate(car[0], transform.position, transform.rotation);
        }
        else
        {
            Instantiate(car[1], transform.position, transform.rotation);
        }
        i = Random.RandomRange(0, 100);

    }

    void Update()
    {
        int x = System.DateTime.Now.Second;
        if(x % between == 0 && active == false)
        {
            Spawn();
            active = true;
            y = x;
        }
        else
        {
            if(System.DateTime.Now.Second != y)
            {
                active = false;
            }
        }
    }
}
