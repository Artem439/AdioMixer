using Core;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace Switchers
{
    [RequireComponent(typeof(Slider))]
    public class VolumeChanger : MonoBehaviour
    {
        [SerializeField] private MixerGroups _groupType;
        [SerializeField] private AudioMixer _mixer;
    
        private Slider _slider;
    
        private void Awake()
        {
            _slider = GetComponent<Slider>();
        }

        private void Start()
        {
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
            float volumeValue =
                Mathf.Log10(Mathf.Clamp(value, VolumeValues.MinSliderValue, VolumeValues.MaxSliderValue)) *
                VolumeValues.DecibelMultiplier;
            
            _mixer.SetFloat(_groupType.ToString(), volumeValue);
        }
    }
}
