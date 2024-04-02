using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPropRotation : MonoBehaviour
{

    private float inputHorizontal;
    private float inputVertical;
    private Rigidbody2D RB;

    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");
        rotateEnemys();
    }


    private void rotateEnemys()
    {

       
        if (inputVertical != 0 && inputHorizontal != 0)
        {
            //  Up + Right
            if (inputVertical == 1f && inputHorizontal == 1)
            {
                RB.rotation = -45f;
            }
            //  Down + Right
            else if (inputVertical == -1f && inputHorizontal == 1)
            {
                RB.rotation = -135f;
            }
            //  Down + left
            else if (inputVertical == -1f && inputHorizontal == -1)
            {
                RB.rotation = 135f;
            }
            //  Up + Left
            else if (inputVertical == 1f && inputHorizontal == -1)
            {
                RB.rotation = 45f;
            }
        }
        else
        {
            //  Up
            if (inputVertical == 1f && inputHorizontal == 0)
            {
                RB.rotation = 0f;
            }
            //  Down
            else if (inputVertical == -1f && inputHorizontal == 0)
            {
                RB.rotation = 180f;
            }
            //  Left
            else if (inputHorizontal == -1f && inputVertical == 0)
            {
                RB.rotation = 90f;
            }
            //  Right
            else if (inputHorizontal == 1f && inputVertical == 0)
            {
                RB.rotation = -90f;
            }
        }
    }

    
       


}
