using UnityEngine;

[RequireComponent(typeof(Bullet))]
public class ControlPoint : MonoBehaviour
{
    [SerializeField] private Transform _placePoint;

    private Transform[] _places;
    private Bullet _bullet;
    private int _currentPlace;

    private void Awake()
    {
        _places = new Transform[_placePoint.childCount];
        _bullet = GetComponent<Bullet>();

        for (int i = 0; i < _places.Length; i++)
        {
            _places[i] = _placePoint.GetChild(i);
        }
    }

    private void Update()
    {
        Transform place = _places[_currentPlace];
        _bullet.transform.position = Vector3.MoveTowards(_bullet.transform.position, place.position, _bullet.Speed * Time.deltaTime);

        if (_bullet.transform.position == place.position)
            ChooseNextPlace();
    }

    private void ChooseNextPlace()
    {
        _currentPlace = (_currentPlace + 1) % _places.Length;
        Vector3 pointVector = _places[_currentPlace].position;
        _bullet.transform.forward = pointVector - _bullet.transform.position;
    }
}