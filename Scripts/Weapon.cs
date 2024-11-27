using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Bullet _prefabBullets;
    [SerializeField] private Transform _shootingTarget;
    [SerializeField] private float _timeFastShooting;
    [SerializeField] private float _speedBullets;

    private void Start() 
    {
        StartCoroutine(Shooting());
    }

    private IEnumerator Shooting()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(_timeFastShooting);

        while (enabled)
        {
            Vector3 direction = (_shootingTarget.position - transform.position).normalized;
            Bullet bullet = Instantiate(_prefabBullets, transform.position, Quaternion.identity);
            bullet.Init(direction);

            yield return waitForSeconds;
        }
    }
}