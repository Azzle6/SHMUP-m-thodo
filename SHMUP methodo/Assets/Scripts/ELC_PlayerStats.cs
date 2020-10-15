using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ELC_PlayerStats : MonoBehaviour
{
    public int Lives;
    public float Score;
    public ELC_CentralDisplay displayScript;
    public float ScoreToWinALife = 50;
    private float NextScoreNeeded;

    public bool isInvincible;
    public float invincibilityTime = 4;


    private void Start()
    {
        NextScoreNeeded = ScoreToWinALife;
    }

    // Update is called once per frame
    void Update()
    {
        if(Lives <= 0)
        {
            displayScript.DisplayMessage("Game Over");
            Object.Destroy(this.gameObject);
        }

        if(Score >= NextScoreNeeded)
        {
            NextScoreNeeded += ScoreToWinALife;
            Lives += 1;
        }

        
    }

    public void LaunchInvincibility(float time)
    {
        StartCoroutine(Invincibility(time));
    }

    public IEnumerator Invincibility(float time)
    {
        Debug.Log("invincible");
        isInvincible = true;
        yield return new WaitForSeconds(time);
        isInvincible = false;
    }
}
