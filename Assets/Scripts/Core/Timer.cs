using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timer;
    [SerializeField] private float _timeleft;

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
        Countdown();
    }

    private void Countdown()
    {
        _timeleft -= Time.deltaTime;

        if (_timeleft <= 0)
        {
            _gameManager.SetGameState(GameState.GameOver);
        }

        UpdateText();
    }

    private void UpdateText()
    {
        _timer.text = $"{_timeleft:F0}";
    }
}
