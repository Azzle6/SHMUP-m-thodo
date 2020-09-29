using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ELC_PlayerStats : MonoBehaviour
{
    public int Lives;
    public float Score;
    public ELC_CentralDisplay displayScript;



    // Update is called once per frame
    void Update()
    {
        if(Lives <= 0)
        {
            displayScript.DisplayMessage("Game Over");
            Object.Destroy(this.gameObject);
        }
    }
}
