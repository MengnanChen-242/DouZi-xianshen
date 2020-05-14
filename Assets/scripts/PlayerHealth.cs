using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health = 100f;
    public float damageInterval = 0.35f;
    public float hurtForce = 100f;
    public float DamageAmount = 10f;

    private SpriteRenderer healthBar;
    private float lastHurtTime;
    private Vector3 healthScale;
    private PlayerControl playerControl;
    private Rigidbody2D heroBody;
    private Animator anim;
    // Start is called before the first frame update

    void Awake()
    {
        healthBar = GameObject.Find("HealthBar").GetComponent<SpriteRenderer>();
        heroBody = GetComponent<Rigidbody2D>();
        playerControl = GetComponent<PlayerControl>();
        healthScale = healthBar.transform.localScale;
        anim = transform.root.gameObject.GetComponent<Animator>();

    }
    void Start()
    {
        
    }
    public void UpdateHealthBar()
    {
        healthBar.material.color = Color.Lerp(Color.green, Color.red, 1- health * 0.01f);
        healthBar.transform.localScale = new Vector3(healthScale.x * health * 0.01f, 1, 1); 
    }
    void TakeDamage(Transform EnemyTran)
    {
        playerControl.jump = false;
        Vector3 hurtVector3 = transform.position - EnemyTran.position + Vector3.up*5f;
        heroBody.AddForce(hurtForce*hurtVector3);

        health -= DamageAmount;
        UpdateHealthBar();
    }
    void Death()
    {
        anim.SetTrigger("Death");
        Collider2D[] colliders = GetComponents<Collider2D>();
        for (int i = 0; i < colliders.Length; i++)
        {
            colliders[i].isTrigger = true;
        }
        SpriteRenderer[] sprites = GetComponentsInChildren<SpriteRenderer>();
        for (int i = 0; i < sprites.Length; i++)
        {
            sprites[i].sortingLayerName = "character";
        }
        playerControl.enabled = false;
        GetComponent<Gun>().enabled = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            if(Time.time > lastHurtTime + damageInterval)
            {
                if(health > 0)
                {
                    TakeDamage(collision.gameObject.transform);
                    lastHurtTime = Time.time;
                    if(health <= 0)
                    {
                        Death();
                    }
                }
                else
                {
                    Death();
                }
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
