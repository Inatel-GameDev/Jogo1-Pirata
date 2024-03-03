using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannon : Trap
{

    public Animator animator;
    public Animator animator_smoke;
    public Ball ball;    
    private string currentAnimation;
    public int vida;
    private float tempo;
    private bool destroyed = false;

    [SerializeField] float tempo_limite;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        play_animation("smoke_idle", animator_smoke);
        tempo = tempo_limite;
    }

    // Update is called once per frame
    void Update()
    {
        if(tempo <= 0 && !destroyed)
        {   
            //Instantiate(ball, transform);
            play_animation("cannon_fire", animator);
            tempo = tempo_limite;
        } else
        {
            tempo -= Time.deltaTime;
        }
    }

    public void create_ball()
    {
        Instantiate(ball, transform);
        play_animation("smoke", animator_smoke);
    }

    public void stopAttacking()
    {
        play_animation("cannon", animator);
        play_animation("smoke_idle", animator_smoke);
    }

    public void play_animation(string newAnimation, Animator anim)
    {
        if (currentAnimation == newAnimation) return;
        anim.Play(newAnimation);
        currentAnimation = newAnimation;

    }

    public new void perdeVida(int n)
    {
        vida -= n;
        if (vida <= 0)
        {
            destroyed = true;
            play_animation("cannon_dead", animator);
            Invoke("destroy", 0.3f);
        }
        else
        {
            play_animation("cannon_hit", animator);
            Invoke("stopAttacking", 0.5f);
        }
    }

    private void destroy()
    {

        Destroy(gameObject);
    }

}
