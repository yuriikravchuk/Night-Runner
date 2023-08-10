using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starter : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private MapMover _mapMover;
    [SerializeField] private StreetBuilder _streetBuilder;

    private void Awake()
    {
        _playerInput.UpSwipe += () => Debug.Log("Up");
        _playerInput.DownSwipe += () => Debug.Log("Down");
        _playerInput.LeftSwipe += () => Debug.Log("Left");
        _playerInput.RightSwipe += () => Debug.Log("Right");

        _mapMover.Init(_streetBuilder);
    }
}
