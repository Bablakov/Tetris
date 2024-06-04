using UnityEngine;

public abstract class Sound : MonoBehaviour {
    protected AudioSource AudioSource;

    public virtual void Initialize(SoundConfig config) {
        GetComponent();
        SetValue(config);
    }

    public void SetVolume(float value) {
        AudioSource.volume = value;
    }

    protected virtual void GetComponent() {
        AudioSource = GetComponent<AudioSource>();
    }

    protected abstract void SetValue(SoundConfig config);
}