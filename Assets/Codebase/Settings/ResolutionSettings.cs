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
            if(PlayerPrefs.HasKey("WindowMode"))
                _windowMode.isOn = PlayerPrefs.GetInt("WindowMode")==1;
            else
                _windowMode.isOn = false;
        }

        private void SetScreenMode(bool isWindowMode)
        {
            PlayerPrefs.SetInt("WindowMode", isWindowMode ? 1 : 0);
            Screen.SetResolution(windowResolution.horizontal, windowResolution.vertical, !isWindowMode);
        }
    }

    [Serializable]
    public class ResItem
    {
        public int horizontal, vertical;
    }
}