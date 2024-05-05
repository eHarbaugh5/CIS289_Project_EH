using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoupHandler : MonoBehaviour
{


    public GameObject[] soup;
    public GameObject boss;

    private bool noSoup;

    private float checkTime;



    // Start is called before the first frame update
    void Start()
    {
        checkTime = 5;
        noSoup = false;
    }

    private void Update()
    {
        checkTime -= Time.deltaTime;
        if (checkTime < 0)
        {
            checkForLoss();
            checkTime = 5;
        }
    }

    public void checkForLoss()
    {

        noSoup = true;

        for (int i = 0; i < soup.Length; i++)
        {

            if (soup[i] != null)
            {
                noSoup = false;
            }

        }

        if (noSoup)
        {

            //  game over
            SceneManager.LoadScene("LevelThree");

        }
        else if (boss == null)
        {

            //  win 
            SceneManager.LoadScene("EndingScene");

        }

    }

        



}
