using UnityEngine;

public class Bootstrap : MonoBehaviour {
    [SerializeField] private SpawnerField spawnerField;
    [SerializeField] private FieldConfig fieldConfig;
    [SerializeField] private FieldController fieldController;
    [SerializeField] private SpawnerFigure spawnerFigure;
    [SerializeField] private FigureController figureController;
    [SerializeField] private InputGame inputGame;

    private void Awake() {
        fieldController.Initialize(spawnerField.Spawn(fieldConfig));
        figureController.Initialize(inputGame, fieldController);
        spawnerFigure.Initialize(fieldConfig.PositionSpawn, figureController);
    }
}