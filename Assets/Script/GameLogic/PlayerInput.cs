using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerInput : MonoBehaviour
{
    private ILeftClick _leftClick;
    private PlayerMovement _playerMovement;
    private BodyRotation _bodyRotation;
    private Vector3 _velocity;
    private Vector2 _mouseAxis;
    private bool _sprint;
    void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _bodyRotation = GetComponent<BodyRotation>();
        _leftClick = GetComponentInChildren<ILeftClick>();
    }
    private void Update()
    {
        _mouseAxis.x = Input.GetAxis(GlobString.MOUSEX_AXIS);
        _mouseAxis.y = Input.GetAxis(GlobString.MOUSEY_AXIS);
        _bodyRotation.Rotate(_mouseAxis);

        _velocity.x = Input.GetAxis(GlobString.HORIZONTAL_AXIS);
        _velocity.z = Input.GetAxis(GlobString.VERTICAL_AXIS);
        _sprint = Input.GetButton(GlobString.FIRE3);
        _playerMovement.Move(_velocity.x, _velocity.z, _sprint);
        if(Input.GetButtonDown(GlobString.Jump)) _playerMovement.Jump();
        if (_leftClick != null)
        {
            if (Input.GetButton(GlobString.FIRE1)) _leftClick.LeftClick();
        }
    }
}   
