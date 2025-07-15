using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonModifiedSound : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, ISelectHandler, IDeselectHandler
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip[] _clips;
    [SerializeField] private float _shotSpeed = 0.13f;
    [SerializeField] private float _pitchMax = 1.2f;
    [SerializeField] private float _pitchMin = 0.6f;

    private bool _isButtonDown = false;
    private bool _hasFocus = false;

    private void OnEnable()
    {
        InputReader.SubmitButtonDown += SubmitButtonDown;
        InputReader.SubmitButtonUp += SubmitButtonUp;
    }

    private void OnDisable()
    {
        InputReader.SubmitButtonDown -= SubmitButtonDown;
        InputReader.SubmitButtonUp -= SubmitButtonUp;
    }

    private void Update()
    {
        if (_isButtonDown && _hasFocus)
            Play();
    }

    public void OnSelect(BaseEventData eventData)
    {
        _hasFocus = true;
    }

    public void OnDeselect(BaseEventData eventData)
    {
        _hasFocus = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _isButtonDown = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _isButtonDown = false;
    }

    private void SubmitButtonDown() => _isButtonDown = true;
    private void SubmitButtonUp() => _isButtonDown = false;


    private void Play()
    {
        if (_audioSource.isPlaying == false || _audioSource.time >= _shotSpeed)
        {
            _audioSource.clip = _clips[Random.Range(0, _clips.Length)];
            _audioSource.pitch = Random.Range(_pitchMin, _pitchMax);
            _audioSource.Play();
        }
    }
}
