using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_animation : MonoBehaviour
{
    public Animator animator;
    public Inimigo inimigo;
    private string currentAnimation;

    public string CurrentAnimation { get => currentAnimation; set => currentAnimation = value; }

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void play_animation(string newAnimation)
    {
        if (currentAnimation == newAnimation) return;
        animator.Play(newAnimation);
        currentAnimation = newAnimation;

    }

    public void check_direction()
    {
        if (inimigo.Direction < 0)
        {
            transform.eulerAngles = new Vector2(0, 180);
        }
        else if (inimigo.Direction > 0)
        {
            transform.eulerAngles = new Vector2(0, 0);
        }
    }
}
