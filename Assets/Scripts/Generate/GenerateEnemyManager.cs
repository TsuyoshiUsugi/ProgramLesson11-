using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEnemyManager : MonoBehaviour
{
    [SerializeField] List<GenerateTable> _generateTables;
    // Start is called before the first frame update
    void Start()
    {
        _generateTables[0].GetGenerateRoutine.TurnOn();
    }
}
