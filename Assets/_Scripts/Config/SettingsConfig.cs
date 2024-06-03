using System;
using UnityEngine;

[CreateAssetMenu(fileName = "SettingsConfig", menuName = "Tetris/SettingsConfig")]
public class SettingsConfig : ScriptableObject {
    [SerializeField, Range(0f, 1f)] private float gameVolume;
    [SerializeField, Range(0f, 1f)] private float uiVolume;
    [SerializeField, Range(0f, 1f)] private float musicVolume;

    public event Action ChangedSettings;

    public float GameVolume => gameVolume;
    public float UIVolume => uiVolume;
    public float MusicVolume => musicVolume;

    public void SetNewValue(float gameVolume, float uiVolume, float musicVolume) {
        this.gameVolume = gameVolume;
        this.uiVolume = uiVolume;
        this.musicVolume = musicVolume;
        ChangedSettings?.Invoke();
    }
}