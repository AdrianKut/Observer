using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private ScoreManager _scoreManager;
    private Effect _playerEffect;

    private void Awake()
    {
        _playerEffect = GetComponent<Effect>();

        if (_playerEffect == null)
        {
            Debug.LogWarning("Effect not found!");
            return;
        }
    }

    private void Start()
    {
        _scoreManager = ScoreManager.Instance;

        if (_scoreManager == null)
        {
            Debug.LogWarning("Score manager not found!");
            return;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        CollectableObject collectableObject = collision.gameObject.GetComponent<CollectableObject>();

        CollisionWithCollectableObject(collision, collectableObject);
    }

    private void CollisionWithCollectableObject(Collision collision, CollectableObject collectableObject)
    {
        if (collectableObject != null)
        {
            Color color = collectableObject.GetComponent<Renderer>().material.color;

            _playerEffect.InstantiateColoredEffect(color);

            int points = collectableObject.GetPoints();
            _scoreManager.Score += points;
            _scoreManager.Notify(EventID.OnScore);

            var eventID = collectableObject.GetEventID();
            _scoreManager.Notify(eventID);

            Destroy(collision.gameObject);
        }
    }
}
