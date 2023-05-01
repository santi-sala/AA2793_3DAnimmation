using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RosalesController : MonoBehaviour
{
    private const string FORWARDSPEED = "ForwardSpeed";
    private const string TURNINGSPEED = "TurningSpeed";

    private Vector2 _movedirection;
    [SerializeField]
    private float _moveSpeed = 2f;   
    [SerializeField]
    private float _maxForwardSpeed = 15f;
    private float _currentSpeed;
    private float _forwardSpeed;

    [SerializeField]
    private float _maxTurning = 3f;
    private float _turningSpeed;
    private float _currentTurning;

    private float _groundAcceleration = 10f;
    private float _groundDecelaration = 25f;

    private Animator _animator;

    private bool _isMoveInput
    {
        get { return !Mathf.Approximately(_movedirection.sqrMagnitude, 0f); }
    }

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
    private void Update()
    {
        Move(_movedirection);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _movedirection = context.ReadValue<Vector2>();
    }

    private void Move(Vector2 direction)
    {
        if (direction.sqrMagnitude > 1f)
        {
            direction.Normalize();
        }

        float acceleration = _isMoveInput ? _groundAcceleration : _groundDecelaration;
        
        if (direction.y == 0)
        {
            
            _currentTurning = direction.magnitude * _maxTurning * Mathf.Sign(direction.x);
            _turningSpeed = Mathf.MoveTowards(_turningSpeed, _currentTurning, acceleration * Time.deltaTime);
            _animator.SetFloat(TURNINGSPEED, _turningSpeed);

            _forwardSpeed = Mathf.MoveTowards(_forwardSpeed, 0, _groundDecelaration * Time.deltaTime);
            _animator.SetFloat(FORWARDSPEED, _forwardSpeed);

        }
        else if (direction.x == 0)
        {
            
            _currentSpeed = direction.magnitude * _maxForwardSpeed * Mathf.Sign(direction.y);
            _forwardSpeed = Mathf.MoveTowards(_forwardSpeed, _currentSpeed, acceleration * Time.deltaTime);
            _animator.SetFloat(FORWARDSPEED, _forwardSpeed);

            _turningSpeed = Mathf.MoveTowards(_turningSpeed, 0, _groundDecelaration * Time.deltaTime);
            _animator.SetFloat(TURNINGSPEED, _turningSpeed);
        }
        else if (direction.y != 0 && direction.x != 0)
        {
            _currentSpeed = direction.magnitude * _maxForwardSpeed * Mathf.Sign(direction.y);
            _forwardSpeed = Mathf.MoveTowards(_forwardSpeed, _currentSpeed, acceleration * Time.deltaTime);
            _animator.SetFloat(FORWARDSPEED, _forwardSpeed);

            _currentTurning = direction.magnitude * _maxTurning * Mathf.Sign(direction.x);
            _turningSpeed = Mathf.MoveTowards(_turningSpeed, _currentTurning, acceleration * Time.deltaTime);
            _animator.SetFloat(TURNINGSPEED, _turningSpeed);
        }
        
        
        

        
        
        
        
        //transform.Rotate(0, direction.x * _turningSpeed * Time.deltaTime, 0);
    }
}
