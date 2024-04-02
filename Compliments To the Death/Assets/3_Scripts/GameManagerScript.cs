using System.Collections;
using System.Collections.Generic;
//using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

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


        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }


        if (Input.GetKeyUp(KeyCode.R))
        {

            SceneManager.LoadScene("DemoScene");

        }

        if (Input.GetKeyUp(KeyCode.P))
        {

            SceneManager.LoadScene("SampleScene");

        }

    }
}
