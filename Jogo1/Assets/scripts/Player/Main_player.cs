using UnityEngine;

public class Main_player : MonoBehaviour
{
    // stats 
    [SerializeField] private int speed;
    [SerializeField] private int vida;
    [SerializeField] private int life_max;
    [SerializeField] private int dano;
    [SerializeField] private int coins;

    // pulo 
    public int jump_force;
    public bool segundo_pulo_up;

    public float knockback;
    private bool _on_ground;
    private bool attacking;
    
    //ui
    public UI_manager ui_manager;

    public GameManager game_manager;


    // animações 
    public Player_animation player_animator;
    
    // movimento 
    public Vector2 _direction;
    public Rigidbody2D rig;
    public Main_player player;
    
    public bool On_ground { get => _on_ground; set => _on_ground = value; }
    public bool Life_max { get => _on_ground; set => _on_ground = value; }


    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Main_player>();
        rig = GetComponent<Rigidbody2D>();
        player_animator = GetComponent<Player_animation>();
        //ui_manager = GetComponent<UI_manager>();
        segundo_pulo_up = true;
        //ui_manager.updateLife(vida);
    }

    // Update is called once per frame
    void Update()
    {
        check_move();
        check_attack();
        check_fall();
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

    public void stop_attack()
    {
        attacking = false;
        player_animator.play_animation("player_idle");
    }
    
    public void attack(Inimigo inimigo){
        inimigo.perdeVida(dano);
    }

    public void perdeVida(int n, Vector2 direction_konckback)
    {
        Debug.Log("Perdeu vida");
        vida -= n;
        ui_manager.lose_life();
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

    private void restart()
    {
        game_manager.restartGame();
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
