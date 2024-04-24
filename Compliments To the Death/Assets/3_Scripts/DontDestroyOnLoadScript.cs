using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoadScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        //  stops dupes from occuring across levels
        GameObject[] dontDestroy = GameObject.FindGameObjectsWithTag("DontDestroyOnLoad");

        if (dontDestroy.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);

    }


}
