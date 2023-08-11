using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private List<Transform> _positionPoints;

    private int _currentPositionIndex = 1;
    private const int _positionsCount = 3;

    public void OnLeftSwipe()
    {
        if (_currentPositionIndex <= 0)
            return;

        Move(_currentPositionIndex - 1);
    }

    public void OnRightSwipe()
    {
        if (_currentPositionIndex >= 2)
            return;

        Move(_currentPositionIndex + 1);
    }

    public void OnUpSwipe()
    {

    }

    public void OnDownSwipe()
    {

    }

    private void Move(int pointIndex)
    {
        _currentPositionIndex = pointIndex;
        Vector3 newPosition = new Vector3(_positionPoints[_currentPositionIndex].position.x, transform.position.y, transform.position.z);
        _rigidbody.MovePosition(newPosition);
    }
}
