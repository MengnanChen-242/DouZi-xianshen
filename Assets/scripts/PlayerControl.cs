﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerControl : MonoBehaviour
{
    public float MoveForce = 400f;
    public float MaxSpeed = 5f;
    public float jumpForce = 500f;
    public AudioClip[] JumpClips;
    public AudioMixer mixer;

    [HideInInspector]
    public bool jump = false;

    private AudioSource audio1;
    private Transform groundCheck;
    private Rigidbody2D heroBody;
    [HideInInspector]
    public bool faceRight = true;
    private bool grounded = false;

    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        heroBody = GetComponent<Rigidbody2D>();
        groundCheck = transform.Find("GroundCheck");
        anim = GetComponent<Animator>();
        audio1 = GetComponent<AudioSource>();
    }


    void FixedUpdate()
    {
        //获取水平方向输入
        float input = Input.GetAxis("Horizontal");
        if(input * heroBody.velocity.x < MaxSpeed)
        {
            heroBody.AddForce(Vector2.right * input * MoveForce);
        }
        if(Mathf.Abs(heroBody.velocity.x) > MaxSpeed)
        {
            heroBody.velocity = new Vector2(Mathf.Sign(heroBody.velocity.x)
                * MaxSpeed, heroBody.velocity.y);
        }
        
        
        if(input > 0 && faceRight == false)
        {
            filp();
        }
        if(input < 0 && faceRight == true)
        {
            filp();
        }
        if (jump)
        {
            anim.SetTrigger("jump");
            heroBody.AddForce(new Vector2(0, jumpForce));
            jump = false;

            if(audio1 != null)
            {
                if (!audio1.isPlaying)
                {
                    int i = Random.RandomRange(0, JumpClips.Length);
                    audio1.clip = JumpClips[i];
                    audio1.Play();
                    mixer.SetFloat("Herovolume", 0);
                }
            }
            
        }
        anim.SetFloat("speed", Mathf.Abs(input));
    }
    // Update is called once per frame
    void Update()
    {
        grounded = Physics2D.Linecast(transform.position, groundCheck.position,
                                        1 << LayerMask.NameToLayer("Ground"));
        if(Input.GetButtonDown("Jump") && grounded)
        {
            jump = true;
        }
    }
    void filp()
    {
        faceRight = !faceRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public void addScore()
    {
        RankListRead rankList = new RankListRead();
        rankList.AddScore();
    }
}
