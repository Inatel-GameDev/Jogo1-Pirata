using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collider_check_attack : MonoBehaviour
{

    public Enemy enemy;
    public float cooldown;
    public bool can_attack = true;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null)
        {
            if (collision.gameObject.tag == "Player" && can_attack)
            {
                enemy.hurt_player();
                can_attack = false;
                Invoke("cooldown_passed", cooldown);
            }
        }
    }

    private void cooldown_passed()
    {
        can_attack = true;
    }
}

