using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_script : MonoBehaviour
{
    public Transform player;
    public float min_x, max_x, off_set_x;
    public float min_y, max_y, min_dist_y, off_set_y;

    public bool movingY;
    public int directionY = 1;
    public float base_y;
    public float timeLerp;


    private void Start()
    {
        base_y = transform.position.y + off_set_y;
    }
    

    private void FixedUpdate()
    {
        Vector3 newPosition = player.position + new Vector3(0, 0, -10);        
        float distY = player.position.y - transform.position.y;
        Debug.Log(distY);

        if (!movingY) { 
            if (Mathf.Abs(distY) > min_dist_y)
            {
                if (distY > 0)
                {
                    directionY = 1;
                    movingY = true;
                } else
                {
                    movingY = true;
                    directionY = -1;
                }
        
            } else {
                newPosition.y = base_y + off_set_y;
            }
        }
        else
        {
            if(Mathf.Abs(distY) < 1)
            {
                movingY = false;
                base_y = transform.position.y;
            }
            newPosition.y += directionY * off_set_y;
        }


        /*        float distX = Mathf.Abs(player.position.x - transform.position.x);      
                if (distX < min_dist_x)
                {
                    newPosition.x = 0.1f;
                } else {
                    newPosition.x += off_set_x;
                }*/

        newPosition.x += off_set_x;

        newPosition = Vector3.Lerp(transform.position, newPosition, timeLerp);
        transform.position = newPosition;
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, min_x, max_x), Mathf.Clamp(transform.position.y, min_y, max_y), transform.position.z);
    }

}
