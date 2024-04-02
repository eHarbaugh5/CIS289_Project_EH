using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EquipedWeaponhandler : MonoBehaviour
{

    private GameObject FryingPan;
    private GameObject BlowTorch;
    private GameObject Tongs;

    private Animator animator;
    private Rigidbody2D playerRB;



    private string currentWeapon;
    private float coolDown;
    public float coolDownTime;

    bool canChangeWeapon;
    //bool isAttacking;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        playerRB = GetComponent<Rigidbody2D>();

        //  initial
        canChangeWeapon = true;
        coolDownTime = 0.4f;
        coolDown = coolDownTime;
        

        //isAttacking = false;

        //  get weapons
        FryingPan = this.transform.GetChild(1).gameObject;
        currentWeapon = FryingPan.name;
        BlowTorch = this.transform.GetChild(2).gameObject;
        Tongs = this.transform.GetChild(3).gameObject;

        //  disable non initial weapons
        BlowTorch.SetActive(false);
        Tongs.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

        attackWithCurrentWeapon();
        checkForWeaponSwap();

        if (!canChangeWeapon) 
        {
            coolDown -= Time.deltaTime;
        }
        if (coolDown < 0)
        {
            canChangeWeapon = true;
            coolDown = coolDownTime;
        }
        
    }

    private void checkForWeaponSwap()
    {

        //  swaps weapons based on key press
        if (Input.GetKeyDown(KeyCode.B) && canChangeWeapon)
        {
            canChangeWeapon = false;
            updateCurrentWeapon(0);
        }
        if (Input.GetKeyDown(KeyCode.N) && canChangeWeapon)
        {
            canChangeWeapon = false;
            updateCurrentWeapon(1);
        }
        if (Input.GetKeyDown(KeyCode.M) && canChangeWeapon)
        {
            canChangeWeapon = false;
            updateCurrentWeapon(2);
        }

    }

    private void updateCurrentWeapon(int weapon)
    {


        //  disable all
        FryingPan.SetActive(false);
        BlowTorch.SetActive(false);
        Tongs.SetActive(false);

        //  enable current
        if (weapon == 0)
        {
            FryingPan.SetActive(true);
            currentWeapon = FryingPan.name;

        }
        else if (weapon == 1)
        {
            currentWeapon = BlowTorch.name;
            BlowTorch.SetActive(true);
        }
        else if (weapon == 2)
        {
            currentWeapon = Tongs.name;
            Tongs.SetActive(true);
        }

        canChangeWeapon = true;



    }

    private void attackWithCurrentWeapon()
    {
        

        if (Input.GetKeyDown("space") && canChangeWeapon) //&& !isAttacking)
        {
            //animator.enabled = true;
            canChangeWeapon = false;
            //isAttacking = true;

            if (currentWeapon == "FryingPan")
            {

                float speed = 27f;
                
                var impulse = (360 * Mathf.Deg2Rad) * speed;

                playerRB.AddTorque(impulse, ForceMode2D.Impulse);


                

            }

        }

    }

    public void endOfAttack()
    {

        animator.SetBool("FryingPanIsAttacking", false);
        canChangeWeapon = true;

        animator.enabled = false;

    }

    public string getCurrentWeapon()
    {
        return currentWeapon;
    }

    public bool getCanChangeWeapon()
    {
        return canChangeWeapon;
    }


}
