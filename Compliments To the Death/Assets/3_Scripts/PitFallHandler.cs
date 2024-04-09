using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PitFallHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.transform.CompareTag("Enemy"))
        {
            Debug.Log(collision.transform.name + " Has fallen to their death");
            Destroy(collision.gameObject);


        }

        if (collision.transform.CompareTag("Player"))
        {
            Debug.Log("Player Has Died");
            SceneManager.LoadScene("LevelOne");
        }

    }



}
