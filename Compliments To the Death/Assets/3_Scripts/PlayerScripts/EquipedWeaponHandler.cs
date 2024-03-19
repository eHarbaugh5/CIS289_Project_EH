using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipedWeaponhandler : MonoBehaviour
{

    private GameObject FryingPan;
    private GameObject BlowTorch;
    private GameObject Tongs;

    /*private SpriteRenderer FryingPanRenderer;
    private SpriteRenderer BlowTorchRenderer;
    private SpriteRenderer TongsRenderer;*/

    private string currentWeapon;

    bool canChangeWeapon;

    // Start is called before the first frame update
    void Start()
    {
        //  initial
        canChangeWeapon = true;

        //  get weapons
        FryingPan = this.transform.GetChild(1).gameObject;
        currentWeapon = FryingPan.name;
        BlowTorch = this.transform.GetChild(2).gameObject;
        Tongs = this.transform.GetChild(3).gameObject;

        //  disable non initial weapons
        BlowTorch.SetActive(false);
        Tongs.SetActive(false);

        /*FryingPanRenderer = FryingPan.GetComponent<SpriteRenderer>();
        BlowTorchRenderer = BlowTorch.GetComponent<SpriteRenderer>();
        TongsRenderer = Tongs.GetComponent<SpriteRenderer>();*/
    }

    // Update is called once per frame
    void Update()
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




}
