using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private Transform _placespoints;
    [SerializeField] private float _speed;

    private Rigidbody _rigidbody;
    private Transform[] _places;
    private int _sizeArray;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Start() 
    {
        _places = _placespoints.GetComponentsInChildren<Transform>();        
    }

    private void Update()
    {
        Transform place = _places[_sizeArray];
        transform.position = Vector3.MoveTowards(transform.position, place.position, _speed * Time.deltaTime);

        if (transform.position == place.position)  
            GetNextPlace();
    }

    public void Init(Vector3 direction)
    {
        _rigidbody.transform.up = direction;
        _rigidbody.velocity = direction * _speed;
    }

    private Vector3 GetNextPlace()
    {
        _sizeArray = (_sizeArray + 1) % _places.Length;

        Vector3 pointVector = _places[_sizeArray].position;
        transform.forward = pointVector - transform.position;

        return pointVector;
    }
}