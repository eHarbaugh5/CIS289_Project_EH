using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class ThornBatSpawner : MonoBehaviour
{

    public GameObject thornBat;
    public GameObject[] BSpawn;
    private GameObject currBat;
    private int currPos;

    // Start is called before the first frame update
    void Start()
    {
        currPos = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if (currBat == null)
        {
            spawnThornBat();
        }

    }


    private void spawnThornBat()
    {

        currBat = Instantiate(thornBat, BSpawn[currPos].transform);
        currPos++;
        if (currPos == BSpawn.Length)
        {
            currPos = 0;
        }


    }



}
