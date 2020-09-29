using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NAC_PlayerMove : MonoBehaviour
{
    [SerializeField]
    float speed;

    Camera cam;
    public Vector2 camBoundMin, camBoundMax;

    // Start is called before the first frame update
    void Start()
    {
        GameObject mainCam = GameObject.FindGameObjectWithTag("MainCamera");
        cam = mainCam.GetComponent<Camera>();
        this.GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        // get direction from input
        Vector2 dir = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Vector2 targetVelocity = dir * speed * Time.deltaTime;

        // apply direction
        transform.position += (Vector3)targetVelocity;
    }


}
