using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody _rigidbody;
    [SerializeField] private float _speedForward;
    [SerializeField] private float _height;
    private float _gravity;
    private Vector3 _position;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _layerMask;
    private bool _isGround = true;
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Move(float horizontal,float vertical, bool sprint)
    {
        _isGround = Physics.CheckSphere(_groundCheck.position, 0.5f, _layerMask);
        if (!_isGround) 
        {
            _rigidbody.velocity += new Vector3(0f, _gravity * Time.deltaTime, 0f);
            return;
        }
        Vector3 offset = (horizontal * transform.right + vertical * transform.forward) * (_speedForward* Time.deltaTime);
        _rigidbody.MovePosition(_rigidbody.position + offset);
    }

    public void Jump()
    {
        if (!_isGround) return;
        _rigidbody.AddForce(transform.up * _height, ForceMode.Impulse);
        _isGround = false;
    }
}
