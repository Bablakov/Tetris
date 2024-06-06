using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SetingValue : MonoBehaviour {
    private Slider _slider;
    private TextMeshProUGUI _textMeshPro;
    private string _text;

    public void Initialize(float initialValue) {
        GetComponents();
        SetValue(initialValue);
        Subscribe();
    }

    public void SetValue(float value) {
        _slider.value = value;
        _textMeshPro.text = _text + (int)(_slider.value * 100);
    }

    public float GetValue() {
        return _slider.value;
    }
        
    private void GetComponents() {
        _slider = GetComponentInChildren<Slider>();
        _textMeshPro = GetComponentInChildren<TextMeshProUGUI>();
        _text = _textMeshPro.text + "\n";
    }

    private void Subscribe() {
        _slider.onValueChanged.AddListener(SetValue);
    }
}