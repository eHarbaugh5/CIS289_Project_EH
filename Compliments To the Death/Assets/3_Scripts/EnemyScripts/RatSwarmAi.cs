using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatSwarmAi : MonoBehaviour
{

    public float speed;
    private Vector2 direction;
    private Vector2 lookDirection;





    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = Vector2.MoveTowards(transform.position, direction, speed * Time.deltaTime);


    }

    public void setDirection(float y)
    {
        
            direction = new Vector2(transform.position.x, y);

            Vector2 lookDirection = direction;
            lookDirection.Normalize();

            //  get the angle, convert from radian to degree    [-90] because all my sprites are rotated
            float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90;

            transform.rotation = Quaternion.Euler(Vector3.forward * angle);
        
        
        

    }


}
