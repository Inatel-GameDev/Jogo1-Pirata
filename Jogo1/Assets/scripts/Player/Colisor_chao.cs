using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colisor_chao : MonoBehaviour
{
    
    public Main_player player;


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.CompareTag("chao"))
            {
                player.On_ground = true;
                player.segundo_pulo_up = true;
                player.player_animator.play_animation("player_idle");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.CompareTag("chao"))
            {
                player.On_ground = false;
            }
        }
    }
}
