using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;
    public GameState State;    
    public Main_player player;
    public Canvas menu_pause;

    private void Awake()
    {
        Instance = this;
    }


    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadScene(Scene scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }

    public void PauseGame()
    {
        State = GameState.Pause;
        player.IsPaused = true;
        Time.timeScale = 0f;
        menu_pause.gameObject.SetActive(true);
    }

    public void ResumeGame()
    {
        State = GameState.Action;
        player.IsPaused = false;
        Time.timeScale = 1f;
        menu_pause.gameObject.SetActive(false);
    }


    public enum Scene
    {
        Menu,
        Level_1,
        Level_2,
        Level_3,
        End,
    }


    public enum GameState
    {
        Pause,
        Action,
        Shop,
        Loading
    }

}