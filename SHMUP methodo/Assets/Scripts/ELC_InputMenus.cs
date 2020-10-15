using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ELC_InputMenus : MonoBehaviour
{
    public bool gamePaused;
    public ELC_CentralDisplay displayScript;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Backspace))
        {
            ChangeScene(0);
        }
        else if(Input.GetKeyDown(KeyCode.P))
        {
            if (!gamePaused)
            {
                displayScript.DisplayMessage("Pause");
                Time.timeScale = 0;
                gamePaused = true;
            }
            else
            {
                displayScript.DeleteMessage();
                Time.timeScale = 1;
                gamePaused = false;
            }
            
        }

    }

    public void ChangeScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex, LoadSceneMode.Single);
    }
}
