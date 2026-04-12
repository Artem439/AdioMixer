using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class BaseSoundPlayer : MonoBehaviour
{
    [SerializeField] protected AudioSource _audioSource;
        
    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
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
        _audioSource.Play();
    }
}