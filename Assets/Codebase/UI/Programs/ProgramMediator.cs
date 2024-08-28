using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Codebase.UI.Programs
{
    public class ProgramMediator : MonoBehaviour
    {
        public static Action<GameObject> SetParentToProgram;

        [SerializeField]
        private Button _exit;

        private void Start()
        {
            SetParentToProgram?.Invoke(gameObject);

            _exit.onClick.AddListener(GetComponentInParent<ProgramStorage>().EndProgram);
        }
    }
}