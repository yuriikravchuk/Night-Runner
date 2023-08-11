using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private List<Transform> _positionPoints;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private float _jumpForce = 10.0f;

    private int _currentPositionIndex = 1;
    private float _distanceToFloor;

    private void Awake()
    {
        _distanceToFloor = transform.position.y;
    }

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
        if(IsGrounded())
            _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, _jumpForce, _rigidbody.velocity.z);
    }

    public void OnDownSwipe()
    {
        if (IsGrounded() == false)
            _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, - _jumpForce, _rigidbody.velocity.z);
    }

    private void Move(int pointIndex)
    {
        _currentPositionIndex = pointIndex;
        Vector3 newPosition = new Vector3(_positionPoints[_currentPositionIndex].position.x, transform.position.y, transform.position.z);
        _rigidbody.MovePosition(newPosition);
    }

    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, _distanceToFloor + 0.01f);
    }
}
