using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UI_manager : MonoBehaviour
{
    public Canvas canvas;
    [SerializeField] private int life_bottles;
    private int max_life_bottles = 8;
    private int sword_total = 0;
    public GridLayoutGroup grid;
    public GameObject[] bottles;
    public TMP_Text textMeshPro_coin;
    public TMP_Text textMeshPro_swords;
    public TMP_Text textMeshPro_death;


    private void Start()
    {  
        for (int i = life_bottles; i < max_life_bottles; i++)
        {
            bottles[i].gameObject.SetActive(false);
        }
    }

    public void add_life()
    {
        life_bottles++;
        bottles[life_bottles].gameObject.SetActive(true);
    }
    public void add_coins(int n)
    {
        textMeshPro_coin.text = n.ToString();
    }
    public void add_swords(int n)
    {
        sword_total += n;
        textMeshPro_swords.text = "x" + sword_total.ToString();
    }

    public void lose_life(int n)
    {
        int aux = life_bottles - n;
        for (int i = life_bottles; i > aux; i--)
        {
            if (i > -1)
            {
                bottles[life_bottles].gameObject.SetActive(false);
                life_bottles--;
            }
            else
            {
                break;
            }
        }
    }

    public void activate_death_text()
    {
        textMeshPro_death.gameObject.SetActive(true);
    }

    
}
