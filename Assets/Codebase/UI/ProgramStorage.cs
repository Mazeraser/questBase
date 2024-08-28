using Codebase.Services.Input;
using Codebase.UI.Programs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Codebase.UI
{
    public class ProgramStorage : MonoBehaviour
    {
        private GameObject _program;
        private InputService _input;

        [Inject]
        private void Construct(InputService input)
        {
            _input = input;
        }

        private void SetParentToProgram(GameObject program)
        {
            _program = program;
            _program.transform.parent = transform;
            _program.transform.localPosition = new Vector3(0, 0, 0);
            _input.DeactivateUI();
        }
        public void EndProgram()
        {
            Destroy(_program);
            _input.ActivateUI();
        }

        private void Start()
        {
            ProgramMediator.SetParentToProgram += SetParentToProgram;
        }
        private void OnDestroy()
        {
            ProgramMediator.SetParentToProgram -= SetParentToProgram;
        }
    }
}
    
