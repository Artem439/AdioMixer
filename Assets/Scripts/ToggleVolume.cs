using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace Sound
{
    [RequireComponent(typeof(Toggle))]
    public class ToggleVolume : MonoBehaviour
    {
        private const string GroupName = "MasterVolume";

        private const string LabelTextOn = "On";
        private const string LabelTextOff = "Off";
        
        private const float NormalVolume = 0.0f;
        private const float MinVolume = -80.0f;
        
        [SerializeField] private AudioMixerGroup _masterMixer;
        [SerializeField] private Text _label;
        
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
            _toggle.onValueChanged.AddListener(UpdateLabel);
        }

        private void OnDisable()
        {
            _toggle.onValueChanged.RemoveListener(ApplyVolume);
            _toggle.onValueChanged.RemoveListener(UpdateLabel);
        }
        
        private void ApplyVolume(bool isOn)
        {
            _masterMixer.audioMixer.SetFloat(GroupName, isOn ? NormalVolume : MinVolume);
        }
        
        private void UpdateLabel(bool isOn)
        {
            _label.text = isOn ? LabelTextOn : LabelTextOff;
        }
    }
}