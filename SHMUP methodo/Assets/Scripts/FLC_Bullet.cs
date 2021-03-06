﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FLC_Bullet : MonoBehaviour
{
    public bool friendlyBullet;

    public float speed;

    private GameObject playerObject;
    public GameObject explosion;

    void Start()
    {
        if (!friendlyBullet)
        {
            speed = -speed;
        }
        playerObject = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        transform.Translate(new Vector3(0, speed * Time.deltaTime, 0), Space.Self);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Enemy") && friendlyBullet)
        {
            playerObject.GetComponent<ELC_PlayerStats>().Score += other.GetComponent<ELC_EnemyMoves>().scoreEarnedWhenDead;
            Object.Instantiate(explosion, this.transform.position, Quaternion.identity);
            Object.Destroy(other.gameObject);
            Object.Destroy(this.gameObject);
        }
        else if(other.CompareTag("Player") && !friendlyBullet)
        {
            Object.Instantiate(explosion, this.transform.position, Quaternion.identity);
            if(!other.GetComponent<ELC_PlayerStats>().isInvincible)
            {
                other.GetComponent<ELC_PlayerStats>().Lives -= 1;
                other.GetComponent<ELC_PlayerStats>().LaunchInvincibility(2);
            }

            Object.Destroy(this.gameObject);
        }
    }
}
