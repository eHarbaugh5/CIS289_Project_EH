using System.Collections;
using System.Collections.Generic;
//using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class RatSpawnerScript : MonoBehaviour
{

    public GameObject ratSwarmEnemy;
    private GameObject newRat;
    public GameObject[] RSpawn;

    private int currSpawn;

    private bool canSpawn;

    private float spawnTimer;

    public float maxSpawnTimer;



    // Start is called before the first frame update
    void Start()
    {
        currSpawn = 0;
        spawnTimer = maxSpawnTimer;
        //  random currSpawn
    }

    // Update is called once per frame
    void Update()
    {
        

        if (!canSpawn)
        {

            spawnTimer -= Time.deltaTime;


        }

        if (spawnTimer < 0)
        {
            canSpawn = true;
            spawnRat();
        }



    }


    private void spawnRat()
    {

        newRat = Instantiate(ratSwarmEnemy, RSpawn[currSpawn].transform);
        // new rat give direction up or down

        if (currSpawn == 0 || currSpawn == 2 || currSpawn == 4)
        {
            newRat.GetComponent<RatSwarmAi>().setDirection(-180);

        }
        else
        {
            newRat.GetComponent<RatSwarmAi>().setDirection(180);

        }
        currSpawn++;
        if (currSpawn == RSpawn.Length)
        {
            currSpawn = 0;
        }
        canSpawn = false;
        spawnTimer = maxSpawnTimer;

    }


    



}
