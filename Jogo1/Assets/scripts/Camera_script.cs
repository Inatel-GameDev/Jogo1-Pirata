using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_script : MonoBehaviour
{
    public Transform player;
    public float min_x, max_x, min_y, max_y ;
    public float off_set_x, off_set_y;

    public float base_y, min_dist_y;
    public float timeLerp;
    public bool inverted = false;


    private void Start()
    {
        base_y = player.transform.position.y;
    }
    /*
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            base_y = player.transform.position.y;
            off_set_y = off_set_y * -1;
        }
    }
    */
    private void FixedUpdate()
    {
        /*
        Vector3 newPosition = player.position + new Vector3(0, 0, -10);        
        float distY = Mathf.Abs(player.position.y - base_y);
        Debug.Log(distY);             

        if(distY > min_dist_y)
        {
            base_y = player.transform.position.y;
        }
        

        newPosition.y = base_y + off_set_y;
        newPosition.x += off_set_x;


        newPosition = Vector3.Lerp(transform.position, newPosition, timeLerp);
        transform.position = newPosition;*/
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, min_x, max_x), Mathf.Clamp(transform.position.y, min_y, max_y), transform.position.z);
    }

}
