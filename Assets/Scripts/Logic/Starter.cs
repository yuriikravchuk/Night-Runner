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
        _playerInput.UpSwipe += _player.OnUpSwipe;
        _playerInput.DownSwipe += _player.OnDownSwipe;
        _playerInput.LeftSwipe += _player.OnLeftSwipe;
        _playerInput.RightSwipe += _player.OnRightSwipe;

        _mapMover.Init(_streetBuilder);
    }
}
