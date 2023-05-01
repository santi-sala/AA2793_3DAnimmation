using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiggerPipoAnimation : MonoBehaviour
{
    const string JUMPINGJACK = "JumpingJack";
    const string HANDWAVE = "HandWave";
    const string KICK = "Kick";

    private Animator _pipoAnimator;
    private bool _isJumping = false;
   // private bool _isKicking = false;
    //private bool _isHandWaving = false;
    private void Start()
    {
        _pipoAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            _pipoAnimator.SetBool(JUMPINGJACK, !_isJumping);
            _isJumping = !_isJumping;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            _pipoAnimator.SetTrigger(HANDWAVE);
            //_isHandWaving = !_isHandWaving;
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            _pipoAnimator.SetTrigger(KICK);
        }
    }

    public void ResetJumpingJack()
    {
        if (_isJumping)
        {
            _isJumping = false;
            _pipoAnimator.SetBool(JUMPINGJACK, false);
        }
        else
        {
            return;
        }
    }
    
}
