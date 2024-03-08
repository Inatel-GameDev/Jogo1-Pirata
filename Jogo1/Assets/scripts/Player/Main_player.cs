using UnityEngine;

public class Main_player : MonoBehaviour
{
    // stats 
    [SerializeField] private int speed;
    [SerializeField] private int vida;
    [SerializeField] private int life_max;
    [SerializeField] private int dano;
    [SerializeField] private int coins;

    // combate 
    [SerializeField] private float knockback;
    [SerializeField] private bool attacking;

    // pulo 
    [SerializeField] private int jump_force;
    [SerializeField] public bool segundo_pulo_up;
    [SerializeField] private bool _on_ground;

    // movimento 
    public Vector2 _direction;
    public Rigidbody2D rig;
    public Main_player player;

    //ui
    public UI_manager ui_manager;

    // animações 
    public Player_animation player_animator;

    // GameState
    public bool IsPaused = false;

    // Getters e Setters
    public bool On_ground { get => _on_ground; set => _on_ground = value; }
    public bool Life_max { get => _on_ground; set => _on_ground = value; }



    void Start()
    {
        player = GetComponent<Main_player>();
        rig = GetComponent<Rigidbody2D>();
        player_animator = GetComponent<Player_animation>();
        segundo_pulo_up = true;
    }

    private void restart()
    {
        GameManager.Instance.restartGame();
    }


    void Update()
    {
        if(IsPaused) return;
        check_move();
        check_attack();
        check_fall();
        check_pause();
    }

    private void check_fall()
    {
        if (transform.position.y < -7)
        {
            killPlayer();
        }
    }

    void check_move()
    {
        rig.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rig.velocity.y);
        
        
        if(Input.GetKeyDown(KeyCode.Space) & On_ground)
        { 
            rig.velocity = new Vector2(rig.velocity.x, jump_force);
            player_animator.play_animation("player_jumping");
        }

        if (Input.GetKeyDown(KeyCode.Space) & !On_ground & segundo_pulo_up)
        {
            rig.velocity = new Vector2(rig.velocity.x, jump_force);
            segundo_pulo_up = false;
            player_animator.play_animation("player_jumping");
        }

        if (!attacking)
        {
            if(On_ground)
            {
                if (rig.velocity.x != 0)
                {
                    player_animator.play_animation("player_running");
                }
                else
                {
                    player_animator.play_animation("player_idle");
                }
            } else if (rig.velocity.y < 0)
                {
                player_animator.play_animation("player_falling");
            }
        }

        _direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        player_animator.check_direction();
    }

    void check_attack()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            player_animator.play_animation("player_attacking");
            attacking = true;
            //player_knockback();
            //ui_manager.add_life();
            Invoke("stop_attack",0.4f);
        }
    }

    void check_pause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameManager.Instance.PauseGame();
        }
    }

    public void stop_attack()
    {
        attacking = false;
        player_animator.play_animation("player_idle");
    }
    
    public void attack(Enemy inimigo){
        inimigo.perdeVida(dano);
    }
    public void attack(cannon cannon)
    {
        cannon.perdeVida(dano);
    }


    public void perdeVida(int n, Vector2 direction_konckback)
    {
        vida -= n;
        ui_manager.lose_life(n);
        ui_manager.add_swords(n);

        if (vida <= 0) {
            killPlayer();
        } else {
            dano += n;
            player_animator.play_animation("player_hit");
            player_knockback(direction_konckback);
        }   
    }

    private void killPlayer()
    {
        ui_manager.activate_death_text();
        Invoke("restart", 0.5f);
        //player_animator.play_animation("player_dead");
    }

    public void player_knockback(Vector2 direction_konckback)
    {
        Debug.Log(direction_konckback);
        rig.AddForce(direction_konckback * knockback, ForceMode2D.Impulse); 
    }

    public void add_coin()
    {
        coins++;
        ui_manager.add_coins(coins);
    }
}
