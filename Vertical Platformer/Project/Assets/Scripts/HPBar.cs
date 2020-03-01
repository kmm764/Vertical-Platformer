using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBar : MonoBehaviour
{
    public float totalLife;
    public float currentLife;
    public GameObject player;
    PlayerController PlayerController;  //reference current HP from playerController
    public Transform bar;
    // Start is called before the first frame update
    void Start()
    {
        PlayerController = player.GetComponent<PlayerController>(); //get hp from HPbar script
        totalLife = PlayerController.totalHP;
        currentLife = totalLife;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerController = player.GetComponent<PlayerController>(); //get hp from HPbar script
        currentLife = PlayerController.currentHP;
        PrintHPBar(currentLife, totalLife);
    }

    void PrintHPBar(float currentLife,float totalLife)
    {
        bar.localScale = new Vector2(currentLife/totalLife, 1f);
    }
}
