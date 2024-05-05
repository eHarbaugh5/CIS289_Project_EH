using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAiScript : MonoBehaviour
{

    private CircleCollider2D bodyCollider;
    private CapsuleCollider2D[] armsCollider;
    private BoxCollider2D attackCollider;
    public GameObject[] jumpLocations;
    private EnemyHpHandler enemyHpHandler;
    private EnemyHpHandler eatHpHandler;
    private int currLocation;

    private GameObject soupToEat;
    private GameObject enemyToEat;
    private SoupHandler soupHandlerScript;

    private Rigidbody2D bossRB;

    private float jumpTimer;
    public float maxJumpTimer;

    private bool canAttack;

    public float jumpSpeed;

    private bool canJump;

    // Start is called before the first frame update
    void Start()
    {
        
        bossRB = GetComponent<Rigidbody2D>();
        bodyCollider = GetComponent<CircleCollider2D>();
        armsCollider = GetComponents<CapsuleCollider2D>();
        attackCollider = GetComponent<BoxCollider2D>();
        enemyHpHandler = GetComponent<EnemyHpHandler>();
        jumpTimer = maxJumpTimer;
        currLocation = 0;
        canAttack = false;
        disableColliders();


    }

    // Update is called once per frame
    void Update()
    {
        
        if (canJump && jumpTimer >= 0)
        {
            jumpTimer -= Time.deltaTime;
        }
        

        if (canJump && jumpTimer < 0 && !canAttack)
        {
            disableColliders();
        }
        else if (canJump && jumpTimer < 0 && canAttack)
        {
            canAttack = false;
        }


        if (!canJump)
        {

            //  get direction of new location
            Vector2 direction = jumpLocations[currLocation].transform.position - transform.position;
            direction.Normalize();

            //  simple movement to the player
            transform.position = Vector2.MoveTowards(transform.position, jumpLocations[currLocation].transform.position, jumpSpeed * Time.deltaTime);

        }
        else if (canAttack)
        {

            //  activate attack animation

            //  grab soup in trigger hitbox ahead
            if (soupToEat != null || enemyToEat != null)
            {

                if (soupToEat != null)
                {
                    //  0.15f
                    soupToEat.transform.position = Vector2.MoveTowards(soupToEat.transform.position, transform.position, 0.15f * Time.deltaTime);
                }
                if (enemyToEat != null)
                {
                    if (eatHpHandler.getOnFire())
                    {
                        // 0.2f
                        enemyToEat.transform.position = Vector2.MoveTowards(enemyToEat.transform.position, transform.position, 2f * Time.deltaTime);

                    }


                }

            }
            else
            {
                //  if there is no soup to eat
                canAttack = false;
            }



        }



    }

    //  prepare to jump
    private void disableColliders()
    {
        bodyCollider.enabled = false;
        armsCollider[0].enabled = false;
        armsCollider[1].enabled = false;
        attackCollider.enabled = false;
        //  move to new location
        canJump = false;
        soupToEat = null;
        enemyToEat = null;


    }
    //  land after jump
    private void enableColliders()
    {
        bodyCollider.enabled = true;
        armsCollider[0].enabled = true;
        armsCollider[1].enabled = true;
        attackCollider.enabled= true;

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        //  hit jump location
        if (collision.transform.CompareTag("JumpLocation"))
        {

            if (!canJump)
            {
                if (collision.name == "JumpLocation" + currLocation)
                {
                    if (currLocation == 1 || currLocation == 3)
                    {
                        bossRB.rotation = 180f;
                    }
                    else
                    {
                        bossRB.rotation = 0f;
                    }
                    enableColliders();
                    canAttack = true;
                    canJump = true;
                    currLocation++;
                    jumpTimer = maxJumpTimer;
                    if (currLocation == jumpLocations.Length)
                    {
                        currLocation = 0;
                    }
                }
                else
                {
                    //Debug.Log(collision.name + "" + currLocation);
                }
                

            }
            
            

        }

        //  pick up soup to eat
        if (collision.transform.CompareTag("Soup"))
        {

            soupToEat = collision.gameObject;
        }

        if (collision.transform.CompareTag("Enemy"))
        {

            enemyToEat = collision.gameObject;
            eatHpHandler = enemyToEat.GetComponent<EnemyHpHandler>();

        }

       
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        //  eat soup
        if (collision.transform.CompareTag("Soup"))
        {
            
            Destroy(collision.gameObject);
            canAttack = false;
            canJump = true;

        }

        if (collision.transform.CompareTag("Enemy"))
        {
            enemyHpHandler.takeDamage(10);
            Destroy(collision.gameObject);
            canAttack = false;
            canJump = true;
        }
    }

}
