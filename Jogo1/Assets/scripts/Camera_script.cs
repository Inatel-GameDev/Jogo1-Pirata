using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_script : MonoBehaviour
{
    public Transform player;
    public float min_x, max_x;
    public float min_y, max_y;
    public float timeLerp;

    // Start is called before the first frame update
    private void FixedUpdate()
    {
        Vector3 newPosition = player.position + new Vector3(0, 0, -10);

        newPosition.y = 0.1f;

        newPosition = Vector3.Lerp(transform.position, newPosition, timeLerp);
        transform.position = newPosition;
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, min_x, max_x), Mathf.Clamp(transform.position.y, min_y, max_y), transform.position.z);


    }
}
