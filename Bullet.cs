using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Transform _placespoints;
    [SerializeField] private float _speed;

    private Transform[] _places;
    private int _sizeArray;

    private void Start() 
    {
        _places = new Transform[_placespoints.childCount];

        for (int i = 0; i < _placespoints.childCount; i++) 
        {
            if (_placespoints.GetChild(i).GetComponent<Transform>())
            {
                _places[i] = _placespoints.GetChild(i).GetComponent<Transform>();
            }
            else 
            {
                _placespoints.GetChild(i).AddComponent<Transform>();
                _places[i] = _placespoints.GetChild(i).GetComponent<Transform>();
            }
        }        
    }

    private void Update()
    {
        Transform place = _places[_sizeArray];
        transform.position = Vector3.MoveTowards(transform.position, place.position, _speed * Time.deltaTime);

        if (transform.position == place.position)  
            GetNextPlace();
    }

    private Vector3 GetNextPlace()
    {
        _sizeArray++;

        if (_sizeArray == _places.Length)
            _sizeArray = 0;

        Vector3 pointVector = _places[_sizeArray].transform.position;
        transform.forward = pointVector - transform.position;

        return pointVector;
    }
}