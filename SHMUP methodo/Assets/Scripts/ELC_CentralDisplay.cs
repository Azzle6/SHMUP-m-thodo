using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ELC_CentralDisplay : MonoBehaviour
{
    public GameObject CentralTextObject;
    public GameObject ScoreTextObject;
    public GameObject LivesTextObject;
    public ELC_PlayerStats playerStatsScript;
    public bool isActivated;

    private void Start()
    {
        isActivated = false;
    }

    private void Update()
    {
        DisplayScore();
        DisplayLives();
        if (isActivated) CentralTextObject.gameObject.SetActive(true);
        else CentralTextObject.gameObject.SetActive(false);
    }

    private void DisplayScore()
    {
        ScoreTextObject.GetComponent<Text>().text = "Score : " + playerStatsScript.Score.ToString();
    }

    private void DisplayLives()
    {
        LivesTextObject.GetComponent<Text>().text = "Lives : " + playerStatsScript.Lives.ToString();
    }

    public void DisplayMessage(string message)
    {
        isActivated = true;
        CentralTextObject.GetComponent<Text>().text = message;
    }
}
