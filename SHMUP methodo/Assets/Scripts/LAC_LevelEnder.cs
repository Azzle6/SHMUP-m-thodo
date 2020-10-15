using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LAC_LevelEnder : MonoBehaviour
{
    public int sceneIndex;
    private ELC_CentralDisplay displayScript;
    private bool coroutineIsActivated;

    private void Update()
    {
        displayScript = GameObject.Find("Canvas Manager").GetComponent<ELC_CentralDisplay>();
        if (!coroutineIsActivated) StartCoroutine("Congratulations");
    }

    IEnumerator Congratulations()
    {
        coroutineIsActivated = true;
        Debug.Log("Activation");
        displayScript.DisplayMessage("CONGRATULATIONS !!!");
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(sceneIndex/*SceneManager.GetActiveScene().buildIndex*/);
    }
}
