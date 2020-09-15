using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FLC_Shoot : MonoBehaviour
{
    public GameObject bulletSpawnPosition;
    public GameObject bulletToSpawn;

    public bool isPlayer;
    public bool shoot;
    bool inCooldown;

    [SerializeField]
    float cadence;

    private void Start()
    {
        inCooldown = false;
    }

    void Update()
    {
        if(Input.GetButton("Fire1") && isPlayer)
        {
            shoot = true;
        }
        else if(this.CompareTag("Enemy") == false)
        {
            shoot = false;
        }

        if(shoot) ShootFonction();
    }

    public void ShootFonction()
    {
        if(!inCooldown)
        {
            Instantiate(bulletToSpawn, bulletSpawnPosition.transform.position, bulletSpawnPosition.transform.rotation);
            inCooldown = true;
            StartCoroutine(Cooldown());
        }
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(cadence);
        inCooldown = false;
    }
}
