using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TongAttack : MonoBehaviour
{

    private EnemyHpHandler enemyHpHandler;
    private EquipedWeaponhandler equipedWeaponHandler;

    public float damage;
    public float maxCoolDown;
    private float coolDown;
    private bool hitOnCooldown;


    // Start is called before the first frame update
    void Start()
    {
        coolDown = maxCoolDown;
        hitOnCooldown = false;
        equipedWeaponHandler = transform.parent.parent.GetComponent<EquipedWeaponhandler>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hitOnCooldown)
        {
            coolDown -= Time.deltaTime;
            if (coolDown <= 0)
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

            hitOnCooldown = true;



        }

    }
    //  Called In Animation
    public void tongsAttackEnd()
    {
        equipedWeaponHandler.endOfAttack();
    }


}
