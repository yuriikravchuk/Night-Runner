using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerInput : MonoBehaviour, IDragHandler, IPointerDownHandler
{
    [SerializeField] private float _minSqrDistance;

    public event Action LeftSwipe;
    public event Action RightSwipe;
    public event Action UpSwipe;
    public event Action DownSwipe;

    private Vector2 _startPosition;
    private Vector2 _swipeDirection;

    private bool _swipped;

    public void OnPointerDown(PointerEventData eventData)
    {
        _startPosition = eventData.position;
        _swipped = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (_swipped) return;

        _swipeDirection = eventData.position - _startPosition;
        float distance = _swipeDirection.sqrMagnitude;

        if (distance < _minSqrDistance) return;

        _swipped = true;

        if (Mathf.Abs(_swipeDirection.x) > Mathf.Abs(_swipeDirection.y))
        {
            if (_swipeDirection.x > 0)
                RightSwipe?.Invoke();
            else
                LeftSwipe?.Invoke();
            return;
        }
        else
        {
            if (_swipeDirection.y > 0)
                UpSwipe?.Invoke();
            else
                DownSwipe?.Invoke();
            return;
        }
        
    }
}
