using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//THIS Script is not in usedS
public class Score : MonoBehaviour
{
    int scoreValue = 0;
    float timer;
    Text scores;
    // Start is called before the first frame update
    void Start()
    {
        scores = GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 2f)
        {
            scoreValue += 5;
            timer = 0;
        }
        scores.text = "scores: " + (scoreValue);

    }
}
