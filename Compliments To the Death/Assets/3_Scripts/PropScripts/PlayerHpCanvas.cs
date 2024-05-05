using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHpCanvas : MonoBehaviour
{


    private GameObject player;
    private PlayerMovement playerHp;

    private RawImage hpBar;

    private float healthScale;
    private float maxHealthScale;




    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        maxHealthScale = 6;
        playerHp = player.GetComponent<PlayerMovement>();
        hpBar = transform.GetChild(1).GetComponent<RawImage>();
    }


    // Update is called once per frame
    void Update()
    {



        healthScale = playerHp.getPlayerHp();

        hpBar.transform.localScale = new Vector3((healthScale / maxHealthScale) * 2.25f, 0.3f, 1);


    }




}

