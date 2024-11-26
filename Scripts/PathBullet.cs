using UnityEngine;

public class PathBullet : MonoBehaviour
{
    [SerializeField] private Transform _placePoint;

    private Transform[] _places;

    private void Awake()
    {
        _places = new Transform[_placePoint.childCount];

        for (int i = 0; i < _places.Length; i++)
        {
            _places[i] = _placePoint.GetChild(i);
        }
    }
    
    public int PointCount => _places.Length;

    public Transform GetCurrentPoint(int index)
    {
        return _places[index];
    }
}