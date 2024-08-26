using UnityEngine;
using UnityEngine.UI;

public class SliderVolumeListener : MonoBehaviour
{
    [SerializeField]
    private Slider _slider;
    [SerializeField]
    private SoundGroupController _group;

    private void Start()
    {
        _slider.onValueChanged.AddListener(ChangeVolume);
    }

    private void OnDestroy()
    {
        _slider.onValueChanged.RemoveAllListeners();
    }

    private void ChangeVolume(float volume)
    {
        volume=Mathf.Lerp(0.0001f,1f,volume/_slider.maxValue);
        volume=Mathf.Log10(volume)*20;
        _group.SetVolume(volume);
    }
}
