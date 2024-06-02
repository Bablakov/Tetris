using UnityEngine;

[CreateAssetMenu(fileName = "SoundConfig", menuName = "Tetris/SoundConfig")]
public class SoundConfig : ScriptableObject {
    [SerializeField] private AudioClip clickButton;
    [SerializeField] private AudioClip deleteLine;
    [SerializeField] private AudioClip moveFigure;
    [SerializeField] private AudioClip rotateFigure;
    [SerializeField] private AudioClip softDropFigure;
    [SerializeField] private AudioClip hardDropFigure;
    [SerializeField] private AudioClip swapFigure;
    [SerializeField] private AudioClip background;

    public AudioClip ClickButton => clickButton;
    public AudioClip DestroyedLine => deleteLine;
    public AudioClip MoveFigure => moveFigure;
    public AudioClip RotateFigure => rotateFigure;
    public AudioClip SoftDropFigure => softDropFigure;
    public AudioClip HardDropFigure => hardDropFigure;
    public AudioClip SwapFigure => swapFigure;
    public AudioClip Background => background;
}