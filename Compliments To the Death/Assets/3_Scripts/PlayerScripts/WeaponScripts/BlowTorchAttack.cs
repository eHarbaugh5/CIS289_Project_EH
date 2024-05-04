using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlowTorchAttack : MonoBehaviour
{
    private EnemyHpHandler enemyHpHandler;
    private EquipedWeaponhandler equipedWeaponHandler;
    private Collider2D blowTorchAttackCollider;
    public GameObject player;
    private Animator animator;

    public float fireDamage;
    public float maxCoolDown;


    // Start is called before the first frame update
    void Start()
    {
        equipedWeaponHandler = player.GetComponent<EquipedWeaponhandler>();
        animator = GetComponent<Animator>();
        blowTorchAttackCollider = GetComponent<Collider2D>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        // bool check
        if (animator.GetBool("BlowTorchIsAttacking"))
        {
            if (collision.transform.CompareTag("Enemy") || collision.transform.CompareTag("Boss"))
            {

                //  get hp handler script from enemy
                enemyHpHandler = collision.gameObject.GetComponent<EnemyHpHandler>();
                //  execute the damage function
                enemyHpHandler.takeDamage(fireDamage);
                enemyHpHandler.setOnFire();
                //  stop multiattacks from occuring
                //canAttack = false;



            }

            if (collision.CompareTag("GrassProp"))
            {

                collision.gameObject.GetComponent<GrassFireSpread>().setGrassOnFire();

            }
        }
        
    }

    //  this is called at the end of the blowtorch animation
    public void blowTorchAttackEnd()
    {
        equipedWeaponHandler.endOfAttack();
    }


  


}
