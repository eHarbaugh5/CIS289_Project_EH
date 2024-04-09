using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WagonCarrotCollect : MonoBehaviour
{


    public float wagonSpotX;
    public float wagonSpotY;

    private bool isCollected;

    // Start is called before the first frame update
    void Start()
    {
        isCollected = false;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player") && !isCollected)
        {

            collectCarrot();

        }
    }

    private void collectCarrot()
    {

        

        isCollected = true;
        //  play animation

        //  then send to cart
        sendToCart();


    }

    private void sendToCart()
    {
        transform.localPosition = new Vector2(wagonSpotX, wagonSpotY);
    }





}
