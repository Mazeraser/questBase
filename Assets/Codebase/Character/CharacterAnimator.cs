using Codebase.Character;
using Codebase.Services.Input;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CharacterAnimator : MonoBehaviour
{
	private const string DEFAULT = "idle";
    private const string IDLE = "idle0";
    private const string WALK = "walk";
    private const string BLINK = "Blink";

    private InputService _input;

    private float _blinkTimer = 0f;
    private float _idleTimer = 0f;

    private bool _isIdle;

    [Inject]
    private void Construct(InputService input)
    {
        _input = input;
    }

    private void Start()
    {
    	//_animator = GetComponent<SkeletonAnimation>();
        _isIdle = false;
    }

	private void Update()
	{
        if (_input.IsMoving)
        {
            _blinkTimer = 0f;
            _idleTimer = 0f;
			Stay(false);
			Walk(true);
        }
        else
        {
			Walk(false);
			Stay(true);
            //Blink();
            Idle();
        }
	}

	private void Stay(bool value)
	{
		/*if(!_isIdle&&value)
		{
	        SetSkelet(FRONT_SKELET);
	        _animator.AnimationState.SetAnimation(0, DEFAULT, true);
	        _isIdle=true;
		}*/
	}

	private void Walk(bool value)
    {	
    	/*if(_isIdle&&value)
    	{
	        SetSkelet(SIDE_SKELET);
	        _animator.AnimationState.SetAnimation(0, WALK, true);
	        _isIdle=false;
    	}*/
	}

    private void Idle()
    {
		/*_idleTimer += Time.deltaTime;

		if (_idleTimer >= 15f)
		{
        	SetSkelet(FRONT_SKELET);
	        _animator.AnimationState.SetAnimation(0, IDLE, false);
			_idleTimer = 0f;
		}*/
    }

    private void Blink()
    {
		/*_blinkTimer += Time.deltaTime;

		if (_blinkTimer >= 3f)
		{
        	SetSkelet(FRONT_SKELET);
	        _animator.AnimationState.SetAnimation(0, BLINK, true);
			_blinkTimer = 0f;
		}*/
    }
}
