using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlowTorchAttack : MonoBehaviour
{
    private EnemyHpHandler enemyHpHandler;
    private EquipedWeaponhandler equipedWeaponHandler;
    public GameObject player;

    public float damage;
    private bool canAttack;
    private float coolDown;

    // Start is called before the first frame update
    void Start()
    {
        canAttack = true;
        coolDown = 1.5f;
        equipedWeaponHandler = player.GetComponent<EquipedWeaponhandler>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!canAttack)
        {
            coolDown -= Time.deltaTime;
            if (coolDown < 0)
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
            


        }

    }

    public void blowTorchAttackEnd()
    {

        equipedWeaponHandler.endOfAttack();
    }


  


}
