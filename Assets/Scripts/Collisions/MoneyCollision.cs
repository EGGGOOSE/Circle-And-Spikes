using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Circle"))
        {
            MoneyHandler.AddMoney();
            Destroy(gameObject);
        }
    }
}
