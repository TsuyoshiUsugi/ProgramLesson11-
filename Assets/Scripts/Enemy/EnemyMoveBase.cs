using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �ړ��Ɏg�����N���X
/// </summary>
[System.Serializable]
public abstract class EnemyMoveBase : MonoBehaviour
{
    [SerializeField] protected float _speed = 1;
    protected GameObject _target;

    /// <summary>
    /// �ړ��̖ڕW�Ƒ��x�����߂�
    /// </summary>
    /// <param name="target"></param>
    /// <param name="speed"></param>
    public void SetTarget(GameObject target)
    {
        _target = target;
    }

    public abstract void Move();
}
