using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    private GameObject Player;
    private GameObject MainCamera;


    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        MainCamera = GameObject.FindWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        MainCamera.transform.position = new Vector3 (Player.transform.position.x, Player.transform.position.y, MainCamera.transform.position.z);
    }
}
