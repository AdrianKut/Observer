using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInput : MonoBehaviour
{
    private GameManager _gameManager;

    private void Start()
    {
        _gameManager = GameManager.Instance;

        if (_gameManager == null)
        {
            Debug.LogWarning("Game manager not found!");
            return;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && _gameManager.GetGameState() == GameState.GameOver)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
