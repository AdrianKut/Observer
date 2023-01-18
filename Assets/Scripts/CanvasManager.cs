using UnityEngine;

public class CanvasManager : MonoBehaviour, IObserver
{
    [SerializeField] private GameObject _mainCanvas;
    [SerializeField] private GameObject _gameOverCanvas;

    private GameManager _gameManager;

    private void Start()
    {
        _gameManager = GameManager.Instance;

        if (_gameManager == null)
        {
            Debug.LogWarning("Game manager not found!");
            return;
        }

        _gameManager.Register(this);
    }

    public void OnNotify(EventID eventID)
    {
        if (eventID == EventID.OnGameOver)
        {
            _gameOverCanvas.SetActive(true);
        }

        if (eventID == EventID.OnPlaying)
        {
            _gameOverCanvas.SetActive(false);
        }
    }
}
