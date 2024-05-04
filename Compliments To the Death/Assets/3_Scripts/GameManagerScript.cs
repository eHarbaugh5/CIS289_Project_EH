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
        if (SceneManager.GetActiveScene().name == "LevelThree")
        {
            this.gameObject.SetActive(false);
        }
        Player = GameObject.FindWithTag("Player");
        MainCamera = GameObject.FindWithTag("MainCamera");
    }


    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        Application.targetFrameRate = 30;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        //  in new scene grabs player and main camera

        Player = GameObject.FindWithTag("Player");
        MainCamera = GameObject.FindWithTag("MainCamera");

    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }


    // Update is called once per frame
    void Update()
    {
        
        MainCamera.transform.position = new Vector3 (Player.transform.position.x, Player.transform.position.y, MainCamera.transform.position.z);


        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }


        if (Input.GetKeyUp(KeyCode.Y))
        {

            SceneManager.LoadScene("LevelOne");

        }

        if (Input.GetKeyUp(KeyCode.U))
        {

            SceneManager.LoadScene("LevelTwo");

        }

        if (Input.GetKeyUp(KeyCode.O))
        {
            SceneManager.LoadScene("LevelThree");
        }

        if (Input.GetKeyUp(KeyCode.I))
        {

            SceneManager.LoadScene("TrailerScene");

        }


        if (Input.GetKeyUp(KeyCode.M))
        {

            SceneManager.LoadScene("MainMenu");

        }

    }




}
