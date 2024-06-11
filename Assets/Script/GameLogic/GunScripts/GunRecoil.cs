using UnityEngine;

public class GunRecoil : MonoBehaviour
{
    [Header("Rotation Recoil")]
    [SerializeField] private float _recoilRotationX;
    [SerializeField] private float _recoilRotationY;
    [SerializeField] private float _rotationRecoilZ;
    [SerializeField] private float _returnRotationSpeed;
    [SerializeField] private float _smoothRotation;
    private Vector3 targetRotation;
    private Vector3 currentRotation;

    [Header("Position Recoil")]
    [SerializeField] private float _recoilPositionX;
    [SerializeField] private float _recoilPositionY;
    [SerializeField] private float _recoilPositionZ;
    [SerializeField] private float _returnPositionSpeed;
    [SerializeField] private float _smoothPosition;
    private Vector3 startPosition;
    private Vector3 targetPosition;
    private Vector3 currentPosition;

    [Header("Aim Position Recoil")]
    [SerializeField] private float returnAimPosSpeed;
    [SerializeField] private float smothAimPosSpeed;
    [SerializeField] private Vector3 aimPosition;

    private bool isShooting;
    private void Start()
    {
        startPosition = transform.localPosition;
        targetPosition = startPosition;
        currentPosition = startPosition;
    }
    private void OnEnable()
    {
        GunShoot.onShooted += ShootRecol;
    }

    private void OnDisable()
    {
        GunShoot.onShooted -= ShootRecol;
    }
    private void Update()
    {
        BackToStartPos();
    }
    public void ShootRecol()
    {
        targetRotation += new Vector3(-_recoilRotationX, Random.Range(-_recoilRotationY, _recoilRotationY), Random.Range(-_recoilRotationY, _recoilRotationY));
        targetPosition += new Vector3(Random.Range(-_recoilPositionX, _recoilPositionX), _recoilPositionY, -_recoilPositionZ);
    }
    private void BackToStartPos()
    {
        targetRotation = Vector3.Lerp(targetRotation, Vector3.zero, _returnRotationSpeed * Time.deltaTime);
        currentRotation = Vector3.Slerp(currentRotation, targetRotation, _smoothRotation * Time.deltaTime);
        transform.localRotation = Quaternion.Euler(currentRotation);
        targetPosition = Vector3.Lerp(targetPosition, startPosition, _returnPositionSpeed * Time.deltaTime);
        currentPosition = Vector3.Slerp(currentPosition, targetPosition, _smoothPosition * Time.deltaTime);
        transform.localPosition = currentPosition;
    }

}
