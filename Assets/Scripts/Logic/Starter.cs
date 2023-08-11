using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starter : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private MapMover _mapMover;
    [SerializeField] private StreetBuilder _streetBuilder;
    [SerializeField] private Player _player;

    private void Awake()
    {
        _playerInput.UpSwipe += () => Debug.Log("Up");
        _playerInput.DownSwipe += () => Debug.Log("Down");
        _playerInput.LeftSwipe += _player.OnLeftSwipe;
        _playerInput.RightSwipe += _player.OnRightSwipe;

        _mapMover.Init(_streetBuilder);
    }
}
