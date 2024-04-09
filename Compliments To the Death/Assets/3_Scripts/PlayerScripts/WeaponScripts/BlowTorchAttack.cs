using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlowTorchAttack : MonoBehaviour
{
    private EnemyHpHandler enemyHpHandler;
    private EquipedWeaponhandler equipedWeaponHandler;
    public GameObject player;
    private Animator animator;

    public float fireDamage;
    private bool canAttack;
    public float maxCoolDown;
    private float coolDown;

    // Start is called before the first frame update
    void Start()
    {
        canAttack = true;
        coolDown = maxCoolDown;
        equipedWeaponHandler = player.GetComponent<EquipedWeaponhandler>();
        animator = GetComponent<Animator>();
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
                coolDown = maxCoolDown;
            }
        }



    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        // bool check
        if (animator.GetBool("BlowTorchIsAttacking"))
        {
            if (collision.transform.CompareTag("Enemy"))
            {

                //  get hp handler script from enemy
                enemyHpHandler = collision.gameObject.GetComponent<EnemyHpHandler>();
                //  execute the damage function
                enemyHpHandler.takeDamage(fireDamage);
                enemyHpHandler.setOnFire();
                //  stop multiattacks from occuring
                canAttack = false;



            }
        }
        
    }

    //  this is called at the end of the blowtorch animation
    public void blowTorchAttackEnd()
    {
        equipedWeaponHandler.endOfAttack();
    }


  


}
