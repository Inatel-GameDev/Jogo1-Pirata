using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu_Pause : MonoBehaviour
{
    [SerializeField] Button _resumePlay;

    void Start()
    {
        _resumePlay.onClick.AddListener(ResumeGame);
    }


    private void ResumeGame()
    {
        GameManager.Instance.ResumeGame();
    }
}
