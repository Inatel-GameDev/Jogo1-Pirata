using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisor_chao_inimigo : MonoBehaviour
{
    public Inimigo inimigo;
    public int direction;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.CompareTag("chao"))
            {
                inimigo.changeDirection(direction);
            }
        }
    }
}
