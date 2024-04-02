using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitFallHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {

            Destroy(collision.gameObject);

        }
    }




}
