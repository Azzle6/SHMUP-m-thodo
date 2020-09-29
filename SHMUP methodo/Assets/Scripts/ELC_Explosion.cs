using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ELC_Explosion : MonoBehaviour
{
    private Animator animator;
    void Start()
    {
        animator = this.GetComponent<Animator>();
        StartCoroutine("PlayAndDestroy");
    }

    IEnumerator PlayAndDestroy()
    {
        animator.SetBool("Activate", true);
        yield return new WaitForSeconds(0.5f);
        Object.DestroyImmediate(this.gameObject);
    }
}
