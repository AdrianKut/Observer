using UnityEngine;

public enum GameState
{
    Playing,
    GameOver
}

public class GameManager : Subject<GameManager>
{
    [SerializeField] private GameState _gameState;

    private void Start()
    {
        SetGameState(GameState.Playing);
    }

    public GameState GetGameState()
    {
        return _gameState;
    }

    public void SetGameState(GameState gameState)
    {
        _gameState = gameState;

        switch (_gameState)
        {
            case GameState.Playing:
                OnPlaying();
                break;
            case GameState.GameOver:
                OnGameOver();
                break;
            default:
                Debug.LogWarning("GameState not found!");
                break;
        }
    }

    private void OnPlaying()
    {
        Time.timeScale = 1f;
        Notify(EventID.OnPlaying);
    }

    private void OnGameOver()
    {
        Time.timeScale = 0f;
        Notify(EventID.OnGameOver);
    }
}
