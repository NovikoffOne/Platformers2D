using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerEnity : MonoBehaviour
{
    [SerializeField] private int _hp = 3;
    [SerializeField] private float _forcePush = 3f;

    private Rigidbody2D _rigidbody2D;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void GetDamage()
    {
        _hp--;

        PushFromDamage();

        Debug.Log("HP : " + _hp);

        if (_hp < 1)
        {
            Die();
        }
    }

    public void Die()
    {
        var currentScene = SceneManager.GetActiveScene().name;

        SceneManager.LoadScene(currentScene);
    }

    public void PushFromDamage()
    {
        _rigidbody2D.AddForce(transform.up * _forcePush, ForceMode2D.Impulse);
    }
}
