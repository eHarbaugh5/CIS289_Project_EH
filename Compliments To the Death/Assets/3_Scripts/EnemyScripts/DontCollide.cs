using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontCollide : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Physics2D.IgnoreLayerCollision(10, 6);

    }

   
}
