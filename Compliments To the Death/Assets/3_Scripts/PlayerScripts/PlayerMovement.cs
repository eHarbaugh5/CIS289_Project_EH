using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Windows;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D playerRB;
    private EquipedWeaponhandler equipedWeaponHandler;



    public float movementSpeed;
    private float inputHorizontal;
    private float inputVertical;
    private Vector2 moveInput;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        equipedWeaponHandler = GetComponent<EquipedWeaponhandler>();
        
    }

    // Update is called once per frame
    void Update()
    {
        playerMovementHandler();
        

    }

    private void playerMovementHandler()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");
        playerRotationHandler();
        moveInput = new Vector2(inputHorizontal * movementSpeed, inputVertical * movementSpeed);
        playerRB.AddForce(moveInput);
        //playerRB.velocity = moveInput;

        //playerRB.velocity.x + 
        //playerRB.velocity.y +
    }


    void playerRotationHandler()
    {
        if (equipedWeaponHandler.getCanChangeWeapon())
        {
            if (inputVertical != 0 && inputHorizontal != 0)
            {
                //  Up + Right
                if (inputVertical == 1f && inputHorizontal == 1)
                {
                    playerRB.rotation = -45f;
                }
                //  Down + Right
                else if (inputVertical == -1f && inputHorizontal == 1)
                {
                    playerRB.rotation = -135f;
                }
                //  Down + left
                else if (inputVertical == -1f && inputHorizontal == -1)
                {
                    playerRB.rotation = 135f;
                }
                //  Up + Left
                else if (inputVertical == 1f && inputHorizontal == -1)
                {
                    playerRB.rotation = 45f;
                }
            }
            else
            {
                //  Up
                if (inputVertical == 1f && inputHorizontal == 0)
                {
                    playerRB.rotation = 0f;
                }
                //  Down
                else if (inputVertical == -1f && inputHorizontal == 0)
                {
                    playerRB.rotation = 180f;
                }
                //  Left
                else if (inputHorizontal == -1f && inputVertical == 0)
                {
                    playerRB.rotation = 90f;
                }
                //  Right
                else if (inputHorizontal == 1f && inputVertical == 0)
                {
                    playerRB.rotation = -90f;
                }
            }
        }

        
        
        
        





    }


    

}
