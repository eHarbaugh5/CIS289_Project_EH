using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTwoCompleteScript : MonoBehaviour
{

    public GameObject[] enemies;
    public GameObject[] ingreedients;
    private int lives = 3;

    private float updateTime;
    private const float maxUpdate = 5;



    // Start is called before the first frame update
    void Start()
    {
        updateTime = maxUpdate;
    }

    private void Update()
    {
        
        updateTime -= Time.deltaTime;
        if ( updateTime < 0 )
        {
            updateTime = maxUpdate;
            enemyDefeated();

        }


    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.transform.CompareTag("PlayerHitBox"))
        {

            //enemyDefeated();

        }


    }


    public void removeCarrot()
    {

        lives--;
        
        ingreedients[lives].gameObject.SetActive(false);

        if (lives == 0)
        {
            SceneManager.LoadScene("Leveltwo");
        }
        
    }

    public void enemyDefeated()
    {

        
        bool allDead = true;
        for (int i = 0; i < enemies.Length; i++)
        {

            if (enemies[i] != null)
            {
              allDead = false;
            }

        }


        if (allDead)
        {
            SceneManager.LoadScene("LevelThree");

        }

        

    }




}
