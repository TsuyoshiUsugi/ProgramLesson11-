using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �G�Ɍ������Ĉ꒼���ɐi�ޓG�̃N���X
/// </summary>
public class BulldogEnemyMove : MonoBehaviour, IEnemyMovable
{
    GameObject _target;
    float _speed;

    /// <summary>
    /// �ړ��̖ڕW�Ƒ��x�����߂�
    /// </summary>
    /// <param name="target"></param>
    /// <param name="speed"></param>
    public void SetField(GameObject target, float speed)
    {
        _target = target;
        _speed = speed;
    }

    /// <summary>
    /// �G�Ɍ������Ĉ꒼���ɐi��ł���
    /// </summary>
    public void Move()
    {
        if (_target == null) return;
        transform.position += (_target.transform.position - transform.position).normalized * Time.deltaTime * _speed;
    }
}
