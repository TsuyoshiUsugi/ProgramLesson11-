using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using System.Collections;
using System;

namespace GameScene
{
    /// <summary>
    /// ìGÇÃê∂ê¨Çä«óùÇ∑ÇÈ
    /// </summary>
    public class EnemySpawnManager : MonoBehaviour
    {
        [SerializeField] Player _player;
        [SerializeField] Enemy _enemy;
        [SerializeField] Enemy _strongEnemy;
        [SerializeField] List<GameObject> _spawnPointList;
        [SerializeField] Camera _camera;
        Vector3 _offset;
        EnemyPool _enemyPool;
        IDisposable _currentRoutine;

        private void Start()
        {
            SetField();
            this.UpdateAsObservable().Subscribe(_ => AdjustEnemeySpawnPointToPlayer());
            _enemyPool = new EnemyPool(_enemy, _camera.transform);
            _currentRoutine = Observable.Interval(System.TimeSpan.FromSeconds(0.5f)).Subscribe(_ => InstantiateEnemy(GetInstantiatePos()));
            StartCoroutine(EnemyLevelUp());
        }

        private IEnumerator EnemyLevelUp()
        {
            yield return new WaitForSeconds(10);
            _currentRoutine.Dispose();
            _enemyPool.Clear();
            _enemyPool.Dispose();
            _enemyPool = new EnemyPool(_strongEnemy, _camera.transform);
            Debug.Log("10ïbåoâﬂ");
            _currentRoutine = Observable.Interval(System.TimeSpan.FromSeconds(0.5f)).Subscribe(_ => InstantiateEnemy(GetInstantiatePos()));
        }

        private void InstantiateEnemy(Vector3 instantitatePos)
        {
            var enemy = _enemyPool.Rent();
            enemy.transform.parent = null;
            enemy.InitializeEnemy(_player);
            enemy.transform.position = instantitatePos;
            enemy.OnDeath.Subscribe(_ => _enemyPool.Return(enemy));
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

        private void AdjustEnemeySpawnPointToPlayer()
        {
            if (_player == null) return;
            transform.position = _player.transform.position + _offset;
        }
    }
}
