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
        [SerializeField]
        private TMP_Text _resolutionText;

        public ResItem[] resolutions;
        private int _resIndex=0;

        private void Start()
        {
            _windowMode.onValueChanged.AddListener(SetScreenMode);
            ChangeResolution(0);
        }

        public void ChangeResolution(int turn)
        {
            _resIndex = Mathf.Clamp(_resIndex+turn,0, resolutions.Length);
            SetResolution(_resIndex);
        }
        public void SetResolution(int index)
        {
            _resolutionText.text = $"{resolutions[index].horizontal} x {resolutions[index].vertical}";
            Screen.SetResolution(resolutions[index].horizontal, resolutions[index].vertical, !_windowMode.isOn);
        }
        private void SetScreenMode(bool isWindowMode)
        {
            Screen.SetResolution(resolutions[_resIndex].horizontal, resolutions[_resIndex].vertical, !isWindowMode);
        }
    }

    [Serializable]
    public class ResItem
    {
        public int horizontal, vertical;
    }
}