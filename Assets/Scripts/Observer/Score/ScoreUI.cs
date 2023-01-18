using TMPro;
using UnityEngine;

[RequireComponent(typeof(ScoreManager))]
public class ScoreUI : MonoBehaviour, IObserver
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _redText;
    [SerializeField] private TextMeshProUGUI _greenText;
    [SerializeField] private TextMeshProUGUI _blueText;

    private ScoreManager _scoreManager;

    private void Start()
    {
        _scoreManager = GetComponent<ScoreManager>();
        if (_scoreManager == null)
        {
            Debug.LogWarning("Score manager not found!");
            return;
        }

        _scoreManager.Register(this);
    }

    private void OnUpdateScore()
    {
        _scoreText.text = $"SCORE: {_scoreManager.Score}";
    }

    private void OnUpdateRed()
    {
        _redText.text = $"RED: {++_scoreManager.RedAmount}";
    }

    private void OnUpdateGreen()
    {
        _greenText.text = $"GREEN: {++_scoreManager.GreenAmount}";
    }

    private void OnUpdateBlue()
    {
        _blueText.text = $"BLUE: {++_scoreManager.BlueAmount}";
    }

    public void OnNotify(EventID eventID)
    {
        switch (eventID)
        {
            case EventID.OnScore:
                OnUpdateScore();
                break;
            case EventID.OnCollectRedObject:
                OnUpdateRed();
                break;
            case EventID.OnCollectGreenObject:
                OnUpdateGreen();
                break;
            case EventID.OnCollectBlueObject:
                OnUpdateBlue();
                break;
            default:
                Debug.LogWarning("Event not found!");
                break;
        }
    }
}
