using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    private Rigidbody _rigidbody;

    [field: SerializeField] public float Speed { get; private set; }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Init(Vector3 direction)
    {
        _rigidbody.transform.up = direction;
        _rigidbody.velocity = direction * Speed;
    }
}