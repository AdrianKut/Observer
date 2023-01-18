using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _positionXLimit;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        float inputHorizontal = Input.GetAxis("Horizontal");

        Vector3 newPosition = new Vector3(inputHorizontal, 0) * _moveSpeed * Time.deltaTime;
        transform.Translate(newPosition);

        newPosition = transform.position;
        newPosition.x = Mathf.Clamp(newPosition.x, -_positionXLimit, _positionXLimit);

        transform.position = newPosition;
    }
}
