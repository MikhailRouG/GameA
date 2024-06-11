using UnityEngine;
using System;

[RequireComponent(typeof(GunRecoil))]
public class GunShoot : MonoBehaviour
{
    [SerializeField] private Transform _bulletStartPos;
    [SerializeField] private float _timeToShoot;
    [SerializeField] private int _damage;
    private float _currentShootTime = 0;
    public static Action onShooted;

    private void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(_bulletStartPos.position, transform.forward, out hit))
        {
            Debug.DrawRay(_bulletStartPos.position, transform.forward * hit.distance, Color.red);
        }
    }
    public void Shoot()
    {
        if ((Time.time - _currentShootTime) < _timeToShoot) return;
        _currentShootTime = Time.time;
        onShooted?.Invoke();
        RaycastHit hit;
        if (Physics.Raycast(_bulletStartPos.position, transform.forward, out hit))
        {
            Debug.DrawRay(_bulletStartPos.position, transform.forward * hit.distance, Color.red);
            if (hit.collider.gameObject.TryGetComponent<Health>(out Health health))
            {
                health.TakeDamage(_damage);
            }
        }
    }
}
