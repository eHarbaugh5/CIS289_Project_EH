using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicEnemyAi : MonoBehaviour
{

    private GameObject player;
    public float speed;

    private float distance;
    public float activeDistance;

    private float attackCooldown;
    public float maxAttackCooldown;

    


// Start is called before the first frame update
void Start()
    {
        player = GameObject.FindWithTag("Player");
        //attackCooldown = maxAttackCooldown;
        attackCooldown = 0;
        
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
        if (attackCooldown <= 0)
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
        else if (attackCooldown > 0)
        {
            attackCooldown -= Time.deltaTime;
        }
        

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.collider.gameObject.CompareTag("PlayerHitBox"))
        {
            if (attackCooldown <= 0)
            {
                collision.gameObject.GetComponent<PlayerMovement>().playerHit(1);
                attackCooldown = maxAttackCooldown;
            }
            
            
        }


    }


}
