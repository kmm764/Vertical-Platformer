using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Keys : MonoBehaviour
{
    //keys
    public static int keyValue = 0;
    public static int keyNeeded = 3;

    public GameObject key1, key2, key3;
    public GameObject LevelLogo;
    public GameObject keyBG;
    SpriteRenderer key1S, key2S, key3S,keyBGS;

    //level logo
    SpriteRenderer levelLogoSprite;
    float LevelLogoCounter;
    float fadingColorTimer = 1;


    private Text keys;
    // Start is called before the first frame update
    void Start()
    {
        //keys = GetComponent<Text>();
        //add components
        key1S = key1.GetComponent<SpriteRenderer>();
        key2S = key2.GetComponent<SpriteRenderer>();
        key3S = key3.GetComponent<SpriteRenderer>();
        keyBGS = keyBG.GetComponent<SpriteRenderer>();
        levelLogoSprite = LevelLogo.GetComponent<SpriteRenderer>(); 

        key1S.color = new Color(1f, 1f, 1f, 0f);
        key2S.color = new Color(1f, 1f, 1f, 0f);
        key3S.color = new Color(1f, 1f, 1f, 0f);
        keyBGS.color = new Color(1f, 1f, 1f, 0f);

    }

    // Update is called once per frame
    void Update()
    {
        
        switch(keyValue)
        {
            //when no keys, make the alphas to 0f
            case 0:
                key1S.color = new Color(1f, 1f, 1f, 0f);
                key2S.color = new Color(1f, 1f, 1f, 0f);
                key3S.color = new Color(1f, 1f, 1f, 0f);
                keyBGS.color = new Color(1f, 1f, 1f, 0f);
                break;
                //when one key, the background and the first key's alpha to 1f
            case 1:
                key1S.color = new Color(1f, 1f, 1f, 1f);
                keyBGS.color = new Color(0.34f, 0.34f, 0.34f, 1f);
                break;
                //2 keys, second key alpha to 1f
            case 2:
                key2S.color = new Color(1f, 1f, 1f, 1f);
                break;
                //3 keys, third key alpha to 1f
            case 3:
                key3S.color = new Color(1f, 1f, 1f, 1f);
                break;
                
        }
        //start the timer, where it start fading after 4 delta time
        LevelLogoCounter += Time.deltaTime;
        if (LevelLogoCounter > 3)//make logo fade out after 4 deltatime
        {
            //Debug.Log("Counter start" + fadingColorTimer);
            fadingColorTimer -= (Time.deltaTime)/2;
            levelLogoSprite.color = new Color(1f, 1f, 1f, fadingColorTimer);
        }



    }
}
