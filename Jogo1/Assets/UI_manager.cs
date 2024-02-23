using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UI_manager : MonoBehaviour
{
    public Canvas canvas;
    private int life_bottles = 4;
    public GridLayoutGroup grid;
    public GameObject[] bottles;
    public Sprite bottle;
    
   

    /*
    private int base_x = 30;
    private int offset_x = 60;
    private int base_y = 555;*/

    private void Start()
    {
        canvas = GetComponent<Canvas>();
        for (int i = 0;i >= life_bottles; i++){
            bottles[i] = new GameObject("bottle_life");
            Image image = bottles[i].AddComponent<Image>();
            image.sprite = bottle;
            bottles[i].transform.SetParent(grid.transform);
        }
    }

    public void updateLife(int n)
    {
        life_bottles = n;
        Destroy(bottles[0]);

    }
}
