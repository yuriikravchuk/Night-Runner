using UnityEngine;

public class MapMover : MonoBehaviour
{
    [Range(5f, 40f)]
    [SerializeField] private float _speed = 10f;
    
    private IStreetProvider _streetProvider;
    private Street _currentStreet;
    private Street _nextStreet;

    public void Init(IStreetProvider streetProvider)
    {
        _streetProvider = streetProvider;
        _currentStreet = _streetProvider.Get(transform, transform.position);
        _nextStreet = _streetProvider.Get(transform, _currentStreet.EndPosition);
    }

    private void Update()
    {
        _currentStreet.transform.position -= _speed * Time.deltaTime * Vector3.forward;
        _nextStreet.transform.position = _currentStreet.EndPosition;

        if (_nextStreet.transform.position.z < -5)
        {
            Destroy(_currentStreet.gameObject);
            _currentStreet = _nextStreet;
            _nextStreet = _streetProvider.Get(transform, _currentStreet.EndPosition);
        }
    }
}
