using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonTextPressShift : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, ISelectHandler, IDeselectHandler
{
    [SerializeField] private Vector2 _pressedOffset = new Vector2(0, -10);
    [SerializeField] private Sprite _pressedSprite;
    [SerializeField] private Sprite _defaultSprite;

    private Transform _textTransform;
    private Vector2 _originalPosition;
    private bool _isSelected = false;
    private Button _button;

    private void OnEnable()
    {
        InputReader.SubmitButtonDown += SwitchButtonPressedState;
        InputReader.SubmitButtonUp += SwitchButtonDefaultState;
    }

    private void OnDisable()
    {
        InputReader.SubmitButtonDown -= SwitchButtonPressedState;
        InputReader.SubmitButtonUp -= SwitchButtonDefaultState;
    }

    private void Awake()
    {
        _textTransform = GetComponentInChildren<TextMeshProUGUI>().rectTransform;
        _button = GetComponent<Button>();
    }

    private void Start()
    {
        _originalPosition = _textTransform.position;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        SwitchButtonPressedState();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        SwitchButtonDefaultState();
    }

    public void OnSelect(BaseEventData eventData)
    {
        _isSelected = true;
    }

    public void OnDeselect(BaseEventData eventData)
    {
        _isSelected = false;
    }

    private void SwitchButtonPressedState()
    {
        if(_isSelected) 
        {
            ShiftTextDown();
            _button.image.sprite = _pressedSprite;
        }
    }

    private void SwitchButtonDefaultState()
    {
        ShiftTextBack();
        _button.image.sprite = _defaultSprite;
    }

    private void ShiftTextDown()
    {
        _textTransform.position = _originalPosition + _pressedOffset;
    }

    private void ShiftTextBack()
    {
        _textTransform.position = _originalPosition;
    }
}
