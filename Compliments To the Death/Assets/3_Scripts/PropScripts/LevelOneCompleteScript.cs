using System.Collections;
using System.Collections.Generic;
//using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelOneCompleteScript : MonoBehaviour
{

    private bool[] collectedIngreedients = {false, false, false};
    private WagonCarrotCollect ingreedientOne;
    private WagonCarrotCollect ingreedientTwo;
    private WagonCarrotCollect ingreedientThree;


    // Start is called before the first frame update
    void Start()
    {
        ingreedientOne = transform.GetChild(0).gameObject.GetComponent<WagonCarrotCollect>();
        ingreedientTwo = transform.GetChild(1).gameObject.GetComponent<WagonCarrotCollect>();
        ingreedientThree = transform.GetChild(2).gameObject.GetComponent<WagonCarrotCollect>();
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("PlayerHitBox"))
        {
            checkForLevelOneComplete();
        }
    }

    private void checkForLevelOneComplete()
    {
        collectedIngreedients[0] = ingreedientOne.getIsCollected();
        collectedIngreedients[1] = ingreedientTwo.getIsCollected();
        collectedIngreedients[2] = ingreedientThree.getIsCollected();

        if (collectedIngreedients[0] && collectedIngreedients[1] && collectedIngreedients[2])
        {
            // all three collected win the game
            SceneManager.LoadScene("LevelTwo");
        }
    }

}
