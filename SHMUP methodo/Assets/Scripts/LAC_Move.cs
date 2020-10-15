using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LAC_Move : MonoBehaviour
{

    public float speed, mouseSpeed;
    public Vector2 camBoundMin, camBoundMax;
    float camWidth, camHeight;
    Rigidbody2D rb;
    Camera cam;
    Vector2 dir;
   
    // Start is called before the first frame update
    void Start()
    {
        // get Cam Bound
        GameObject mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        cam = mainCamera.GetComponent<Camera>();

        camWidth = 1 / (cam.WorldToViewportPoint(new Vector3(1, 1, 0)).x - 0.5f);
        camHeight = 1 / (cam.WorldToViewportPoint(new Vector3(1, 1, 0)).y - 0.5f);

        camBoundMin = new Vector2(-camWidth / 2, -camHeight / 2);
        camBoundMax = new Vector2(camWidth / 2, camHeight / 2);

        rb = GetComponent<Rigidbody2D>();


        
    }

    // Update is called once per frame
    void Update()
    {

        dir = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;

        if (Input.GetMouseButton(1))
            dir = (cam.ScreenToWorldPoint(Input.mousePosition) - transform.position) * mouseSpeed;
        

    }

    private void FixedUpdate()
    {
        
        Vector2 targetVelocity = dir * speed * Time.deltaTime;
        Vector2 velocity = targetVelocity;

        // clamp position
        if (transform.position.x + velocity.x > camBoundMax.x)
            velocity.x = 0;
          
        if (transform.position.x + velocity.x < camBoundMin.x)
            velocity.x = 0;
        
        if (transform.position.y + velocity.y > camBoundMax.y)
            velocity.y = 0;

        if (transform.position.y + velocity.y < camBoundMin.y)
            velocity.y = 0;      

        transform.position += (Vector3)velocity;

    }
}
