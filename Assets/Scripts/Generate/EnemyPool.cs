using UnityEngine;
using UniRx.Toolkit;

namespace GameScene
{
    public class EnemyPool : ObjectPool<EnemyModel>
    {
        private readonly EnemyModel _enemyPrefab;
        private readonly Transform _parentTransform;

        public EnemyPool(EnemyModel enemy)
        {
            _enemyPrefab = enemy;
            _parentTransform = Camera.main.transform;
        }

        protected override EnemyModel CreateInstance()
        {
            var enemy = GameObject.Instantiate(_enemyPrefab);
            enemy.transform.SetParent(_parentTransform);
            return enemy;
        }

    }
}
