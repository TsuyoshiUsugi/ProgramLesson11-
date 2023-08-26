using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �G�Ɍ������Ĉ꒼���ɐi�ޓG�̃N���X
/// </summary>
[System.Serializable]
public class BulldogEnemyMove : EnemyMoveBase
{
    /// <summary>
    /// �v���C���[�Ɍ������Ĉ꒼���ɐi��ł���
    /// </summary>
    public override void Move()
    {
        if (_target == null) return;
        transform.position += (_target.transform.position - transform.position).normalized * Time.deltaTime * _speed;
    }
}
