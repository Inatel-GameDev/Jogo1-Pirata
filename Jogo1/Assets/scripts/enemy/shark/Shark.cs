using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shark : Enemy
{
    [SerializeField] private float jump;

    private void Start()
    {
        speedInitial = speed;
        animator = GetComponent<enemy_animation>();
        animation_idle = "shark_idle";
        animation_running = "shark_run";
        animation_attacking = "shark_attack";
        animation_hit = "shark_hit";
        animation_dead = "shark_dead";
    }

    public override void attack()
    {
        attacking = true;
        animator.play_animation(animation_attacking);
        Invoke("stop_attacking", 0.5f);
        rig.velocity = new Vector2(direction * jump, rig.velocity.y);
    }

}
