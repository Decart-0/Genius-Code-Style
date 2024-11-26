using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody _rigidbody;
    private PathBullet _pathBullet;
    private int _currentPlace;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _pathBullet = GetComponent<PathBullet>();
    }

    private void Update()
    {
        Transform place = _pathBullet.GetCurrentPoint(_currentPlace);
        transform.position = Vector3.MoveTowards(transform.position, place.position, _speed * Time.deltaTime);

        if (transform.position == place.position)  
            ChooseNextPlace();
    }

    public void Init(Vector3 direction)
    {
        _rigidbody.transform.up = direction;
        _rigidbody.velocity = direction * _speed;
    }

    private void ChooseNextPlace()
    {
        _currentPlace = (_currentPlace + 1) % _pathBullet.PointCount;
        Vector3 pointVector = _pathBullet.GetCurrentPoint(_currentPlace).position;
        transform.forward = pointVector - transform.position;
    }
}