using UnityEngine;

public class VolumeSlider : MonoBehaviour
{
    [SerializeField] private string Channel;
    [SerializeField] private VolumeChanger _volumeChanger;

    public void ChangeVolume(float volume)
    {
        _volumeChanger.SetVolume(volume, Channel);
    }    
}
