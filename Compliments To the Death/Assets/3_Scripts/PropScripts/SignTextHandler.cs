using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SignTextHandler : MonoBehaviour
{

    private GameObject signText;
    private GameObject signTextBox;

    void Start()
    {
        signText = transform.GetChild(0).gameObject;
        signTextBox = transform.GetChild(1).gameObject;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.transform.CompareTag("PlayerHitBox"))
        {
            signText.SetActive(true);
            signTextBox.SetActive(true);

        }
        


    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("PlayerHitBox"))
        {
            signText.SetActive(false);
            signTextBox.SetActive(false);

        }
    }




}
