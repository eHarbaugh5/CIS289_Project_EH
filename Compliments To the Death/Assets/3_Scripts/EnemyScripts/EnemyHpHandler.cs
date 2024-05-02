using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyHpHandler : MonoBehaviour
{

    public float maxHp;
    public float currentHp;


    //  Fire
    private SpriteRenderer fireSprite;
    private Animator pitFallAnimator;
    private Animator fireAnimator;
    private bool isOnFire;
    public float fireDamage;
    public float maxFireBurnTime;
    private float fireBurnTime;
    public bool isBurnable;
    public bool isFlying;


    // Start is called before the first frame update
    void Start()
    {
        currentHp = maxHp;
        fireBurnTime = maxFireBurnTime;
        isOnFire = false;
        fireSprite = transform.GetChild(0).GetComponent<SpriteRenderer>();
        fireAnimator = transform.GetChild(0).GetComponent<Animator>();
        pitFallAnimator = transform.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (isOnFire)
        {
            fireSprite.enabled = true;
            fireAnimator.enabled = true;
            currentHp -= fireDamage * Time.deltaTime;
            fireBurnTime -= Time.deltaTime;

            if (fireBurnTime <= 0)
            {
                isOnFire = false;
                fireBurnTime = maxFireBurnTime;
                //  update fire sprite status
                fireSprite.enabled = false;
                fireAnimator.enabled = false;
            }

        }


        if (currentHp <= 0)
        {
            //  die
            Debug.Log(this.gameObject.transform.name + " Has been Slayen");
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

    public bool getIsFlying()
    {
        return isFlying;
    }

    //  called by pit fall collision
    public void fallInPit()
    {

        if (!isFlying)
        {

            pitFallAnimator.enabled = true;


        }

    }

    //  end of pitfall animation, will remove enemy
    public void removeEnemy()
    {

        Destroy(this.gameObject);
    }





}
