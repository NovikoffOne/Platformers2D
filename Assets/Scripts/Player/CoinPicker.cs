using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPicker : MonoBehaviour
{
    private int _point;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coin")
        {   
            GetPoint();

            Destroy(collision.gameObject);
        }
    }

    public void GetPoint()
    {
        _point++;

        Debug.Log("Point : " + _point);
    }
}
