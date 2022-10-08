using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static int MoneyCount;
    [SerializeField] private int _moneyCount, _spikeCount;

    [SerializeField] private GameObject _moneyPrefab;
    [SerializeField] private GameObject _spikePrefab;
    
    private void Start()
    {
        MoneyCount = _moneyCount;
        SpawnObjects(_moneyPrefab, _moneyCount);
        SpawnObjects(_spikePrefab, _spikeCount);
    }
    
    private void SpawnObjects(GameObject gameObject, int count)
    {
        for (int i = 0; i < count; i++)
        {
            Instantiate(gameObject, getRandomPosition(), Quaternion.identity);
        }
    }

    private Vector2 getRandomPosition()
    {
        float x = Random.Range(0, Screen.width);
        float y = Random.Range(0, Screen.height);
        return Camera.main.ScreenToWorldPoint(new Vector3(x, y, 10));
    }
}
