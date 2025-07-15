using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeChanger : MonoBehaviour
{
    private readonly string MasterVolume = "MasterVolume";
    private readonly string MusicVolume = "MusicVolume";
    private readonly string EffectsVolume = "EffectsVolume";
    private List<string> Channels = new List<string>();

    private const float MixerMinValue = -80;
    private const int DbToPercentConstant = 20;

    [SerializeField] private AudioMixer _audioMixer;

    public float MasterCurrentValue { get; private set; }

    private bool _isDisabled = false;

    private void Awake()
    {
        _audioMixer.GetFloat(MasterVolume, out float currentValue);
        MasterCurrentValue = currentValue;
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
            MasterCurrentValue = volume;
            
            if(_isDisabled == false)
                _audioMixer.SetFloat(MasterVolume, MasterCurrentValue);
        }
        else
        {
            _audioMixer.SetFloat(channel, volume);
        }
    }

    public void DisableVolume()
    {
        _audioMixer.SetFloat(MasterVolume, MixerMinValue);
        _isDisabled = true;
    }

    public void EnableVolume()
    {
        _audioMixer.SetFloat(MasterVolume, MasterCurrentValue);
        _isDisabled = false;
    }

    private bool CheckChannel(string channel)
    {
       return Channels.Contains(channel);
    }
}
