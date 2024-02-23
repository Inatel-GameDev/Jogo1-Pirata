using UnityEngine;

public class Inimigo : MonoBehaviour
{
    // stats 
    [SerializeField] private int speed;
    [SerializeField] private int vida;
    [SerializeField] private int dano;
    [SerializeField] private int direction = 1;
    [SerializeField] private Vector2 knockback;

    public Main_player player;
    public Rigidbody2D rig;
    public enemy_animation animator;

    public int Direction { get => direction; set => direction = value; }

    //public int Vida { get => vida; set => vida = value; }

    private void Start()
    {
        animator = GetComponent<enemy_animation>();
    }

    public void perdeVida(int n)
    {
        vida -= n;
        if(vida <= 0) {
            animator.play_animation("crabby_dead_hit");
            Invoke("destroy", 0.3f);
        } else
        {
            Invoke("goBack",1f);
            Invoke("goBack", 2f);
            animator.play_animation("crabby_hit");
        }
    }
    private void destroy()
    {
        Debug.Log("aa");
        Destroy(gameObject);
    }

    void Update()
    {
        rig.velocity = new Vector2(Direction * speed, rig.velocity.y);
        
        if (rig.velocity.x != 0)
        {
            animator.play_animation("crabby_running");
        } else
        {
            animator.play_animation("crabby_idle");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision != null)
        {
            if (collision.collider.tag == "Player")
            {
                player.perdeVida(dano);
                enemy_knockback();
            }
        }
    }

    public void changeDirection(int d)
    {
        Direction = d;
    }
    public void goBack()
    {
        Direction = -1 * direction;
    }

    public void enemy_knockback()
    {
        rig.AddForce(knockback, ForceMode2D.Impulse); //if you don't want to take into consideration enemy's mass then use ForceMode.VelocityChange
    }
}
