using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnControllerForEnemy : MonoBehaviour
{
    [SerializeField] private GameObject _spawnObject;
    [SerializeField] private GameObject _currentSpawnedObject;

    private void Update()
    {
        if(_currentSpawnedObject == null)
        {
            _currentSpawnedObject = Instantiate(_spawnObject);
        }
    }

}
