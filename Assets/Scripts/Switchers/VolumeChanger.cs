using Core;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace Switchers
{
    [RequireComponent(typeof(Slider))]
    public class VolumeChanger : MonoBehaviour
    {
        [SerializeField] private AudioMixerGroup _mixerGroup;
        [SerializeField] private MixerGroups _groupType;
    
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
            string groupName = _groupType.ToString();
        
            _mixerGroup.audioMixer.SetFloat(groupName, Mathf.Log10(Mathf.Clamp(value, VolumeValues.MinSliderValue, VolumeValues.MaxSliderValue)) * VolumeValues.DecibelMultiplier);
        }
    }
}
