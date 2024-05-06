using System.Collections;
using System.Collections.Generic;
//using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    private GameObject Player;
    private GameObject MainCamera;
    private GameObject spawnPoint;

    [SerializeField] GameObject playerCanvas;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject resumeButton;

    public bool isPaused;

    private bool canCheat;


    // Start is called before the first frame update
    void Start()
    {
        canCheat = false;
        isPaused = false;
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

        
        //if (SceneManager.GetActiveScene().name != "MainMenu")
        //{
            Player = GameObject.FindWithTag("Player");
            Player.GetComponent<PlayerMovement>().resetPlayerHp();
            spawnPoint = GameObject.FindWithTag("SpawnPoint");
            Player.transform.position = spawnPoint.transform.position;
        //}
        MainCamera = GameObject.FindWithTag("MainCamera");

        if (SceneManager.GetActiveScene().name == "MainMenu" || SceneManager.GetActiveScene().name == "EndingScene")
        {

            playerCanvas.SetActive(false);

        }
        else
        {
            playerCanvas.SetActive(true);
        }


         
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }


    // Update is called once per frame
    void Update()
    {
        
        MainCamera.transform.position = new Vector3 (Player.transform.position.x, Player.transform.position.y, MainCamera.transform.position.z);


        if (Input.GetKeyUp("escape"))
        {
            if (SceneManager.GetActiveScene().name != "MainMenu" && SceneManager.GetActiveScene().name != "EndingScene")
            {
                if (!isPaused)
                {
                    //  pause
                    isPaused = true;
                    Time.timeScale = 0f;
                    pauseMenu.SetActive(true);
                    EventSystem.current.SetSelectedGameObject(resumeButton);


                }
                else if (isPaused)
                {
                    isPaused = false;
                    Time.timeScale = 1f;
                    pauseMenu.SetActive(false);
                    EventSystem.current.SetSelectedGameObject(null);
                }
                //Application.Quit();
            }




        }

        if (Input.GetKeyUp(KeyCode.Backslash))
        {
            if (canCheat)
            {
                canCheat = false;
            }
            else
            {
                canCheat = true;

            }
        }

        if (canCheat)
        {

            if (Input.GetKeyUp(KeyCode.Y))
            {

                SceneManager.LoadScene("LevelOne");

            }

            if (Input.GetKeyUp(KeyCode.U))
            {

                SceneManager.LoadScene("LevelTwo");

            }

            if (Input.GetKeyUp(KeyCode.I))
            {
                SceneManager.LoadScene("LevelThree");
            }



            if (Input.GetKeyUp(KeyCode.O))
            {

                SceneManager.LoadScene("EndingScene");

            }

            if (Input.GetKeyUp(KeyCode.P))
            {

                SceneManager.LoadScene("MainMenu");

            }

        }

        

    }

    public void resumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);



    }


    public void returnToHome()
    {
        isPaused = false;
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        SceneManager.LoadScene("MainMenu");


    }




}
