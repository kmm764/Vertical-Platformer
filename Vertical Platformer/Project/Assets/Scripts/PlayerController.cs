using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // from lab2 tutorial
    bool isIdle;
    bool isLeft;
    bool canJump;
    public int levelx;

    //link to HP script
    public GameObject hp;
    HPBar hPBar;

    //add effects to player's actions
    public GameObject jumpEffect;
    public GameObject bloodEffect;
    public GameObject exploEffect;


    public bool hasDied = false;
   
    int isIdleKey = Animator.StringToHash("isIdle");

    public int speedx;
    public int jumpPower;
    

    //from lab2
    int groundMask = 1 << 8;

    //------------------------------HP related variables------------------------------
    public float currentHP;
    public float totalHP;
    public float spikesDmg;
    public float fireballDmg;
    public float bigFireballDmg;

    //counters to make sure the sound won't repeat one after another in 0.1 secs, annoying...
    float jumpSoundCounter;
    float landSoundCounter;

    //make sure the player have a invincivle period right after taking damage, 0.25 seconds
    float invincibleCounter;

    // Start is called before the first frame update
    void Start()
    {
        
        currentHP = totalHP;
        
    }

    // Update is called once per frame
    private void Update()
    {
        // from lab 2
        Animator a = GetComponent<Animator>();
        a.SetBool(isIdleKey, isIdle);
        SpriteRenderer r = GetComponent<SpriteRenderer>();
        r.flipX = isLeft;
        

        //counters
        invincibleCounter -= Time.deltaTime;
        jumpSoundCounter -= Time.deltaTime;
        landSoundCounter -= Time.deltaTime;

        //die if <=0 hp
        if (currentHP <= 0)
        {
            hasDied = true;
        }

        //move to game over scene
        if (hasDied == true)
        {

            Keys.keyValue = 0;
            currentHP = totalHP;
            switch (levelx)
            {
                case 1:
                    SceneManager.LoadScene("gameOver");
                    break;
                case 2:
                    SceneManager.LoadScene("GameOver2");
                    break;
                case 3:
                    SceneManager.LoadScene("GameOver3");
                    break;



            }
            


        }
    }

    
    
    // Update is called once per frame
    void FixedUpdate()
    {
        // the new velocity to apply to the character
        Vector2 physicsVelocity = Vector2.zero;
        Rigidbody2D r = GetComponent<Rigidbody2D>(); //get the rigidbody
        isIdle = true;
        isLeft = false;
        // move to the left, from lab 2
        if (Input.GetKey(KeyCode.A))
        {
            physicsVelocity.x -= speedx;
            isLeft = true;
            isIdle = false;
        }

        // from lab 2
        if (Input.GetKey(KeyCode.D))
        {
            physicsVelocity.x += speedx;
            isIdle = false;
            //isLeft = true;
        }
        //jumping from lab 2
        if (Input.GetKey(KeyCode.W))
        {
            if (canJump == true)
            {
                r.velocity = new Vector2(physicsVelocity.x, jumpPower);
                
                canJump = false;

                // spawn jump effect under the plader each time the player jumps
                Vector2 jumpEffectSpawnPosition = new Vector2(transform.position.x, transform.position.y-1);
                Instantiate(jumpEffect, (jumpEffectSpawnPosition), transform.rotation);
                if (jumpSoundCounter<0)
                {
                    System.Random randomSound = new System.Random();

                    int x = randomSound.Next(1, 4);
                    //sound effect when jumping, random between the 3 jumping sound
                    SoundController.PlaySound(("jumpGroan" + x),0.5f);
                    //make a coutner so it won't make a sound if the player jumps within 5 secs
                    jumpSoundCounter = 0.5f;
                }
                
            }
        }
        //from lab 2
        if(Physics2D.Raycast(new Vector2(transform.position.x-0.1f, transform.position.y), -Vector2.up, 1.0f, groundMask))
        {
            canJump = true;
        }
        
        //from lab 2
        r.velocity = new Vector2(physicsVelocity.x,
        r.velocity.y);
        
    }

    //die if out of the viewport
    void OnBecameInvisible()
    {
        hasDied = true;

        
    }

    //if the player collide with others
    void OnCollisionEnter2D(Collision2D other)
    {


        //move to other scenes if hit the object with the tag "FinishLv1"
        if (other.transform.tag == "FinishLv1")
        {
            if (Keys.keyValue >= Keys.keyNeeded)
            {
                SceneManager.LoadScene("intro2");
                Keys.keyValue= 0;
            }
            else
            {
                SceneManager.LoadScene("gameOver");
            }

        }
        //move to other scenes if hit the object with the tag "FinishLv2"
        if (other.transform.tag == "FinishLv2")
        {
            if (Keys.keyValue >= Keys.keyNeeded)
            {
                SceneManager.LoadScene("intro3");
                Keys.keyValue = 0;
            }
            else
            {
                SceneManager.LoadScene("GameOver2");
            }

        }
        //move to other scenes if hit the object with the tag "FinishLv3"
        if (other.transform.tag == "FinishLv3")
        {
            if (Keys.keyValue >= Keys.keyNeeded)
            {
                SceneManager.LoadScene("Win");
            }
            else
            {
                SceneManager.LoadScene("GameOver3");
            }

        }

        //destory the key once collided and add key value
        if (other.transform.tag == "Keys")
        {
            Destroy(other.gameObject);
            // play the sound effect when collected a key
            SoundController.PlaySound(("key"), 0.1f);
            Keys.keyValue += 1;
        }
        //destory the heart once collided and add HP to the player, if he is not full health
        if (other.transform.tag == "Hearts")
        {
            Destroy(other.gameObject);
            //sound effect
            SoundController.PlaySound(("HP"), 0.1f);
            if (currentHP < 100) //don't add HP if full health
            {
                currentHP += 30;
                if (currentHP > 100) //make sure HP don't exceed 100
                {
                    currentHP = 100;
                }
            }
        }
        //play sound when contact the ground
        if (other.transform.tag == "Ground" || other.transform.tag =="MovingPlatform" || other.transform.tag == "FallingPlatform")
        {
            if(landSoundCounter<0)
            {
                System.Random randomSound = new System.Random();

                // random between the ten sound included
                int x = randomSound.Next(1, 11);

                SoundController.PlaySound(("jumpLand" + x), 0.1f);
                landSoundCounter = 0.5f;
            }
            


        }

    }

    //when staying
    void OnCollisionStay2D(Collision2D other)
    {

        //every one second, the player will be damged bt the spikes if he stays in it
        if (other.transform.tag == "Spikes")
        {
            //Debug.Log(" Collisoin with spikes");
            if (invincibleCounter <= 0)
            {
                System.Random randomSound = new System.Random();

                int x = randomSound.Next(0, 6);

                SoundController.PlaySound(("playerOuch" + x), 1);
                Instantiate(bloodEffect, transform.position, transform.rotation);
                currentHP -= spikesDmg;
                invincibleCounter = 1;
            }

            
        }

        //every 0.5 seconds the player is vunarable to small fireballs and other harzards
        if (other.transform.tag == "Fireball")
        {
            //Debug.Log(" Collisoin with spikes");
            if (invincibleCounter <= 0)
            {
                SoundController.PlaySound(("fireballExplo2"), 0.3f);

                Instantiate(exploEffect, transform.position, transform.rotation);
                currentHP -= fireballDmg;
                Destroy(other.gameObject);
                invincibleCounter = 0.5f;
            }


        }
        //every 0.5 seconds the player is vunarable to Big fireballs and other harzards
        if (other.transform.tag == "BigFireball")
        {
            //Debug.Log(" Collisoin with spikes");
            if (invincibleCounter <= 0)
            {
                SoundController.PlaySound(("fireballExplo1"), 0.5f);

                Instantiate(exploEffect, transform.position, transform.rotation);
                currentHP -= bigFireballDmg;
                Destroy(other.gameObject);
                invincibleCounter = 0.5f;
            }


        }


    }
    
}
