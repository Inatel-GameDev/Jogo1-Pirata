using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Button _newGame;

    void Start()
    {
        _newGame.onClick.AddListener(StartNewGame);    
    }


    private void StartNewGame()
    {
        GameManager.Instance.LoadNewGame();
    }
}
