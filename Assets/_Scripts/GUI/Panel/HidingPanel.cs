using UnityEngine.UI;

public class HidingPanel : BasePanel{
    private Image _image;

    public override void Initialize(EventBus eventBus) {
        base.Initialize(eventBus);
        Hide();
    }

    protected override void GetComponents() {
        _image = GetComponent<Image>();
    }

    public virtual void Hide() {
        _image.enabled = false;
    }

    public virtual void Show() {
        _image.enabled = true;
    }
}