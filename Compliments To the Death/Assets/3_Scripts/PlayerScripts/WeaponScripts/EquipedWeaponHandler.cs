using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EquipedWeaponhandler : MonoBehaviour
{

    private GameObject FryingPan;
    private FryingPanAttack fryingPanAttackSc;
    private GameObject BlowTorch;
    private GameObject Tongs;

    private Animator animator;
    private GameObject player;

    private string currentWeapon;
    private float coolDown;
    public float coolDownTime;

    bool canChangeWeapon;
    //bool isAttacking;

    // Start is called before the first frame update
    void Start()
    {
        //  components and childs
        animator = GetComponent<Animator>();
        player = this.transform.GetChild(0).gameObject;

        //  initial
        canChangeWeapon = true;
        coolDown = coolDownTime;


        //isAttacking = false;

        //  get weapons
        FryingPan = this.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
        fryingPanAttackSc = FryingPan.GetComponent<FryingPanAttack>();
        currentWeapon = FryingPan.name;
        BlowTorch = this.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject;
        Tongs = this.transform.GetChild(0).gameObject.transform.GetChild(2).gameObject;

        //  disable non initial weapons
        BlowTorch.SetActive(false);
        Tongs.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        //  check for attack
        attackWithCurrentWeapon();
        //  check for swap
        checkForWeaponSwap();

        //  after attack reset attack based on cooldown
        if (!canChangeWeapon)
        {
            coolDown -= Time.deltaTime;
        }
        if (coolDown <= 0)
        {
            canChangeWeapon = true;
            coolDown = coolDownTime;
            fryingPanAttackSc.setHitOnCoolDown(false);
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

    //  updates current weapon when a weapon change occurs
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



    }

    //  if space is pressed and weapoon can be changed, initate attack animation
    private void attackWithCurrentWeapon()
    {
        

        if (Input.GetKeyDown("space") && canChangeWeapon)
        {
            canChangeWeapon = false;

            if (currentWeapon == "FryingPan")
            {

                animator = player.GetComponent<Animator>();

                animator.SetBool("FryingPanIsAttacking", true);


            }
            else if (currentWeapon == "BlowTorch")
            {

               // Debug.Log("blowtorch");
                animator = player.transform.GetChild(1).gameObject.GetComponent<Animator>();

                animator.SetBool("BlowTorchIsAttacking", true);


            }

        }

    }

    //  Attack Ends -- Animation calls this to reset bools
    public void endOfAttack()
    {
        if (currentWeapon == "FryingPan")
        {
            animator.SetBool("FryingPanIsAttacking", false);
        }
        else if (currentWeapon == "BlowTorch")
        {
            animator.SetBool("BlowTorchIsAttacking", false);
        }
        
       
        canChangeWeapon = true;


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
