using UnityEngine;

public class BodyRotation : MonoBehaviour
{
    [SerializeField] private float _mouthSensetiveX;
    [SerializeField] private float _mouthSensetiveY;
    [SerializeField] private Transform _hand;
    private float _xRotation;
    private float _yRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void Rotate(Vector2 velocity)
    {
        float mouseX = velocity.x * Time.deltaTime * _mouthSensetiveX;
        float mouseY = velocity.y * Time.deltaTime * _mouthSensetiveY;
        _xRotation -= mouseY;
        _yRotation += mouseX;

        _xRotation = Mathf.Clamp(_xRotation, -75f, 75f);
        transform.rotation = Quaternion.Euler(0, _yRotation, 0);
        _hand.rotation = Quaternion.Euler (_xRotation, _yRotation, 0);

    }
}
