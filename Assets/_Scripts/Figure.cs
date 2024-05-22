using System.Collections.Generic;
using UnityEngine;

public class Figure : MonoBehaviour {
    [SerializeField] private Cell cell;

    [SerializeField] private List<Vector3> positionCubes;

    [SerializeField] private Vector3 position;

    [SerializeField] private float speed;

    public void Initialize() {
        
    }

    public void Start() {
        transform.position = position;
    }

    private void Update() {
        transform.position += new Vector3(0, - speed * Time.deltaTime);
    }
}