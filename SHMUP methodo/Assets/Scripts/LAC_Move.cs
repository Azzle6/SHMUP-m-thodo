using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LAC_Move : MonoBehaviour
{

    public float speed;
    public Vector2 camBoundMin, camBoundMax;

    Rigidbody2D rb;
    Camera cam;
    Vector2 dir;
   
    // Start is called before the first frame update
    void Start()
    {
        // get Cam Bound
        GameObject mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        cam = mainCamera.GetComponent<Camera>();

        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        dir = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
       
    }

    private void FixedUpdate()
    {
        Vector2 targetVelocity = dir * speed * Time.deltaTime;
        Vector2 velocity;

        velocity.x = (transform.position.x + targetVelocity.x < camBoundMax.x &&
        transform.position.x + targetVelocity.x > camBoundMin.x) ? targetVelocity.x : -targetVelocity.x * 0.2f;

        velocity.y = (transform.position.y + targetVelocity.y < camBoundMax.y &&
        transform.position.y + targetVelocity.x > camBoundMin.y) ? targetVelocity.y : -targetVelocity.y * 0.2f;

        transform.position += (Vector3)velocity;
    }
}
