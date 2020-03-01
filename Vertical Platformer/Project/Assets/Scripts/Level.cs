using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    public int levelValue;

    Text level;
    // Start is called before the first frame update
    void Start()
    {
        level = GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {

        level.text = "Level " + (levelValue);

    }
}
