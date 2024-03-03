using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colisor_espada : MonoBehaviour
{
    public Main_player player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision != null)
        {
            if (collision.CompareTag("inimigo")){
                player.attack(collision.GetComponent<Inimigo>());
            
            } else if (collision.CompareTag("Trap")){
                player.attack(collision.GetComponent<cannon>());
            }
        }
    }
}
