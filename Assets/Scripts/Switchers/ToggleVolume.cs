using Core;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace Switchers
{
    [RequireComponent(typeof(Toggle))]
    public class ToggleVolume : MonoBehaviour
    {
        private const float MinVolume = -80.0f;
        private const float NormalVolume = 0.0f;
        
        private const string LabelTextOn = "On"; 
        private const string LabelTextOff = "Off";
        
        [SerializeField] private MixerGroups _groupType;
        [SerializeField] private AudioMixer _mixer;
        [SerializeField] private Text _label;
        [SerializeField] private Slider _volumeSlider;
        
        private Toggle _toggle;

        private void Awake()
        {
            _toggle = GetComponent<Toggle>();
            ApplyVolume(_toggle.isOn);
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
            _mixer.SetFloat(_groupType.ToString(), isOn ? NormalVolume : MinVolume);
            
            UpdateLabel(isOn);
        }
        
        private void UpdateLabel(bool isOn)
        {
            _label.text = isOn ? LabelTextOn : LabelTextOff;
        }
    }
}