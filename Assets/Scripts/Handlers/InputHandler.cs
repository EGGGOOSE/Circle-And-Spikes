using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{

    [SerializeField] private GameObject _circle;
    private CircleMoveHandler _circleMoveHandler;
    
    private void Start()
    {
        _circleMoveHandler = _circle.GetComponent<CircleMoveHandler>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !GameOver.IsGameOver)
        {
            _circleMoveHandler.HandleClick(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }
    }
}
