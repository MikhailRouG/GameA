using UnityEngine;

public class BodyRotation : MonoBehaviour
{
    [SerializeField] private float _mouthSensetiveX;
    [SerializeField] private float _mouthSensetiveY;
    public void Rotate(Vector2 velocity) =>
         transform.eulerAngles += new Vector3(0, velocity.x * _mouthSensetiveX, 0f);
}
