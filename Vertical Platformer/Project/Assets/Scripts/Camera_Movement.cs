using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Movement : MonoBehaviour
{
    public float camSpeed;
    public static float camSpeedS;
    // Start is called before the first frame update
    void Start()
    {
        camSpeedS = camSpeed; 
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * Time.deltaTime * camSpeed; //move the camera downwards
        

    }
}
