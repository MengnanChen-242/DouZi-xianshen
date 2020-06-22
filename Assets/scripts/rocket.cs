using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocket : MonoBehaviour
{
    public GameObject explosion;
    private Enemy enemys;
    private Enemy2 enemy1;
    // Start is called before the first frame update
    void Start()
    {
        enemys = GameObject.Find("Enemy1").GetComponent<Enemy>();
        enemy1 = GameObject.Find("Enemy2").GetComponent<Enemy2>();
    }

    void OnExplode()
    {
        Quaternion randRotation = Quaternion.Euler(0, 0, Random.Range(0f, 360f));
        Instantiate(explosion, transform.position, randRotation);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        enemys = collision.GetComponent<Enemy>();
        enemy1 = collision.GetComponent<Enemy2>();
        if (collision.tag != "Player")
       {
            OnExplode();
            Destroy(gameObject);
        }

        if (collision.tag == "Enemy")
        {
            enemys.Hurt();
        }else if(collision.tag == "Enemy2")
        {
            enemy1.Hurt();
        }
          
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
