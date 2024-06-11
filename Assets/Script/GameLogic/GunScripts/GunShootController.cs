using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class GunShootController : MonoBehaviour
{
    [Header("Camera")]
    [SerializeField] private Camera _camera;
    [SerializeField] private float _standartFov;
    [SerializeField] private float _aimFov;
    [SerializeField] private float _speedFov;

    [Header("HandAnim")]
    [SerializeField] private GameObject _leftHand;
    [SerializeField] private GameObject _rigthHand;
    [SerializeField] private Transform _rigthHandGrip;
    [SerializeField] private Transform _leftHandGrip;
    [SerializeField] private Transform _magazineGrip;
    [Header("Characteristics")]
    [SerializeField] private int _ammo;
    [SerializeField] private int _currentAmmo;
    [SerializeField] private float _timeToShoot;
    private float _shootTime = 0;
    [Header("Bullet")]
    [SerializeField] private GameObject BulletPrefab;
    [SerializeField] private Transform _BulletStartPos;

    [Header("Audio")]
    private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioClip;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _currentAmmo = _ammo;
    }

    public void Shoot()
    {
        if (Time.time < (_timeToShoot + _shootTime)) return;

        if (_currentAmmo <= 0) return;
        _currentAmmo -= 1;
        _shootTime = Time.time;
        Instantiate(BulletPrefab, _BulletStartPos.position, transform.rotation);
        _audioSource.PlayOneShot(_audioClip);
        //_cameraAnimator.Play("CameraShake");
    }

    public void Reload()
    {
        _currentAmmo = _ammo;
    }
}
