using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAiScript : MonoBehaviour
{

    private CircleCollider2D bodyCollider;
    private CapsuleCollider2D[] armsCollider;
    public GameObject[] jumpLocations;
    private int currLocation;

    private float jumpTimer;
    public float maxJumpTimer;

    public float jumpSpeed;

    private bool canJump;

    // Start is called before the first frame update
    void Start()
    {
        bodyCollider = GetComponent<CircleCollider2D>();
        armsCollider = GetComponents<CapsuleCollider2D>();
        jumpTimer = maxJumpTimer;
        currLocation = 0;


    }

    // Update is called once per frame
    void Update()
    {
        
        if (canJump && jumpTimer >= 0)
        {
            jumpTimer -= Time.deltaTime;
        }
        

        if (canJump && jumpTimer < 0)
        {
            disableColliders();
        }


        if (!canJump)
        {

            //  get direction of new location
            Vector2 direction = jumpLocations[currLocation].transform.position - transform.position;
            direction.Normalize();

            //  simple movement to the player
            transform.position = Vector2.MoveTowards(transform.position, jumpLocations[currLocation].transform.position, jumpSpeed * Time.deltaTime);

        }


    }


    private void disableColliders()
    {

        bodyCollider.enabled = false;
        armsCollider[0].enabled = false;
        armsCollider[1].enabled = false;
        //  move to new location
        canJump = false;


    }

    private void enableColliders()
    {

        bodyCollider.enabled = true;
        armsCollider[0].enabled = true;
        armsCollider[1].enabled = true;

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("JumpLocation"))
        {

            if (!canJump)
            {

                enableColliders();
                canJump = true;
                currLocation++;
                jumpTimer = maxJumpTimer;
                if (currLocation > jumpLocations.Length)
                {
                    currLocation = 0;
                }

            }

        }
    }

}
