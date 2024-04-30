using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FryingPanAttack : MonoBehaviour
{

    private EnemyHpHandler enemyHpHandler;
    private Rigidbody2D enemyRigidbody;

    private bool hitOnCooldown;

    public GameObject player;
    private Rigidbody2D playerRB;
    private Vector2 KnockBack;
    public float knockBackStrength;

    public float damage;
    private float coolDown;

    // Start is called before the first frame update
    void Start()
    {
        //canAttack = true;
        coolDown = 1.5f;
        hitOnCooldown = false;

        //  player rigidbody
        playerRB = player.GetComponent<Rigidbody2D>();

        Physics2D.IgnoreLayerCollision(10, 6);



    }

    // Update is called once per frame
    void Update()
    {
        
        if (hitOnCooldown)
        {
            coolDown -= Time.deltaTime;
            if (coolDown <= 0 )
            {

                hitOnCooldown = false;
                coolDown = 1.5f;
            }
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {

            //  get hp handler script from enemy
            enemyHpHandler = collision.gameObject.GetComponent<EnemyHpHandler>();
            //  execute the damage function
            if (!hitOnCooldown)
            {
                enemyHpHandler.takeDamage(damage);
            }
            

            //  get enemy rigidbody for knockback
            enemyRigidbody = collision.gameObject.GetComponent<Rigidbody2D>();

            Vector2 knockBack = (collision.transform.position - player.transform.position).normalized;
            enemyRigidbody.AddForce(knockBack*knockBackStrength, ForceMode2D.Impulse);

            //  set knockback to scale off of current velocity
            //KnockBack = new  Vector2(playerRB.velocity.x * 7, playerRB.velocity.y * 7);
            //  add the knockbac force

            //enemyRigidbody.velocity = KnockBack;
            //enemyRigidbody.AddForce(KnockBack);

            hitOnCooldown = true;



        }

    }

    public void setHitOnCoolDown(bool h)
    {
        hitOnCooldown = h;
    }



}
