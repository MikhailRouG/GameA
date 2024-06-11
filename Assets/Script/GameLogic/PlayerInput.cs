using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerInput : MonoBehaviour
{
    private GunShoot _gunShoot;
    private PlayerMovement _playerMovement;
    private BodyRotation _bodyRotation;
    private GunRotation _gunRotation;
    private Vector3 _velocity;
    private Vector2 _mouseAxis;
    private bool _sprint;
    void Start()
    {
        Cursor.visible = false;
        _playerMovement = GetComponent<PlayerMovement>();
        _bodyRotation = GetComponent<BodyRotation>();
        _gunRotation = GetComponentInChildren<GunRotation>();
        _gunShoot = GetComponentInChildren<GunShoot>();
    }
    private void Update()
    {
        _mouseAxis.x = Input.GetAxis(GlobString.MOUSEX_AXIS);
        _mouseAxis.y = Input.GetAxis(GlobString.MOUSEY_AXIS);
        _bodyRotation.Rotate(_mouseAxis);
        _gunRotation.Rotate(_mouseAxis.y);

        _velocity.x = Input.GetAxis(GlobString.HORIZONTAL_AXIS);
        _velocity.z = Input.GetAxis(GlobString.VERTICAL_AXIS);
        _sprint = Input.GetButton(GlobString.FIRE3);
        _playerMovement.Move(_velocity, _sprint);
        if (Input.GetButton(GlobString.FIRE1)) _gunShoot.Shoot();
        //_gunShoot.Recoil(Input.GetButton(GlobString.FIRE2));
        //if(Input.GetKeyDown(KeyCode.R)) _gunController.Reload();
    }
}
