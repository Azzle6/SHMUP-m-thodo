using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ELC_PlayerStats : MonoBehaviour
{
    public int Lives;
    public float Score;
    public ELC_CentralDisplay displayScript;

    // Start is called before the first frame update
    void Start()
    {
        Lives = 3;
    }

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
