using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameScene
{
    public class Whip : MonoBehaviour
    {
        int _damage = 10;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.TryGetComponent(out NormalEnemy enemy))
            {
                enemy.Hit(_damage);
            }
        }
    }
}
