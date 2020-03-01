using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingGround : MonoBehaviour
{
    
    public float speedX;
    float randN;
    // Start is called before the first frame update
    void Start()
    {
        //generate a random number
        randN =  Random.Range(0, 10);

    }

    // Update is called once per frame
    void Update()
    {

        //use pingpong to move the ground
        transform.position = new Vector3(Mathf.PingPong(Time.time*speedX + randN, 10)-7, transform.position.y, transform.position.z);


        
    }
    
}
