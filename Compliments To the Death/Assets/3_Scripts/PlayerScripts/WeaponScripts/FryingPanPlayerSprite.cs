using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FryingPanPlayerSprite : MonoBehaviour
{

    private EquipedWeaponhandler equipedWeaponHandler;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        equipedWeaponHandler = player.GetComponent<EquipedWeaponhandler>();
    }


    public void FryingPanAttackEnd()
    {
        equipedWeaponHandler.endOfAttack();
    }

}
