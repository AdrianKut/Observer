using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableObjectSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> _prefabs;
    [SerializeField] private float _delayBetweenSpawnNewObject;

    [SerializeField] private Vector3 _spawnPosition;

    private GameManager _gameManager;

    private void Start()
    {
        _gameManager = GameManager.Instance;

        if (_gameManager == null)
        {
            Debug.LogWarning("Game manager not found!");
            return;
        }

        StartCoroutine("Spawn");
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            if (_gameManager.GetGameState() == GameState.Playing)
            {
                int randomIndex = Random.Range(0, _prefabs.Count);
                Vector3 randomPosition = new Vector3(Random.Range(-_spawnPosition.x, _spawnPosition.x), _spawnPosition.y);

                Instantiate(_prefabs[randomIndex], randomPosition, Quaternion.identity);
                yield return new WaitForSeconds(_delayBetweenSpawnNewObject);
            }

            yield return null;
        }
    }

    #region Gizmos
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector3(-_spawnPosition.x, _spawnPosition.y), new Vector3(_spawnPosition.x, _spawnPosition.y));
    }
    #endregion
}
