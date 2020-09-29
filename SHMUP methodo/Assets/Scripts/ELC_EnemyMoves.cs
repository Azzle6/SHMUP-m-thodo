using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ELC_EnemyMoves : MonoBehaviour
{
    public float verticalSpeed;
    public float horizontalSpeed;

    private float playerDistanceX;

    public bool followPlayer;
    public bool followPath;
    [SerializeField]
    private GameObject path1;
    [SerializeField]
    private GameObject path2;
    [SerializeField]
    private GameObject path3;
    [SerializeField]
    private GameObject actualFollowedPath;

    [SerializeField]
    private Vector3 enemyDirection;

    private GameObject playerObject;
    private void Start()
    {
        
        playerObject = GameObject.FindGameObjectWithTag("Player");

        if(followPath)
        {
            FollowNextPath(path1);
        }
        else
        {
            enemyDirection = new Vector3(0f, -verticalSpeed);
        }
    }

    void Update()
    {
        if (followPlayer == true)
        {
            playerDistanceX = (playerObject.GetComponent<Transform>().position.x - this.transform.position.x) * 3;
            enemyDirection.x = Mathf.Clamp(playerDistanceX, -horizontalSpeed, horizontalSpeed);
        }
        else if (followPath)
        {
            enemyDirection = Vector3.ClampMagnitude((actualFollowedPath.GetComponent<Transform>().position - this.transform.position)*3, horizontalSpeed);
        }

        this.transform.Translate(enemyDirection * Time.deltaTime);
    }

    private void FollowNextPath(GameObject nextPath)
    {
        actualFollowedPath = nextPath;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (followPath)
        {
            if (path1 != null && collision.gameObject == path1)
            {
                FollowNextPath(path2);
            }
            else if (path2 != null && collision.gameObject == path2)
            {
                FollowNextPath(path3);
            }
        }
    }
}
