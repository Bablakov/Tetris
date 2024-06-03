using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ButtonSoundControl : StandartButton {
    [SerializeField] private Sprite _soundOn;
    [SerializeField] private Sprite _soundOff;

    private bool _isSoundOn = true;
    private Image _image;

    public override void Initialize(EventBus eventBus) {
        base.Initialize(eventBus);
        SetInitialValue();
        AddMethodInEventClick(TurnSound);
        AddEventOnButton();
    }

    protected override void GetComponent() {
        base.GetComponent();
        _image = GetComponent<Image>();
    }

    private void SetInitialValue() {
        _isSoundOn = true;
        _image.sprite = _soundOn;
    }

    private void TurnSound() {
        SetSoundInGameOpposite();
        SetSoundValueOpposite();
    }

    private void SetSoundInGameOpposite() {
        if (_isSoundOn) {
            GameSoundController.TurnOffSound();
            _image.sprite = _soundOff;

        } else {
            GameSoundController.TurnOnSound();
            _image.sprite = _soundOn;
        }
    }

    private void SetSoundValueOpposite() {
        _isSoundOn = !_isSoundOn;
    }
}