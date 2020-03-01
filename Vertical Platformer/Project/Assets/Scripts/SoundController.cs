using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{

    //Declare sounds names
    public static AudioClip playerOuchSound0, playerOuchSound1, playerOuchSound2, playerOuchSound3, playerOuchSound4, playerOuchSound5, playerOuchSound6;
    public static AudioClip fireBallSpawnSound1, fireBallSpawnSound2,fireballExploSound1, fireballExploSound2;
    public static AudioClip keySound,HPSound;
    public static AudioClip woodCrash0, woodCrash1, woodCrash2, woodCrash3, woodCrash4;
    public static AudioClip jumpGroan1, jumpGroan2, jumpGroan3, jumpLand1, jumpLand2, jumpLand3, jumpLand4, jumpLand5, jumpLand6, jumpLand7, jumpLand8, jumpLand9, jumpLand10;

    static AudioSource audioX;
   
    void Start()
    {
        //imput sounds
        //------------------------------sound when ouch------------------------------
        playerOuchSound0 = Resources.Load<AudioClip>("Sounds/Player_Sound/p0");
        playerOuchSound1 = Resources.Load<AudioClip>("Sounds/Player_Sound/p1");
        playerOuchSound2 = Resources.Load<AudioClip>("Sounds/Player_Sound/p2");
        playerOuchSound3 = Resources.Load<AudioClip>("Sounds/Player_Sound/p3");
        playerOuchSound4 = Resources.Load<AudioClip>("Sounds/Player_Sound/p4");
        playerOuchSound5 = Resources.Load<AudioClip>("Sounds/Player_Sound/p5");
        playerOuchSound6 = Resources.Load<AudioClip>("Sounds/Player_Sound/p6");

        //------------------------------sound for fireballs------------------------------
        fireBallSpawnSound1 = Resources.Load<AudioClip>("Sounds/Fireball_Sound/Spawn1");
        fireBallSpawnSound2 = Resources.Load<AudioClip>("Sounds/Fireball_Sound/Spawn2");
        fireballExploSound1 = Resources.Load<AudioClip>("Sounds/Fireball_Sound/Fireball1");
        fireballExploSound2 = Resources.Load<AudioClip>("Sounds/Fireball_Sound/Fireball2");

        //------------------------------sound for wood crashing------------------------------
        woodCrash0 = Resources.Load<AudioClip>("Sounds/Wood_Crash_Sound/woodCrash0");
        woodCrash1 = Resources.Load<AudioClip>("Sounds/Wood_Crash_Sound/woodCrash1");
        woodCrash2 = Resources.Load<AudioClip>("Sounds/Wood_Crash_Sound/woodCrash2");
        woodCrash3 = Resources.Load<AudioClip>("Sounds/Wood_Crash_Sound/woodCrash3");
        woodCrash4 = Resources.Load<AudioClip>("Sounds/Wood_Crash_Sound/woodCrash4");

        //------------------------------sound for wood crashing------------------------------
        jumpGroan1 = Resources.Load<AudioClip>("Sounds/Jumping_Sound/jumpGroan1");
        jumpGroan2 = Resources.Load<AudioClip>("Sounds/Jumping_Sound/jumpGroan2");
        jumpGroan3 = Resources.Load<AudioClip>("Sounds/Jumping_Sound/jumpGroan3");
        jumpLand1 = Resources.Load<AudioClip>("Sounds/Jumping_Sound/jumpLand1");
        jumpLand2 = Resources.Load<AudioClip>("Sounds/Jumping_Sound/jumpLand2");
        jumpLand3 = Resources.Load<AudioClip>("Sounds/Jumping_Sound/jumpLand3");
        jumpLand4 = Resources.Load<AudioClip>("Sounds/Jumping_Sound/jumpLand4");
        jumpLand5 = Resources.Load<AudioClip>("Sounds/Jumping_Sound/jumpLand5");
        jumpLand6 = Resources.Load<AudioClip>("Sounds/Jumping_Sound/jumpLand6");
        jumpLand7 = Resources.Load<AudioClip>("Sounds/Jumping_Sound/jumpLand7");
        jumpLand8 = Resources.Load<AudioClip>("Sounds/Jumping_Sound/jumpLand8");
        jumpLand9 = Resources.Load<AudioClip>("Sounds/Jumping_Sound/jumpLand9");
        jumpLand10 = Resources.Load<AudioClip>("Sounds/Jumping_Sound/jumpLand10");

        //------------------------------sound for items------------------------------
        keySound = Resources.Load<AudioClip>("Sounds/keySound");
        HPSound = Resources.Load<AudioClip>("Sounds/HPSound");

        audioX = GetComponent<AudioSource>();
    }

    
    void Update()
    {
        


    }

    //make a method to play sound
    public static void PlaySound(string soundName, float volume)
    {
        //switch method for playing different sound
        switch(soundName)
        {
            case "playerOuch0":
                audioX.PlayOneShot(playerOuchSound0, volume);
                break;
            case "playerOuch1":
                audioX.PlayOneShot(playerOuchSound1, volume);
                break;
            case "playerOuch2":
                audioX.PlayOneShot(playerOuchSound2, volume);
                break;
            case "playerOuch3":
                audioX.PlayOneShot(playerOuchSound3, volume);
                break;
            case "playerOuch4":
                audioX.PlayOneShot(playerOuchSound4, volume);
                break;
            case "playerOuch5":
                audioX.PlayOneShot(playerOuchSound5, volume);
                break;
            case "playerOuch6":
                audioX.PlayOneShot(playerOuchSound6, volume);
                break;
            case "fireballExplo1":
                audioX.PlayOneShot(fireballExploSound1, volume);
                break;
            case "fireballExplo2":
                audioX.PlayOneShot(fireballExploSound2, volume);
                break;
            case "fireballSpawn1":
                audioX.PlayOneShot(fireBallSpawnSound1, volume);
                break;
            case "fireballSpawn2":
                audioX.PlayOneShot(fireBallSpawnSound2, volume);
                break;
            case "woodCrash0":
                audioX.PlayOneShot(woodCrash0, volume);
                break;
            case "woodCrash1":
                audioX.PlayOneShot(woodCrash1, volume);
                break;
            case "woodCrash2":
                audioX.PlayOneShot(woodCrash2, volume);
                break;
            case "woodCrash3":
                audioX.PlayOneShot(woodCrash3, volume);
                break;
            case "woodCrash4":
                audioX.PlayOneShot(woodCrash4, volume);
                break;
            case "jumpGroan1":
                audioX.PlayOneShot(jumpGroan1, volume);
                break;
            case "jumpGroan2":
                audioX.PlayOneShot(jumpGroan2, volume);
                break;
            case "jumpGroan3":
                audioX.PlayOneShot(jumpGroan3, volume);
                break;
            case "jumpLand1":
                audioX.PlayOneShot(jumpLand1, volume);
                break;
            case "jumpLand2":
                audioX.PlayOneShot(jumpLand2, volume);
                break;
            case "jumpLand3":
                audioX.PlayOneShot(jumpLand3, volume);
                
                break;
            case "jumpLand4":
                audioX.PlayOneShot(jumpLand4, volume);

                break;
            case "jumpLand5":
                audioX.PlayOneShot(jumpLand5, volume);

                break;
            case "jumpLand6":
                audioX.PlayOneShot(jumpLand6, volume);

                break;
            case "jumpLand7":
                audioX.PlayOneShot(jumpLand7, volume);

                break;
            case "jumpLand8":
                audioX.PlayOneShot(jumpLand8, volume);

                break;
            case "jumpLand9":
                audioX.PlayOneShot(jumpLand9, volume);

                break;
            case "jumpLand10":
                audioX.PlayOneShot(jumpLand10, volume);

                break;
            case "key":
                audioX.PlayOneShot(keySound, volume);

                break;
            case "HP":
                audioX.PlayOneShot(HPSound, volume);

                break;
        }
    }
}
