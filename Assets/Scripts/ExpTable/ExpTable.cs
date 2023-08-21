using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ExpData")]
public class ExpTable : ScriptableObject
{
    public List<int> _levelUpTable = new();
}
