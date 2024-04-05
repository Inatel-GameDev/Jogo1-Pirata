using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : Enemy
{
    public float cooldown;
    public bool can_attack = true;

    private void Start()
    {
        speedInitial = speed;
        animator = GetComponent<enemy_animation>();
        animation_idle = "star_idle";
        animation_running = "star_run";
        animation_attacking = "star_attack";
        animation_hit = "star_hit";
        animation_dead = "star_dead";
    }

    public override void attack()
    {
        attacking = true;
        animator.play_animation(animation_attacking);
        speed = 10;
        Invoke("stop_attacking",2.5f);
    }

    public override void perdeVida(int n)
    {
        vida -= n;
        if (vida <= 0)
        {
            animator.play_animation(animation_dead);
            Invoke("destroy", 0.3f);
        }
        else
        {
            stop_attacking();
            animator.play_animation(animation_hit);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (attacking)
        {
            if (collision.gameObject.tag == "Player" && can_attack)
            {
                hurt_player();
                can_attack = false;
                Invoke("cooldown_passed", cooldown);
            }
        }
        if (collision.collider.tag == "inimigo")
        {
            changeDirection();
            stop_attacking();
        }
    }

    private void cooldown_passed()
    {
        can_attack = true;
    }
}
