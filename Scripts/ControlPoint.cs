using UnityEngine;

public class ControlPoint : MonoBehaviour
{
    [SerializeField] private Transform _placePoint;

    private Transform[] _places;

    public int PointCount => _places.Length;

    private void Awake()
    {
        _places = new Transform[_placePoint.childCount];

        for (int i = 0; i < _places.Length; i++)
        {
            _places[i] = _placePoint.GetChild(i);
        }
    }
    
    public Transform GetCurrentPoint(int index)
    {
        return _places[index];
    }
}