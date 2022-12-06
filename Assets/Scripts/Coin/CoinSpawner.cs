using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _coinPrefabs;
    [SerializeField] private float _direction = 2f;
    [SerializeField] private int _countCoinOnPlatform = 5;

    private Transform[] _positionSpawn;
    private Vector3 _position;

    private void Start()
    {
        _positionSpawn = GetComponentsInChildren<Transform>();

        foreach(var child in _positionSpawn)
        {
            Spawn(child);
        }
    }

    private void Spawn(Transform transformChild)
    {
        _position = new Vector3(transformChild.transform.position.x, transformChild.transform.position.y, transformChild.transform.position.z);

        for (int i = 0; i < _countCoinOnPlatform; i++)
        {
            Instantiate(_coinPrefabs, _position, Quaternion.identity);

            _position = new Vector3(_position.x + _direction, _position.y, _position.z);
        }
    }
}