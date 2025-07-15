using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeChanger : MonoBehaviour
{
    private readonly string MasterVolume = "MasterVolume";
    private readonly string MusicVolume = "MusicVolume";
    private readonly string EffectsVolume = "EffectsVolume";
    private List<string> Channels;

    private const float MixerMinValue = -80;
    private const int DbToPercentConstant = 20;

    [SerializeField] private AudioMixer _audioMixer;

    private float _masterCurrentValue;
    private bool _isVolumeDisabled = false;

    private void Awake()
    {
        _audioMixer.GetFloat(MasterVolume, out _masterCurrentValue);
        Channels = new List<string>() { MasterVolume, MusicVolume, EffectsVolume };
    }

    public void SetVolume(float value, string channel)
    {
        if(CheckChannel(channel) == false)
        {
            Debug.LogError("Check the volume channel name.");
        }

        float volume = Mathf.Log10(value) * DbToPercentConstant;

        if (channel == MasterVolume)
        {
            _masterCurrentValue = volume;
            
            if(_isVolumeDisabled == false)
                _audioMixer.SetFloat(MasterVolume, _masterCurrentValue);
        }
        else
        {
            _audioMixer.SetFloat(channel, volume);
        }
    }

    public void DisableMasterVolume()
    {
        _audioMixer.SetFloat(MasterVolume, MixerMinValue);
        _isVolumeDisabled = true;
    }

    public void EnableMasterVolume()
    {
        _audioMixer.SetFloat(MasterVolume, _masterCurrentValue);
        _isVolumeDisabled = false;
    }

    private bool CheckChannel(string channel)
    {
       return Channels.Contains(channel);
    }
}
