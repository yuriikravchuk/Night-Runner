using UnityEngine;

public class StreetBuilder : MonoBehaviour, IStreetProvider
{
    [SerializeField] private Street _prefab;

    public Street Get(Transform parent, Vector3 position)
    {
        return Instantiate(_prefab, position, Quaternion.identity, parent);
    }
}

public interface IStreetProvider
{
    public Street Get(Transform parent, Vector3 position);
}