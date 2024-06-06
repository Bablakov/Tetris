using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CinemachineTargetGroup))]
public class TargetGroupCamera : MonoBehaviour {
    [SerializeField] private Transform[] pointForLook;

    private CinemachineTargetGroup _cinemachineTargetGroup;
    private List<CinemachineTargetGroup.Target> _targets;

    private void Awake() {
        _cinemachineTargetGroup = GetComponent<CinemachineTargetGroup>();
        _targets = new();
        foreach (var point in pointForLook) {
            _targets.Add(new CinemachineTargetGroup.Target() { target = point, weight = 1, radius = 0 });
        }
        _cinemachineTargetGroup.m_Targets = _targets.ToArray();
    }
}