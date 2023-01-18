using UnityEngine;

public class CollectableObject : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private EventID _eventID = EventID.None;

    [SerializeField] private int _pointsToGet;
    [SerializeField] private float _forceAmount;

    private void OnEnable()
    {
        _rigidbody.AddForce(Vector3.down * _forceAmount, ForceMode.Impulse);
    }

    public int GetPoints()
    {
        return _pointsToGet;
    }

    public EventID GetEventID()
    {
        return _eventID;
    }
}
