using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backgrounds : MonoBehaviour
{
    float speedBackground =5;
    
    
    public int backgroundNumber;
    
    void Start()
    {
        
        //change differnet background's speed
        switch (backgroundNumber)
        {
            case 1:
                speedBackground -= 5;
                break;
            case 2:
                speedBackground -= 3;
                break;
            case 3:
                speedBackground -= 1;
                break;

        }
        
    }

    // Update is called once per frame
    void Update()
    {
        //move the backgrounds down
        MoveDown(speedBackground);
    }

    public void MoveDown(float s)
    {
        transform.position += Vector3.down * Time.deltaTime * (s);
        
    }
    
}
