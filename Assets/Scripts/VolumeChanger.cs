using UnityEngine;
using UnityEngine.Audio;

public class VolumeChanger : MonoBehaviour
{
    private readonly string MasterVolume = "MasterVolume";
    private readonly string MusicVolume = "MusicVolume";
    private readonly string EffectsVolume = "EffectsVolume";
    private readonly float MixerMinValue = -80;

    [SerializeField] private AudioMixer _audioMixer;

    private bool _isDisabled = false;
    private float _masterVolumeCurrentValue;

    private void Awake()
    {
        _audioMixer.GetFloat(MasterVolume, out _masterVolumeCurrentValue);
    }

    public void ToggleVolume()
    {
        _isDisabled = !_isDisabled;

        if (_isDisabled)
            _audioMixer.SetFloat(MasterVolume, MixerMinValue);
        else
            _audioMixer.SetFloat(MasterVolume, _masterVolumeCurrentValue);
    }

    public void ChangeMasterVolume(float volume)
    {
        _masterVolumeCurrentValue = Mathf.Log10(volume) * 20;

        if (_isDisabled == false)
            _audioMixer.SetFloat(MasterVolume, _masterVolumeCurrentValue);
    }

    public void ChangeMusicVolume(float volume)
    {
        _audioMixer.SetFloat(MusicVolume, Mathf.Log10(volume) * 20);
    }    
    
    public void ChangeEffectsVolume(float volume)
    {
        _audioMixer.SetFloat(EffectsVolume, Mathf.Log10(volume) * 20);
    }
}
