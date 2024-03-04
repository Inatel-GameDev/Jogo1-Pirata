using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shark : Enemy
{
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

}
