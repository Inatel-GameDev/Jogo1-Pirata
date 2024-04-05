using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public int direction = 1;
    public int speed;
    public int speedInitial;
    public int vida;
    public int dano;
    public Main_player player;
    public Rigidbody2D rig;

    public enemy_animation animator;
    public bool attacking = false;

    [SerializeField] private Vector2 knockback;

    public string animation_idle;
    public string animation_running;
    public string animation_attacking;
    public string animation_hit;
    public string animation_dead;


    private void Start()
    {
        player = FindObjectOfType<Main_player>();
    }

    public void hurt_player()
    {
        Vector2 direction = (player.transform.position - gameObject.transform.position).normalized;
        direction.y = 0;
        player.perdeVida(dano, direction);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "inimigo")
        {
            changeDirection();
        }
    }

    public  void changeDirection()
    {
        direction = direction * -1;
        animator.invert_sprite_direction();
    }


    public virtual void attack()
    {
        attacking = true;
        animator.play_animation(animation_attacking);
        Invoke("stop_attacking", 0.5f);
        speed = 1;
    }

    public virtual void perdeVida(int n)
    {
        vida -= n;
        if (vida <= 0)
        {
            animator.play_animation(animation_dead);
            Invoke("destroy", 0.3f);
        }
        else
        {
            animator.play_animation(animation_hit);
        }
    }


    public virtual void stop_attacking()
    {
        attacking = false;
        animator.play_animation(animation_running);
        speed = speedInitial;
    }


    private void destroy()
    {
        Destroy(gameObject);
    }

    void FixedUpdate()
    {
        rig.velocity = new Vector2(direction * speed, rig.velocity.y);

        if (!attacking)
        {
            if (rig.velocity.x != 0)
            {
                animator.play_animation(animation_running);
            }
            else
            {
                animator.play_animation(animation_idle);
            }
        }
    }

    /*public void enemy_knockback()
{
    rig.AddForce(knockback, ForceMode2D.Impulse); //if you don't want to take into consideration enemy's mass then use ForceMode.VelocityChange
}*/

}
