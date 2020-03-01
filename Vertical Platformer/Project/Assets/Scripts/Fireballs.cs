using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireballs : MonoBehaviour
{
    float speedY = 15;

    System.Random randomSpeed = new System.Random();

    // Start is called before the first frame update
    void Start()
    {
        float x = randomSpeed.Next(0, 10);
        speedY -= x; //make the start speed take away a random number between 1 and 10, making each fireball speed different
        speedY += ShootingFireballs.speedDownS; //add the camera speed to the fireball
    }

    // Update is called once per frame
    void Update()
    {
        MoveFireball(speedY); //move the fireball each frame
    }

    public void MoveFireball(float speedY)
    {
        transform.position += Vector3.down * Time.deltaTime * (speedY); //move the fireball downwards
        
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject); //destroy the fireball when it disappear


    }
}
