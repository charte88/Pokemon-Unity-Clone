using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartPoint : MonoBehaviour
{
    private Movement thePlayer;
    private CameraController theCamera;

    public string pointName;
    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<Movement>();

        if (thePlayer.startPoint == pointName)
        {
            thePlayer.transform.position = transform.position;

            theCamera = FindObjectOfType<CameraController>();
            theCamera.transform.position = new Vector3(transform.position.x, transform.position.y, theCamera.transform.position.z);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
