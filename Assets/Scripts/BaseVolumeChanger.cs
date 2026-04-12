using Interfaces;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public abstract class BaseVolumeChanger : MonoBehaviour, IChangeableSound
{
    [SerializeField] private AudioMixerGroup _soundMixer;
    
    private const float MinValue = 0.0001f;
    private const float MaxValue = 1f;
    
    protected abstract string GroupName { get; }
    
    private Slider _slider;
    
    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void Start()
    {
        GetComponentInChildren<Slider>().value = PlayerPrefs.GetFloat(GroupName, MaxValue);
    }
    
    private void OnEnable()
    {
        _slider.onValueChanged.AddListener(ChangeVolume);
    }

    private void OnDestroy()
    {
        _slider.onValueChanged.RemoveListener(ChangeVolume);
    }

    public void ChangeVolume(float value)
    {
        _soundMixer.audioMixer.SetFloat(GroupName, Mathf.Log10(Mathf.Clamp(value, MinValue, MaxValue)) * 20);
        PlayerPrefs.SetFloat(GroupName, value);
    }
}