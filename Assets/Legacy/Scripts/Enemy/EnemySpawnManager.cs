using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using System.Collections;
using System;
using TsuyoshiLibrary;

namespace GameScene
{
    /// <summary>
    /// 敵の生成を管理する
    /// </summary>
    public class EnemySpawnManager : SingletonMonobehavior<MonoBehaviour>
    {
        [SerializeField] GameObject _player;
        [SerializeField] EnemyModel _enemy;
        [SerializeField] List<GameObject> _spawnPointList;
        Vector3 _offset;
        EnemyPool _enemyPool;
        IDisposable _currentRoutine;
        [SerializeField] Queue<string> a;

        public void Start()
        {
            SetField();
            this.UpdateAsObservable().Subscribe(_ => AdjustSpawnPos());
            _enemyPool = new EnemyPool(_enemy);
            _currentRoutine = Observable.Interval(System.TimeSpan.FromSeconds(0.5f)).Subscribe(_ => InstantiateEnemy(GetInstantiatePos()));
        }

        private void InstantiateEnemy(Vector3 instantitatePos)
        {
            var enemy = _enemyPool.Rent();
            enemy.transform.parent = null;
            enemy.InitializeEnemy(_player);
            enemy.transform.position = instantitatePos;
        }

        private Vector3 GetInstantiatePos()
        {
            int index = UnityEngine.Random.Range(0, _spawnPointList.Count);
            return _spawnPointList[index].transform.position;
        }

        private void SetField()
        {
            _offset = transform.position - _player.transform.position;
        }

        /// <summary>
        /// スポーンポイントをプレイヤーの位置に合わせて動かす
        /// </summary>
        private void AdjustSpawnPos()
        {
            if (_player == null) return;
            transform.position = _player.transform.position + _offset;
        }

        protected override void OnAwake()
        {
        }
    }
}
