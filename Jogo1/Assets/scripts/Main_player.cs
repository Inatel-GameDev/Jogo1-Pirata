using UnityEngine;

public class Main_player : MonoBehaviour
{
    // stats 
    [SerializeField] private int speed;
    [SerializeField] private int vida;
    [SerializeField] private int dano;

    // pulo 
    public int jump_force;
    public bool segundo_pulo_up;

    public Vector2Int knockback;
    private bool _on_ground;
    private bool attacking;
    
    //ui
    public UI_manager ui_manager;


    // animações 
    public Player_animation player_animator;
    
    // movimento 
    public Vector2 _direction;
    public Rigidbody2D rig;
    public Main_player player;
    public bool On_ground { get => _on_ground; set => _on_ground = value; }


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
            player_knockback();
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

    public void perdeVida(int n)
    {
        vida -= n;
        dano += n;
        player_animator.play_animation("player_hit");
        ui_manager.updateLife(vida);
        player_knockback();
    }

    public void player_knockback()
    {
        rig.AddForce(knockback, ForceMode2D.Impulse); //if you don't want to take into consideration enemy's mass then use ForceMode.VelocityChange
    }
}
