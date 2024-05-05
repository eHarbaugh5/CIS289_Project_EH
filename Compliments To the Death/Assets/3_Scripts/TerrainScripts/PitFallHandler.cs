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



    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.transform.CompareTag("Enemy"))
        {

            if (!collision.gameObject.GetComponent<EnemyHpHandler>().getIsFlying())
            {

                //  activate animator that will kill them

                collision.transform.GetComponent<EnemyHpHandler>().fallInPit();

                // Old prior to animation
                //Debug.Log(collision.transform.name + " Has fallen to their death");
                //Destroy(collision.gameObject);
            }

            


        }

        if (collision.transform.CompareTag("PlayerHitBox"))
        {
            Debug.Log("Player Has Died");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }



}
