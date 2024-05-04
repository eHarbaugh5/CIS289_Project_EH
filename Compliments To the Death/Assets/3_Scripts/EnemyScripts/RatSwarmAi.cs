using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatSwarmAi : MonoBehaviour
{

    public float speed;
    private Vector2 direction;
    private Vector2 lookDirection;

    private float attackCooldown;
    public float maxAttackCooldown;



    // Start is called before the first frame update
    void Start()
    {
        attackCooldown = 0;
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = Vector2.MoveTowards(transform.position, direction, speed * Time.deltaTime);
        if (attackCooldown > 0)
        {
            attackCooldown -= Time.deltaTime;
        }

    }

    public void setDirection(float y)
    {
        
            direction = new Vector2(transform.position.x, y);

            Vector2 lookDirection = direction;
            lookDirection.Normalize();

            //  get the angle, convert from radian to degree    [-90] because all my sprites are rotated
            float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90;

            transform.rotation = Quaternion.Euler(Vector3.forward * angle);
        
        
        

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
        

        if (collision.transform.CompareTag("TileMapCollider"))
        {
            Destroy(this.gameObject);
        }


    }


}
