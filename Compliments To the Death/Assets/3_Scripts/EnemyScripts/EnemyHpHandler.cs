using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyHpHandler : MonoBehaviour
{

    public float maxHp;
    private float currentHp;


    // Start is called before the first frame update
    void Start()
    {
        currentHp = maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHp < 0)
        {
            //  die
            Destroy(this.gameObject);
            //transform.Translate(transform.position.x + 0.25f, transform.position.y, transform.position.z);
        }
    }

    public void takeDamage(float damage)
    {

        currentHp -= damage;

    }

}
