using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敵に向かって一直線に進む敵のクラス
/// </summary>
public class BulldogEnemyMove : MonoBehaviour, IEnemyMovable
{
    GameObject _target;
    float _speed;

    /// <summary>
    /// 移動の目標と速度を決める
    /// </summary>
    /// <param name="target"></param>
    /// <param name="speed"></param>
    public void SetField(GameObject target, float speed)
    {
        _target = target;
        _speed = speed;
    }

    /// <summary>
    /// 敵に向かって一直線に進んでくる
    /// </summary>
    public void Move()
    {
        if (_target == null) return;
        transform.position += (_target.transform.position - transform.position).normalized * Time.deltaTime * _speed;
    }
}
