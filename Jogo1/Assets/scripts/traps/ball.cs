using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Rigidbody2D body;
    [SerializeField] float speed;
    [SerializeField] int direction;
    [SerializeField] int dano;
    public Main_player player;

    private void Start()
    {
        player = FindFirstObjectByType<Main_player>();
    }

    void FixedUpdate()
    {
        body.velocity = new Vector2(direction * speed, body.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Player")
        {
           player.perdeVida(dano, new Vector2(0,0));
        }

        Destroy(gameObject);
    }
}
