using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingFireballs : MonoBehaviour
{
    public GameObject Fireball1, Fireball2, Fireball3, Fireball4, Fireball5, Fireball6, Fireball7;
    
    float speedDown;
    public static float speedDownS;
    public float coolDown;
    float countdownX =10;
    float timer;
    GameObject randomFireball;

    // Start is called before the first frame update
    void Start()
    {
        speedDown = Camera_Movement.camSpeedS;
        speedDownS = speedDown;
    }

    // Update is called once per frame
    void Update()
    {
        //every 4 secs, increase the rate of fireball spawn
        countdownX -= Time.deltaTime;
        if (countdownX <0 && coolDown> 0.3f)
        {
            coolDown -= 0.1f;
            countdownX = 10;
        }
        
        timer -= Time.deltaTime;
        transform.position += Vector3.down * Time.deltaTime * speedDown;//move the shooting platform down, same speed as the camera

        
        //transform.rotation
        if (timer < 0)
        {
            //System.Random randomY = new System.Random();

            shootFireballs();
            timer = coolDown;
        }
        

    }

    void shootFireballs()
    {

        //pick random fireball animation between the seven of them
        int randomNumber = Random.Range(1, 7);
        switch (randomNumber)
        {
            case 1:
                randomFireball = Fireball1;
                break;
            case 2:
                randomFireball = Fireball2;
                break;
            case 3:
                randomFireball = Fireball3;
                break;
            case 4:
                //play a fireball moving sound when the big fireball spawn
                randomFireball = Fireball4;
                SoundController.PlaySound(("fireballSpawn1"), .3f);
                break;
            case 5:
                randomFireball = Fireball5;
                break;
            case 6:
                randomFireball = Fireball6;
                break;
            case 7:
                randomFireball = Fireball7;
                break;

        }
        //spawn the fireball randomly on the line, top of the screen
        Vector2 newPosition = new Vector2(Random.Range(transform.position.x - 6.6f, transform.position.x + 7f), (transform.position.y));
        Instantiate(randomFireball, newPosition, Quaternion.Euler(0f, 0f, 270f));

        //
        ;
    }

}
