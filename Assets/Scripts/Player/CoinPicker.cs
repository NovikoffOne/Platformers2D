using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPicker : MonoBehaviour
{
    private int _point;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Coin>())
        {   
            CollectPoint();

            Destroy(collision.gameObject);
        }
    }

    public void CollectPoint()
    {
        _point++;

        Debug.Log("Point : " + _point);
    }
}
