using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{

    public GameObject effect;
    private Rigidbody2D rigidBody;
    private bool isSleeping = true;
    private float counter;

    // Start is called before the first frame update
    void Start()
    {
        
        //isSleeping = true;
    }

    // Update is called once per frame
    void Update()
    {
        counter -= Time.deltaTime;
    }

    //destroy the faling platform when in contact to other platforms
    void OnCollisionEnter2D(Collision2D other)
    {

        if (other.transform.tag == "Ground")
        {
            playCrashSound();
            Instantiate(effect, transform.position, transform.rotation);
            Destroy(gameObject);
        }

        if (other.transform.tag == "Spikes")
        {
            playCrashSound();
            Instantiate(effect, transform.position, transform.rotation);
            Destroy(gameObject);
        }

        if (other.transform.tag == "MovingPlatform")
        {
            playCrashSound();
            Instantiate(effect, transform.position, transform.rotation);
            Destroy(gameObject);
            
        }

        //give the platform gravity when the player contacts it, so that it falls when the player touches it
        if (other.transform.tag == "Player")
        {
            if (counter < 0)
            {
                rigidBody = gameObject.AddComponent<Rigidbody2D>(); //give it gravity and fall
                                                                    //rigidBody.mass = 1;
                rigidBody.gravityScale = 4;// set gravity to 4
                counter = 0.5f;
            }
            
        }

        if (other.transform.tag == "FallingPlatform")
        {

            playCrashSound();
            Instantiate(effect, transform.position, transform.rotation);
            Destroy(gameObject);
        }

        

    }
    //method for playing crashing sound, random crashin sound each time between 0 and 4
    void playCrashSound()
    {
        System.Random randomSound = new System.Random();

        int x = randomSound.Next(0, 5);

        SoundController.PlaySound(("woodCrash" + x),0.2f);
    }
}
