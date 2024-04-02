using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FryingPanAttack : MonoBehaviour
{

    private EnemyHpHandler enemyHpHandler;
    private Rigidbody2D enemyRigidbody;

    public GameObject player;
    private Rigidbody2D playerRB;
    private Vector2 KnockBack;

    public float damage;
    private bool canAttack;
    private float coolDown;

    // Start is called before the first frame update
    void Start()
    {
        canAttack = true;
        coolDown = 1.5f;
        playerRB = player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!canAttack)
        {
            coolDown -= Time.deltaTime;
            if (coolDown < 0 )
            {
                canAttack = true;
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
            enemyHpHandler.takeDamage(damage);
            //  stop multiattacks from occuring
            canAttack = false;
            //  get enemy rigidbody for knockback
            enemyRigidbody = collision.gameObject.GetComponent<Rigidbody2D>();

            //  set knockback to scale off of current velocity
            KnockBack = new  Vector2(playerRB.velocity.x * 7, playerRB.velocity.y * 7);
            //  add the knockbac force

            enemyRigidbody.velocity = enemyRigidbody.velocity + KnockBack;
            //enemyRigidbody.AddForce(KnockBack);



        }

    }



}
