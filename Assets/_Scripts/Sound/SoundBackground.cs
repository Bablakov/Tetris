using UnityEngine;

public class SoundBackground : Sound {
    private AudioClip _soundBackground;

    public override void Initialize(SoundConfig config) {
        base.Initialize(config);
        StartPlay();
    }

    protected override void SetValue(SoundConfig config) {
        _soundBackground = config.Background;
    }

    private void StartPlay() {
        AudioSource.clip = _soundBackground;
        AudioSource.loop = true;
        AudioSource.Play();
    }
}