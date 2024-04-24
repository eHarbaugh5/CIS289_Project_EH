using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuControler : MonoBehaviour
{




 
    public void startGameButton()
    {
        SceneManager.LoadScene("LevelOne");
    }




    public void quitGameButton()
    {

        Application.Quit();

    }




}
