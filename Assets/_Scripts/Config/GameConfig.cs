using UnityEngine;

[CreateAssetMenu(fileName = "GameConfig", menuName = "Tetris/GameConfig")]
public class GameConfig : ScriptableObject {
    [SerializeField, Range(0.1f, 100f)] private float speedFigure;

    public float SpeedFigure => speedFigure;
}