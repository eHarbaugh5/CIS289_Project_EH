using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoupHandler : MonoBehaviour
{


    public GameObject[] soup;

    private bool noSoup;



    // Start is called before the first frame update
    void Start()
    {
        noSoup = false;
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

    }

        



}
