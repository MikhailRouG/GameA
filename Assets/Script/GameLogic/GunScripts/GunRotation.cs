using UnityEngine;

public class GunRotation : MonoBehaviour
{
    [SerializeField] private float _mouseSensetiveY;
    [SerializeField] private float _maxValue;
    [SerializeField] private float _minValue;
    [SerializeField] private float _currentAngel;

    private void Start()
    {
        _maxValue = 360 - _maxValue;
    }
    public void Rotate(float velocity)
    {
        float rotation = -velocity * _mouseSensetiveY;
        _currentAngel = transform.eulerAngles.x;
        _currentAngel += rotation;
        if (rotation < 0f)
        {
            if (_currentAngel < _maxValue && _currentAngel > 90 && _currentAngel != 0) _currentAngel = _maxValue;
        }
        else if (rotation > 0f)
        {
            if (_currentAngel > _minValue && _currentAngel < 270 && _currentAngel != 0) _currentAngel = _minValue;
        }
        transform.eulerAngles = new Vector3(_currentAngel, transform.eulerAngles.y, transform.eulerAngles.z) ;
    }
}
