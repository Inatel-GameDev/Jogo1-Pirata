using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;
    public GameState State;

    public static event Action<GameState> OnGameStateChanged;


    public void restartGame()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }


    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        updateGameState(GameState.Action);
    }

    public void updateGameState(GameState newState)
    {
        State = newState;
        switch (newState)
        {
            case GameState.Pause:
                break;
            case GameState.Dead:
                break;
            case GameState.Shop:
                break;
            case GameState.Action:
                break;
            case GameState.Victory:
                break;
            default:
                break;
        }
        OnGameStateChanged?.Invoke(newState);
    }
}

    public enum GameState
    {
        Pause,
        Action,
        Shop,
        Dead,
        Victory
    }

