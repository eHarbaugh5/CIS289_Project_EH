using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicEnemyAi : MonoBehaviour
{

    private GameObject player;
    public float speed;

    private float distance;
    public float activeDistance;

    public float AttackCooldown;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

        //  get the distance  between enemy and player
        distance = Vector2.Distance(transform.position, player.transform.position);

        
        //  activate movement if player is in range
        if (distance < activeDistance)
        {
            enemyActive();
        }
    }

    void enemyActive()
    {
        //  dont move if on attack cooldown
        if (AttackCooldown <= 0)
        {
            //  get direction of player
            Vector2 direction = player.transform.position - transform.position;
            direction.Normalize();

            //  get the angle, convert from radian to degree    [-90] because all my sprites are rotated
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
            //  rotate the sprite based on the previously given angle
            transform.rotation = Quaternion.Euler(Vector3.forward * angle);

            //  simple movement to the player
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
        else if (AttackCooldown > 0)
        {
            AttackCooldown -= Time.deltaTime;
        }
        

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        /*if (collision.transform.CompareTag("PlayerHitBox"))
        {
            Debug.Log("hitbox");
            AttackCooldown = 1.25f;

        }*/
        if (collision.transform.CompareTag("Player"))
        {
            //Debug.Log("Player hit");
            AttackCooldown = 1.25f;
        }
       // Debug.Log(collision.transform.tag);


    }


}
