using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bossHpFrameHandler : MonoBehaviour
{


    public GameObject boss;
    private EnemyHpHandler bossHp;

    private RawImage hpBar;

    private float healthScale;
    private float maxHealthScale;



    // Start is called before the first frame update
    void Start()
    {
        maxHealthScale = 50;
        bossHp = boss.GetComponent<EnemyHpHandler>();
        hpBar = transform.GetChild(1).GetComponent<RawImage>();
    }

    // Update is called once per frame
    void Update()
    {



        healthScale = bossHp.getCurrentHp();

        hpBar.transform.localScale = new Vector3((healthScale / maxHealthScale) * 2.25f, 0.3f, 1);

        if (healthScale <= 0)
        {

            hpBar.enabled = false;

        }






    }




}
