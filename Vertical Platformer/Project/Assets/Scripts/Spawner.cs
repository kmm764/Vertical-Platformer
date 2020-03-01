using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //-------------------------GameObjects-------------------------
    public GameObject tPlatform;
    public GameObject movingPlatform;
    public GameObject spikePlatform;
    public GameObject movingSpikePlatform;
    public GameObject fallingPlatform;
    public GameObject nextLevel;
    public GameObject keys;
    public GameObject hearts;
    public GameObject BG1;
    public GameObject BG2;
    public GameObject BG3;
    
    GameObject newObject;


    //-------------------------platform spawning chance-------------------------
    public int normalPlatformChance = 30;
    public int movingPlatformChance =30;
    public int spikePlatformChance = 10;
    public int movingSpikePlatformChance = 10;
    public int fallingPlatformChance=0;

    //-------------------------items-------------------------
    public int numOfKeys;
    public int numOfHearts;
    int numberOfBG;

    

    int totalRatio;
    
    public Transform spawnPos;
    bool canSee = true;
    int numberOfObj = 0; //make sure onyl spawn once, the whole scene
    public int numberOfPlatforms = 20; //number of platforms
    
     //make this component


    void start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        //make the total ratio sum of all propability from all five platforms
        totalRatio = (normalPlatformChance + movingPlatformChance + spikePlatformChance + movingSpikePlatformChance + fallingPlatformChance);
        numberOfBG = numberOfPlatforms/4;// make the amout of background spawn 1.4 of the number of platform
        

        System.Random random = new System.Random();
        if (canSee == true && numberOfObj <1) //numberOfObj making sure only spawning once
        {
            //spawn keys
            if(numOfKeys > 0)
            {
                for (int j = 0; j < numOfKeys + 1; j++)
                {
                    //make sure keys spawn within the viewport
                    Vector2 newPosition = new Vector2(Random.Range(-spawnPos.position.x - 2.56f, spawnPos.position.x + 6.28f), (spawnPos.position.y - j * (numberOfPlatforms * 5) / (numOfKeys-1))); //make sure the key spawn in the platform spawn range
                    Instantiate(keys, newPosition, spawnPos.rotation);
                }
            }

            //spawn Hearts
            if (numOfHearts > 0)
            {
                for (int b = 0; b < numOfHearts + 1; b++)
                {
                    //make sure hearts spawn within the viewport
                    Vector2 newPosition = new Vector2(Random.Range(-spawnPos.position.x - 2.56f, spawnPos.position.x + 6.28f), (spawnPos.position.y - b * (numberOfPlatforms * 6) / (numOfKeys - 1))); //make sure the key spawn in the platform spawn range
                    Instantiate(hearts, newPosition, spawnPos.rotation);
                }
            }

            for (int h = 0; h < numberOfBG; h++) //spawn first background layer
            {
                Vector2 newPositionLeft = new Vector2(transform.position.x - 8.09f, (spawnPos.position.y - h * 36.35f)); //spawn a background every 36.35 in y, thats the length of the background img 2.07
                Instantiate(BG1, newPositionLeft, spawnPos.rotation);

                Vector2 newPositionRight = new Vector2(transform.position.x + 8.55f, (spawnPos.position.y - h * 36.35f)); //6.48 to the right from the spawner
                Instantiate(BG1, newPositionRight,  Quaternion.Euler(0f, 0f, 180f)); //flip the image
            }
            for (int h = 0; h < numberOfBG; h++) //spawn second background layer
            {
                Vector2 newPosition = new Vector2(transform.position.x - 5.52f, (spawnPos.position.y - h * 36.35f +10)); //spawn a background every 36.35 in y, thats the length of the background img 1.5
                Instantiate(BG2, newPosition, spawnPos.rotation);
                Vector2 newPositionRight = new Vector2(transform.position.x + 5.98f, (spawnPos.position.y - h * 36.35f)); //4.48 to the right from the spawner
                Instantiate(BG2, newPositionRight, Quaternion.Euler(0f, 0f, 180f)); //flip the image
            }
            for (int h = 0; h < numberOfBG; h++) //spawn third background layer
            {
                Vector2 newPosition = new Vector2(transform.position.x - 2.79f, (spawnPos.position.y - h * 36.35f+20)); //spawn a background every 36.35 in y, thats the length of the background img 0.77
                Instantiate(BG3, newPosition, spawnPos.rotation);
                Vector2 newPositionRight = new Vector2(transform.position.x + 3.25f, (spawnPos.position.y - h * 36.35f)); //2.48 to the right from the spawner
                Instantiate(BG3, newPositionRight, Quaternion.Euler(0f, 0f, 180f)); //flip the image
            }


            for (int i = 0; i<numberOfPlatforms+1;i++) //spawn platforms
            {
                
                int x = random.Next(0, totalRatio);

                //if x is in range between 0 and normal platform chance
                if ((x - normalPlatformChance) < 0) 
                {
                    newObject = tPlatform;
                }
                //if x is in range between normal platform chance and moving platform chance
                else if ((x - movingPlatformChance) < normalPlatformChance)
                {
                    newObject = movingPlatform;
                }

                //if x is in range between normalPlatformChance+movingPlatformChance and spikePlatformChance
                else if ((x - spikePlatformChance) < normalPlatformChance+movingPlatformChance)
                {
                    newObject = spikePlatform;
                }

                //if x is in range between normalPlatformChance+movingPlatformChance +spikePlatformChance and moving spike platform chance
                else if ((x - movingSpikePlatformChance) < normalPlatformChance + movingPlatformChance + spikePlatformChance)
                {
                    newObject = movingSpikePlatform;
                }
                //if x is in range between normalPlatformChance+movingPlatformChance +spikePlatformChance +moving spike platform chance and falling platform chance
                else if ((x - fallingPlatformChance) < normalPlatformChance + movingPlatformChance + spikePlatformChance + movingSpikePlatformChance)
                {
                    newObject = fallingPlatform;
                }
                Vector2 newPosition = new Vector2(Random.Range(-spawnPos.position.x - 2.56f, spawnPos.position.x + 6.28f), (spawnPos.position.y - i*5)); //spawn platforms randomly on x between x-2.56 and x+6.28, and spawn constanly on y

            
                //spawn ending line
                if (i == numberOfPlatforms)
                {
                    Instantiate(nextLevel, newPosition, spawnPos.rotation);

                }
                else
                {
                    Instantiate(newObject, newPosition, spawnPos.rotation);
                    numberOfObj += 1;
                }

            }
            

        }
    }

    
}
