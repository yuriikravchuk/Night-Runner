using UnityEngine;

public class Street : MonoBehaviour
{
    [SerializeField] private Transform _endPoint;

    public Vector3 EndPosition => _endPoint.position;

    public float StreetLength { get; private set; }

    private void Awake()
    {
        StreetLength = _endPoint.localPosition.z;
    }
}
