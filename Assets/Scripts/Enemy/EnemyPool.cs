using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx.Toolkit;

namespace GameScene
{
    public class EnemyPool : ObjectPool<NormalEnemy>
    {
        private readonly NormalEnemy _enemyPrefab;
        private readonly Transform _parentTransform;

        public EnemyPool(NormalEnemy enemy, Transform transform)
        {
            _enemyPrefab = enemy;
            _parentTransform = transform;
        }

        protected override NormalEnemy CreateInstance()
        {
            var enemy = GameObject.Instantiate(_enemyPrefab);
            enemy.transform.SetParent(_parentTransform);
            return enemy;
        }

    }
}
