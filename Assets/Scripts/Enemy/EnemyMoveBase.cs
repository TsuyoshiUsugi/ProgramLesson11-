using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 移動に使う基底クラス
/// </summary>
[System.Serializable]
public abstract class EnemyMoveBase : MonoBehaviour
{
    [SerializeField] protected float _speed = 1;
    protected GameObject _target;

    /// <summary>
    /// 移動の目標と速度を決める
    /// </summary>
    /// <param name="target"></param>
    /// <param name="speed"></param>
    public void SetTarget(GameObject target)
    {
        _target = target;
    }

    public abstract void Move();
}
