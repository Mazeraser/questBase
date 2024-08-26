using UnityEngine;
using UnityEngine.Audio;

public class SoundGroupController : MonoBehaviour
{
    [SerializeField]private AudioMixerGroup group;
    [SerializeField]private string group_name;

    public void SetVolume(float volume)
    {
        group?.audioMixer.SetFloat(group_name,volume);
    }
}
