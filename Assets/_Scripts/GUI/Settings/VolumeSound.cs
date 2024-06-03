using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class VolumeSound : MonoBehaviour {
    private Slider _slider;
    private TextMeshProUGUI _textMeshPro;
    private string _text;

    public void Initialize(string text, float initialValue) {
        _text = text + "\n";
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

    private void Subscribe() {
        _slider.onValueChanged.AddListener(SetValue);
    }

    private void Unsubcribe() {
    }
        
    private void GetComponents() {
        _slider = GetComponentInChildren<Slider>();
        _textMeshPro = GetComponentInChildren<TextMeshProUGUI>();
    }

}