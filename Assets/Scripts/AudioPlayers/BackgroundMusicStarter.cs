using UnityEngine;

namespace AudioPlayers
{
    public class BackgroundMusicStarter : MonoBehaviour
    {
        private AudioSource _audioSource;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        private void Start()
        {
            if (_audioSource.clip != null && _audioSource.isPlaying == false)
                _audioSource.Play();
        }
    }
}