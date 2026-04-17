using Sound;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class VolumeChanger : MonoBehaviour
{
    private const float MinValue = 0.0001f;
    private const float MaxValue = 1f;
    
    [SerializeField] private AudioMixerGroup _mixerGroup;
    [SerializeField] private MixerGroups _groupType;
    [SerializeField] private AudioSource _audioSource = null;
    
    private Slider _slider;
    
    private void Awake()
    {
        _slider = GetComponent<Slider>();
        ChangeVolume(_slider.value);
    }
    
    private void OnEnable()
    {
        _slider.onValueChanged.AddListener(ChangeVolume);
    }

    private void OnDisable()
    {
        _slider.onValueChanged.RemoveListener(ChangeVolume);
    }

    private void ChangeVolume(float value)
    {
        string groupName = MixerGroupNames.GetName(_groupType);

        if (_audioSource != null)
            _audioSource.volume = value;
        
        _mixerGroup.audioMixer.SetFloat(groupName, Mathf.Log10(Mathf.Clamp(value, MinValue, MaxValue)) * 20);
    }
}