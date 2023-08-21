using System;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

namespace GameScene
{
    public class Enemy : MonoBehaviour, Iposable
    {
        [SerializeField] Player _player;
        [SerializeField] int _damage = 1;
        [SerializeField] float _speed = 1;
        [SerializeField] float _hp = 1;
        [SerializeField] GameObject _expObj;
        private Subject<Unit> _onDeath = new();
        public IObservable<Unit> OnDeath => _onDeath;

        public void InitializeEnemy(Player player)
        {
            _player = player;
            this.UpdateAsObservable().Subscribe(_ => Move());
        }

        public void Hit(int damage)
        {
            _hp -= damage;
            if (_hp <= 0)
            {
                Death();
            }
        }

        private void Death()
        {
            Instantiate(_expObj, transform.position, Quaternion.identity);
            FindObjectOfType<PoseManager>().RemovePosableObj(this);
            _onDeath.OnNext(Unit.Default);
        }

        private void Move()
        {
            if (_player == null) return;
            transform.position += (_player.transform.position - transform.position).normalized * Time.deltaTime * _speed;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.TryGetComponent<Player>(out var player))
            {
                player.Hit(_damage);
            }
        }

        public void Pose()
        {
            this.enabled = false;
        }

        public void UnPose()
        {
            this.enabled = true;
        }

        public void Set()
        {
            FindObjectOfType<PoseManager>().SetPosableObj(this);
        }

        private void OnDestroy()
        {
           
        }
    } 
}
