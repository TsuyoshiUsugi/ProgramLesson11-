using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敵に向かって一直線に進む敵のクラス
/// </summary>
[System.Serializable]
public class BulldogEnemyMove : EnemyMoveBase
{
    /// <summary>
    /// プレイヤーに向かって一直線に進んでくる
    /// </summary>
    public override void Move()
    {
        if (_target == null) return;
        transform.position += (_target.transform.position - transform.position).normalized * Time.deltaTime * _speed;
    }
}
