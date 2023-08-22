using UnityEngine;
using UniRx.Toolkit;

namespace GameScene
{
    public class EnemyPool : ObjectPool<Enemy>
    {
        private readonly Enemy _enemyPrefab;
        private readonly Transform _parentTransform;

        public EnemyPool(Enemy enemy, Transform transform)
        {
            _enemyPrefab = enemy;
            _parentTransform = transform;
        }

        protected override Enemy CreateInstance()
        {
            var enemy = GameObject.Instantiate(_enemyPrefab);
            enemy.transform.SetParent(_parentTransform);
            return enemy;
        }

    }
}
