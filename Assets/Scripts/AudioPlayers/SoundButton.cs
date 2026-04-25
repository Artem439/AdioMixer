using Core;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace AudioPlayers
{
    [RequireComponent(typeof(Button))]
    public class SoundButton : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _audioClip;
        [SerializeField] private MixerGroups _groupType;
        [SerializeField] private AudioMixer _mixer;
        
        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        private void Start()
        {
            _audioSource.outputAudioMixerGroup = _mixer.FindMatchingGroups(_groupType.ToString())[0];
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(PlaySound);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(PlaySound);
        }

        private void PlaySound()
        {
            _audioSource.PlayOneShot(_audioClip);
        }
    }
}