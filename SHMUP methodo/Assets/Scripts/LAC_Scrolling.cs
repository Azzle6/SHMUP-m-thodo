using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LAC_Scrolling : MonoBehaviour
{
    public float scrollSpeed;
    public Transform[] childObj;

    Camera cam;
    public float camLimit;
    
    // Start is called before the first frame update
    void Start()
    {
        // get and disable all child execpt scroll manager (child[0])
        childObj = GetComponentsInChildren<Transform>();
        for(int i = 0; i < childObj.Length; i++)
        {
            if (i !=0)
            childObj[i].gameObject.SetActive(false);
        }
        // get camera
        GameObject mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        cam = mainCamera.GetComponent<Camera>();

        // set cam limit
        float camHeight = camHeight = 1 / (cam.WorldToViewportPoint(new Vector3(1, 1, 0)).y - 0.5f);
        camLimit = (camHeight / 2);
    }

    // Update is called once per frame
    void Update()
    {
        // move the scroll manager
        transform.position += new Vector3 (0, -scrollSpeed * Time.deltaTime,0);

        // check what childObj to active
        Active(ObjInScreen(childObj,camLimit));
    }

    public Transform ObjInScreen( Transform[] tList, float yScreen)
    {
        Transform transform = null;
        foreach(Transform t in tList)
        {
            if (t.position.y < yScreen)
                transform = t;
        }

        return transform;
    }

    public void Active( Transform child)
    {
        child.gameObject.SetActive(true);
        child.SetParent(null);
    }
}
