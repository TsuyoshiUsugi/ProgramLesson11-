using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameScene
{
    public class NormalEnemy : MonoBehaviour
    {
        [SerializeField] GameObject _target;
        [SerializeField] int _damage = 1;
        [SerializeField] float _speed = 1;
        [SerializeField] float _hp = 1;

        public void Hit(int damage)
        {
            _hp -= damage;
            if (_hp <= 0)
            {
                Destroy(gameObject);
            }
        }

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            transform.position += (_target.transform.position - transform.position).normalized * Time.deltaTime;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.TryGetComponent<Player>(out var player))
            {
                player.Hit(_damage);
            }
        }
    } 
}
