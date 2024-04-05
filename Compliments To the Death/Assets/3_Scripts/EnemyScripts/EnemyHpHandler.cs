using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyHpHandler : MonoBehaviour
{

    public float maxHp;
    public float currentHp;

    private bool isOnFire;
    public float fireDamage;
    public float maxFireBurnTime;
    private float fireBurnTime;
    public bool isBurnable;


    // Start is called before the first frame update
    void Start()
    {
        currentHp = maxHp;
        fireBurnTime = maxFireBurnTime;
        isOnFire = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (isOnFire)
        {
        
            currentHp -= fireDamage * Time.deltaTime;
            fireBurnTime -= Time.deltaTime;

            if (fireBurnTime <= 0)
            {
                isOnFire = false;
                fireBurnTime = maxFireBurnTime;
                //  update fire sprite status
            }

        }

        if (currentHp < 0)
        {
            //  die
            Debug.Log("Enemy Has Died");
            Destroy(this.gameObject);

        }


    }

    public void takeDamage(float damage)
    {

        currentHp -= damage;

    }

    public void setOnFire()
    {
        if (isBurnable)
        {
            isOnFire = true;
            //  update fire sprite status
        }
        

    }


}
