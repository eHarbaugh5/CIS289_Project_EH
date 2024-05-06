using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsScript : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private float endCredits;

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * Time.deltaTime * speed;

        if (transform.position.y >= endCredits)
        {

            SceneManager.LoadScene("MainMenu");

        }
    }


}
