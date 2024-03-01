using UnityEngine;

public class Player_animation : MonoBehaviour
{
    public Animator animator;
    public Main_player player;
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
        if (player._direction.x < 0)
        {
            transform.eulerAngles = new Vector2(0, 180);
        }
        else if (player._direction.x > 0)
        {
            transform.eulerAngles = new Vector2(0, 0);
        }
    }
}
