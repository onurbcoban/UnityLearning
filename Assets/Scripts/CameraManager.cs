using System;
using UnityEngine;
using UnityEngine.InputSystem;
public class CameraManager : MonoBehaviour
{
    private float _distanceToPlayer;
    [SerializeField] private Transform target;
    [SerializeField] private float _smoothTime;
     private Vector3 _currentVelocity = Vector3.zero;
     private Vector2 _input;
     [SerializeField] private MouseSensitivity _mouseSensitivity;
     private CameraRotation _cameraRotation;
    [SerializeField] private CameraAngle _cameraAngle;

    void Awake()
    {
        _distanceToPlayer = Vector3.Distance(transform.position, target.position);
    }
    public void Look(InputAction.CallbackContext context)
    {
        _input = context.ReadValue<Vector2>();
    }

    void Update()
    {
        _cameraRotation.Yaw += _input.x * _mouseSensitivity.horizontal * Time.deltaTime;   
        _cameraRotation.Pitch += _input.y * _mouseSensitivity.vertical * Time.deltaTime;
        Mathf.Clamp(_cameraRotation.Pitch, _cameraAngle.min, _cameraAngle.max);
    }

    void LateUpdate()
    {
        transform.eulerAngles = new Vector3(_cameraRotation.Pitch, _cameraRotation.Yaw, 0.0f);
        transform.position = transform.position - transform.forward * _distanceToPlayer;
    }
}

[Serializable]
public struct MouseSensitivity
{
    public float horizontal;
    public float vertical;
}

public struct CameraRotation
{
    public float Pitch;
    public float Yaw;    
}

[Serializable]
public struct CameraAngle
{
    public float min;
    public float max;

}
