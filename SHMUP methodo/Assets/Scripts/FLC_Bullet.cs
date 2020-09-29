using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FLC_Bullet : MonoBehaviour
{
    public bool friendlyBullet;

    public float speed;

    private GameObject playerObject;

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
            Object.Destroy(other.gameObject);
            Object.Destroy(this.gameObject);
        }
        else if(other.CompareTag("Player") && !friendlyBullet)
        {
            other.GetComponent<ELC_PlayerStats>().Lives -= 1;
            Object.Destroy(this.gameObject);
        }
    }
}
