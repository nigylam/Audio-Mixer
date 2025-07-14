using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using System.Collections;

public class ButtonTextHighlight : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler
{
    private TextMeshProUGUI _text;
    private Color _normalColor = Color.white;
    private Color _hoverColor = Color.yellow;
    private bool _isSelected = false;
    private WaitForSeconds _colorChangeDelayWait;
    private float _colorChangeDelay = 0.5f;

    private void Awake()
    {
        _text = GetComponentInChildren<TextMeshProUGUI>();
        _colorChangeDelayWait = new WaitForSeconds(_colorChangeDelay);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _text.color = _hoverColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _text.color = _normalColor;
    }

    public void OnSelect(BaseEventData eventData)
    {
        _isSelected = true;
        StartCoroutine(SwitchColor());
    }

    public void OnDeselect(BaseEventData eventData)
    {
        _isSelected = false;
        _text.color = _normalColor;
    }

    private IEnumerator SwitchColor()
    {
        while (_isSelected)
        {
            _text.color = _hoverColor;
            yield return _colorChangeDelayWait;
            _text.color = _normalColor;
            yield return _colorChangeDelayWait;
        }
    }
}