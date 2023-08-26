using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx.Triggers;
using UniRx;
using GameScene;

/// <summary>
/// ランダムで敵を出現させるクラス
/// </summary>
public class Random4DirectionGenerate : GenerateBase
{
    [SerializeField] EnemyModel _enemy;
    EnemyPool _enemyPool;
    const int DirectionNum = 4;
    GameObject _player;

    private void Awake()
    {
        TurnOn();
    }

    public override void TurnOn()
    {
        _player = FindObjectOfType<Player>().gameObject;
        _enemyPool = new EnemyPool(_enemy);
        this.UpdateAsObservable().Subscribe(_ => CountDestroyTime()).AddTo(this);
        Observable.Interval(System.TimeSpan.FromSeconds(_generateInterval)).Subscribe(_ => GenerateRoutine()).AddTo(this);
    }

    protected override void GenerateRoutine()
    {
        Vector3 pos = GetGeneratePos();

        var enemy = _enemyPool.Rent();
        enemy.transform.parent = null;
        enemy.transform.position = pos;
        enemy.InitializeEnemy(_player);
    }

    /// <summary>
    /// 画面外の4方向のうちランダムな場所を取得
    /// </summary>
    /// <returns></returns>
    private static Vector3 GetGeneratePos()
    {
        var dir = (GenerateSide)Enum.ToObject(typeof(GenerateSide), UnityEngine.Random.Range(0, DirectionNum));
        Vector3 pos;

        if (dir == GenerateSide.Up)
        {
            pos = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 1, 0));
        }
        else if (dir == GenerateSide.Down)
        {
            pos = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0, 0));
        }
        else if (dir == GenerateSide.Left)
        {
            pos = Camera.main.ViewportToWorldPoint(new Vector3(0, 0.5f, 0));
        }
        else
        {
            pos = Camera.main.ViewportToWorldPoint(new Vector3(1, 0.5f, 0));
        }
        return pos;
    }

    enum GenerateSide
    {
        Up = 0,
        Down = 1,
        Left = 2,
        Right = 3,
    }
}
