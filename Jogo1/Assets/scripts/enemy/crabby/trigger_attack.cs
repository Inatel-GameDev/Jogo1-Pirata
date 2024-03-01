using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger_check_attack : MonoBehaviour
{

    public Inimigo enemy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.CompareTag("Player"))
            {
                enemy.hurt_player();
            }
        }
    }
}
