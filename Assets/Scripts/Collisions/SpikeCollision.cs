using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeCollision : MonoBehaviour
{

    private static GameObject _gameOverScreenContainer;

    private void Awake()
    {
        _gameOverScreenContainer = GameObject.Find("GameOverScreenContainer");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Circle"))
        {
            _gameOverScreenContainer.GetComponent<GameOver>().Defeat();
        }
    }
}
