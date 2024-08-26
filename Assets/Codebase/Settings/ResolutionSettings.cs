using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Codebase.Settings
{
    public class ResolutionSettings : MonoBehaviour
    {
        [SerializeField]
        private Toggle _windowMode;

        public ResItem windowResolution;

        private void Start()
        {
            _windowMode.onValueChanged.AddListener(SetScreenMode);
        }

        private void SetScreenMode(bool isWindowMode)
        {
            Screen.SetResolution(windowResolution.horizontal, windowResolution.vertical, !isWindowMode);
        }
    }

    [Serializable]
    public class ResItem
    {
        public int horizontal, vertical;
    }
}