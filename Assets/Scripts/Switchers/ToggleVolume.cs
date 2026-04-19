using Core;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace Switchers
{
    [RequireComponent(typeof(Toggle))]
    public class ToggleVolume : MonoBehaviour
    {
        private const string LabelTextOn = "On"; 
        private const string LabelTextOff = "Off";
        
        [SerializeField] private AudioMixerGroup _masterMixer;
        [SerializeField] private Text _label;
        [SerializeField] private Slider _volumeSlider;
        
        private Toggle _toggle;

        private void Awake()
        {
            _toggle = GetComponent<Toggle>();
            ApplyVolume(_toggle.isOn);
            UpdateLabel(_toggle.isOn);
        }
        
        private void OnEnable()
        {
            _toggle.onValueChanged.AddListener(ApplyVolume);
        }

        private void OnDisable()
        {
            _toggle.onValueChanged.RemoveListener(ApplyVolume);
        }
        
        private void ApplyVolume(bool isOn)
        {
            _masterMixer.audioMixer.SetFloat(MixerGroups.MasterVolume.ToString(), isOn ? (Mathf.Log10(Mathf.Clamp(_volumeSlider.value, VolumeValues.MinSliderValue, VolumeValues.MaxSliderValue)) * VolumeValues.DecibelMultiplier) : VolumeValues.MinVolume);
            
            UpdateLabel(isOn);
        }
        
        private void UpdateLabel(bool isOn)
        {
            _label.text = isOn ? LabelTextOn : LabelTextOff;
        }
    }
}