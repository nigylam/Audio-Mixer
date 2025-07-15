using UnityEngine;

public class VolumeSwitcher : MonoBehaviour
{
    [SerializeField] private VolumeChanger _volumeChanger;

    private bool _isDisabled = false;

    public void ToggleVolume()
    {
        _isDisabled = !_isDisabled;

        if (_isDisabled)
            _volumeChanger.DisableVolume();
        else
            _volumeChanger.EnableVolume();
    }
}
