using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct GenerateTable
{
    [SerializeField] float _startTime;
    [SerializeField] GenerateBase _generateBase;

    public float GetStartTime => _startTime;
    public GenerateBase GetGenerateRoutine => _generateBase;
}
