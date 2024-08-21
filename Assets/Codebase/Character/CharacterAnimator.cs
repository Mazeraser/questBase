using Codebase.Services.Input;
using UnityEngine;
using Zenject;

namespace Codebase.Character
{
    public class CharacterAnimator : MonoBehaviour
    {
	    private InputService _input;
        private Animator _animator;

        private bool _isIdle;

        [Inject]
        private void Construct(InputService input)
        {
            _input = input;
        }

        private void Start()
        {
    	    _animator = GetComponent<Animator>();
            _isIdle = false;
        }

	    private void Update()
	    {
            if (_input.IsMoving)
            {
			    Stay(false);
			    Walk(true);
            }
            else
            {
			    Walk(false);
			    Stay(true);
            }
	    }

	    private void Stay(bool value)
	    {
		    if(!_isIdle&&value)
		    {
	            _animator.SetBool("isRun", false);
	            _isIdle=true;
		    }
	    }

	    private void Walk(bool value)
        {	
    	    if(_isIdle&&value)
    	    {
                _animator.SetBool("isRun", true);
                _isIdle =false;
    	    }
	    }
    }
}