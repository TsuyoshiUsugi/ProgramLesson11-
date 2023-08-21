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

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            transform.position += (_target.transform.position - transform.position).normalized;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent<Player>(out var player))
            {
                player.Hit(_damage);
            }
        }
    } 
}
