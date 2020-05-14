﻿using UnityEngine;
using System.Collections;

public class BombPickup : MonoBehaviour
{
    private PickupSpawner pickupSpawner;
    private Animator anim;              // Reference to the animator component.
    private bool landed = false;        // Whether or not the crate has landed yet.

    void Awake()
    {
        anim = transform.root.GetComponent<Animator>();
        pickupSpawner = GameObject.Find("PickupSpawner").GetComponent<PickupSpawner>();
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        // 炸弹还在半空被接住
        if (other.tag == "Player")
        {
            // 销毁炮弹
            Destroy(transform.root.gameObject);
            pickupSpawner.StartCoroutine(pickupSpawner.DeliverPickup());
        }
        // 掉地上
        else if (other.tag == "ground" && !landed)
        {
            anim.SetTrigger("Land");
            transform.parent = null;
            gameObject.AddComponent<Rigidbody2D>();
            landed = true;
        }
    }
}