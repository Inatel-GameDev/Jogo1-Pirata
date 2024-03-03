using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannon : MonoBehaviour
{

    public Ball ball;
    private float tempo;
    [SerializeField] float tempo_limite;

    // Start is called before the first frame update
    void Start()
    {
        tempo = tempo_limite;
    }

    // Update is called once per frame
    void Update()
    {
        if(tempo <= 0)
        {   
            Instantiate(ball, transform);
            tempo = tempo_limite;
        } else
        {
            tempo -= Time.deltaTime;
        }
    }


}
