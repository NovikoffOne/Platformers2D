using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathArea : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerEnity player = collision.gameObject.GetComponent<PlayerEnity>();

        if (player)
        {
            player.Die();
        }
    }
}
