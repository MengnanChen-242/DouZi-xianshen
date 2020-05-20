using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Remover : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject splash;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>().enabled = false;
        }
        Instantiate(splash, collision.transform.position, transform.rotation);
        Destroy(collision.gameObject);
    }

    
}
