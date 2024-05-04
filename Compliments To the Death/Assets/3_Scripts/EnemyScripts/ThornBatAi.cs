using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ThornBatAi : MonoBehaviour
{

    private GameObject player;

    public float speed;

    private EnemyHpHandler hpHandler;

    private bool isOnFire;


    private float attackCooldown;
    public float maxAttackCooldown;

    // Start is called before the first frame update
    void Start()
    {
        attackCooldown = 0;
        isOnFire = false;
        player = GameObject.FindWithTag("Player");
        hpHandler = transform.gameObject.GetComponent<EnemyHpHandler>();
    }

    // Update is called once per frame
    void Update()
    {

        isOnFire = hpHandler.getOnFire();


        if (!isOnFire && attackCooldown <= 0)
        {

            Vector2 direction = player.transform.position - transform.position;
            direction.Normalize();

            //  get the angle, convert from radian to degree    [-90] because all my sprites are rotated
            //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
            //  rotate the sprite based on the previously given angle
            //transform.rotation = Quaternion.Euler(Vector3.forward * angle);


            //  simple movement to the player
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);


        }

        if (attackCooldown > 0)
        {
            attackCooldown -= Time.deltaTime;
        }


    }




    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.gameObject.CompareTag("Player"))
        {

            if (attackCooldown <= 0)
            {
                collision.gameObject.GetComponent<PlayerMovement>().playerHit(1);
                attackCooldown = maxAttackCooldown;
            }
        }


    }
}
