using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{
    public Main_player player;

    private void Start()
    {
        player = FindObjectOfType<Main_player>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision != null)
        {
            if (collision.CompareTag("Player")){
                player.add_coin();
                Destroy(gameObject);
            }
        }
    }
}
