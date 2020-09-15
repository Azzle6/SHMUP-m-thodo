using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FLC_Bullet : MonoBehaviour
{
    public bool friendlyBullet;

    public float speed;

    void Start()
    {
        if (!friendlyBullet)
        {
            speed = -speed;
        }
    }

    void Update()
    {
        transform.Translate(new Vector3(0, speed * Time.deltaTime, 0), Space.Self);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Enemy") && friendlyBullet)
        {
            Object.Destroy(other.gameObject);
            Object.Destroy(this.gameObject);
        }
        else if(other.CompareTag("Player") && !friendlyBullet)
        {
            Object.Destroy(GameObject.FindGameObjectWithTag("Player"));
            Object.Destroy(this.gameObject);
        }
    }
}
