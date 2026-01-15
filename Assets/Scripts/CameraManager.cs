using System;
using UnityEngine;
using UnityEngine.InputSystem;
public class CameraManager : MonoBehaviour
{
    private float _distanceToPlayer;
    [SerializeField] private Transform target;
     private Vector2 _input;
     [SerializeField] private MouseSensitivity _mouseSensitivity;
     private CameraRotation _cameraRotation;
    [SerializeField] private CameraAngle _cameraAngle;

    void Awake() =>_distanceToPlayer = Vector3.Distance(transform.position, target.position);
   
    public void Look(InputAction.CallbackContext context)
    {
        _input = context.ReadValue<Vector2>();
    }

    void Update()
    {
        _cameraRotation.Yaw += _input.x * _mouseSensitivity.horizontal * BoolToInt(_mouseSensitivity.invertHorizontal) * Time.deltaTime;   
        _cameraRotation.Pitch += _input.y * _mouseSensitivity.vertical * BoolToInt(_mouseSensitivity.invertVertical) * Time.deltaTime;
        _cameraRotation.Pitch = Mathf.Clamp(_cameraRotation.Pitch, _cameraAngle.min, _cameraAngle.max);
    }

    void LateUpdate()
    {
        transform.eulerAngles = new Vector3(_cameraRotation.Pitch, _cameraRotation.Yaw, 0.0f);
        transform.position = target.position - transform.forward * _distanceToPlayer;
    }
    private static int BoolToInt(bool b) => b ? 1: -1;  
}

[Serializable]
public struct MouseSensitivity
{
    public float horizontal;
    public float vertical;
    public bool invertVertical;
    public bool invertHorizontal;

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
