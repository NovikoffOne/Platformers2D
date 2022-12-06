using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControlls : MonoBehaviour
{
    [SerializeField] private Transform _player;

    private Vector3 _position;

    private void Awake()
    {
        if (_player == null)
        {
            _player = FindObjectOfType<PlayerEnity>().transform;
        }
    }

    private void Update()
    {
        _position = _player.position;

        _position.z = -10;
        
        transform.position = Vector3.Lerp(transform.position, _position, Time.deltaTime);
    }
}
