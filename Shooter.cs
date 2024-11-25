using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject _prefabBullets;
    [SerializeField] private Transform _shootingTarget;
    [SerializeField] private float _timeFastShooting;
    [SerializeField] private float _speedBullets;

    private void Start() 
    {
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        while (enabled)
        {
            Vector3 direction = (_shootingTarget.position - transform.position).normalized;
            GameObject bullet = Instantiate(_prefabBullets, transform.position, Quaternion.identity);

            bullet.GetComponent<Rigidbody>().transform.up = direction;
            bullet.GetComponent<Rigidbody>().velocity = direction * _speedBullets;

            yield return new WaitForSeconds(_timeFastShooting);
        }
    }
}