using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float movespeed = 2f;
    public int HP = 2;
    public Sprite deadEnemy;           //死亡后灰色图片
    public Sprite hurtedEnemy;         //受伤后图片
    public GameObject UI_100Points;    //怪物死后的得分
    public float deathSpinMin = -100f; //怪物死后旋转量
    public float deathSpinMax = 100f;


    private Transform frontCheck;
    private SpriteRenderer ren;        //负责更换对应图片的
    private Rigidbody2D enemyBody;     //敌人的2D刚体
    private bool bDeath = false;       //标识敌人已经死了
    // Start is called before the first frame update
    void Start()
    {
        frontCheck = transform.Find("frontCheck");
        ren = transform.Find("alienShip").GetComponent<SpriteRenderer>();
        enemyBody = GetComponent<Rigidbody2D>();
    }


    void flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }


    public void Hurt()
    {
        HP--;
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        int nlayer = 1 << LayerMask.NameToLayer("wall");
        Collider2D[] frontHits = Physics2D.OverlapPointAll(frontCheck.position, nlayer);
        foreach(Collider2D c in frontHits)
        {
            if(c.tag == "wall")
            {
                flip();
                break;
            }
        }
        enemyBody.velocity = new Vector2(movespeed * transform.localScale.x, enemyBody.velocity.y);

        if(HP == 1 && hurtedEnemy != null)
            ren.sprite = hurtedEnemy;
        if (HP == 0 && !bDeath)
            Death();
    }


    void Death()
    {
        SpriteRenderer[] renders = GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer s in renders)
            s.enabled = false;

        ren.enabled = true;

        if (deadEnemy != null)
            ren.sprite = deadEnemy;

        enemyBody.AddTorque(Random.Range(deathSpinMin, deathSpinMax));
        Collider2D[] colliders = GetComponents<Collider2D>();
        for (int i = 0; i < colliders.Length; i++)
        {
            colliders[i].isTrigger = true;
        }

        if(UI_100Points != null)
        {
            Vector3 ScorePos;
            ScorePos = transform.position;
            ScorePos.y += 1.6f;
            Instantiate(UI_100Points, ScorePos, Quaternion.identity);
        }
        bDeath = true;
    }
}
