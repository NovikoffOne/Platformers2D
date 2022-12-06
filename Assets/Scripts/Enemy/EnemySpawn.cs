using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private Enemy enemy;

    private Transform[] _spawnsPositions;

    private void Awake()
    {
        _spawnsPositions = GetComponentsInChildren<Transform>();
    }

    void Start()
    {
        Spawn();
    }

    private void Spawn()
    {
        for (int i = 0; i < _spawnsPositions.Length; i++)
        {
            Instantiate(enemy, _spawnsPositions[i]);
        }
    }
}
