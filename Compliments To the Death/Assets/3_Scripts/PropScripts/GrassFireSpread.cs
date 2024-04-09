using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassFireSpread : MonoBehaviour
{


    private bool onFire;
    public float burnTime;

    private GameObject fireEffect;



    // Start is called before the first frame update
    void Start()
    {
        fireEffect = transform.GetChild(0).gameObject;
    }

    private void Update()
    {
        if (onFire && burnTime > 0)
        {
            burnTime -= Time.deltaTime;
        }
        if (burnTime <= 0)
        {
            onFire = false;
            this.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.transform.CompareTag("GrassProp"))
        {
            setGrassOnFire();
        }
        if (collision.transform.CompareTag("Enemy") && onFire)
        {
            collision.gameObject.GetComponent<EnemyHpHandler>().setOnFire();
        }
    }

    public void setGrassOnFire()
    {
        onFire = true;
        fireEffect.SetActive(true);
    }


}
