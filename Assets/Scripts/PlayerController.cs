using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

 [RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    private CharacterController _characterController;
    private Vector2 _input;
    private Vector3 _direction;

    private float _gravity = -9.81f;
    [SerializeField] private float _gravityMultiplier = 12.0f;
    private float _velocity;

    [SerializeField] private float _speed;
    [SerializeField] private float rotationSpeed = 500f;
    private float _currentVelocity;
    [SerializeField] private float _jumpPower;
    private int _numberOfJumps;
    [SerializeField] private int _maxNumberOfjumps = 2;
    private Camera _mainCamera;
    void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _mainCamera = Camera.main;
    }
    void Update()
    {
        ApplyRotation();
        ApplyGravity();
        ApplyMovement();
        
    }

    public void ApplyGravity()
    {
        if(IsGrounded() && _velocity < 0.0f)
        {
            _velocity = -1.0f;
        }
        else
        {
            _velocity += _gravity * _gravityMultiplier * Time.deltaTime;
        }
        _direction.y = _velocity;
    }
    public void ApplyRotation()
    {
        if(_input.sqrMagnitude == 0) return;
        
        _direction = Quaternion.Euler(0.0f, _mainCamera.transform.eulerAngles.y, 0.0f) * new Vector3(_input.x, 0.0f, _input.y);
        var targetRotation = Quaternion.LookRotation(_direction, Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    public void ApplyMovement()
    {
        _characterController.Move(_direction * _speed * Time.deltaTime);
    }

    public void Move(InputAction.CallbackContext context)
    {
        _input = context.ReadValue<Vector2>();
        _direction = new Vector3(_input.x, 0.0f, _input.y);        
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if(!context.started) return;
        if(!IsGrounded() && _numberOfJumps >= _maxNumberOfjumps) return;
        if(_numberOfJumps == 0) StartCoroutine(WaitForLanding());

        _numberOfJumps++;

        _velocity = _jumpPower /_numberOfJumps;

        Debug.Log("Jump");
    }
    private IEnumerator WaitForLanding()
    {
        yield return new WaitUntil(() => !IsGrounded());
        yield return new WaitUntil(IsGrounded); 

        _numberOfJumps = 0;
    }

    private bool IsGrounded() => _characterController.isGrounded;
}
