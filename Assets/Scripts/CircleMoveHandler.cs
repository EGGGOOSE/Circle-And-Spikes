using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleMoveHandler : MonoBehaviour
{

    public float accel;

    private Rigidbody2D _rb;
    private LineRenderer _lineRenderer;

    private Vector2 _moveDirection;
    private bool isSlowDown = false;
    private Queue<Vector2> movePositions = new Queue<Vector2>();

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _lineRenderer = GetComponent<LineRenderer>();

        _lineRenderer.positionCount++;
        _lineRenderer.SetPosition(0, transform.position);
    }

    public void HandleClick(Vector2 position)
    {
        
        if (movePositions.Count != 0 && position == movePositions.Peek() || position == new Vector2(transform.position.x, transform.position.y))
            return;

        if (movePositions.Count == 0)
            _moveDirection = (position - new Vector2(transform.position.x, transform.position.y)).normalized;

        movePositions.Enqueue(position);

        _lineRenderer.positionCount++;
        _lineRenderer.SetPosition(_lineRenderer.positionCount - 1, position);
    } 

    private void FixedUpdate()
    {
        if (movePositions.Count != 0)
        {


            float distance = Vector2.Distance(transform.position, movePositions.Peek());
            if (isSlowDown)
            {
                _rb.velocity += _moveDirection * -accel;
                float futureDistance = Vector2.Distance(new Vector2(transform.position.x, transform.position.y) + _rb.velocity/50f, movePositions.Peek());

                if (futureDistance > distance)
                {
                    _rb.velocity = Vector2.zero;
                    isSlowDown = false;
                    _rb.MovePosition(movePositions.Dequeue());

                    if (movePositions.Count != 0)
                        _moveDirection = (movePositions.Peek() - new Vector2(transform.position.x, transform.position.y)).normalized;
                }
                return;
            }

            float velocityMagnitude = _rb.velocity.magnitude;

            //Если расстояние до точки больше, чем тормозной путь, то ускоряемся
            if (distance * 50f > (velocityMagnitude / 2f) * (velocityMagnitude / accel + 1))
            {
                _rb.velocity += _moveDirection * accel;
            }
            else
            {
                isSlowDown = true;
            }

        }
    }
}
