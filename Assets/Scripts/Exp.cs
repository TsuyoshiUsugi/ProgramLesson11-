using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameScene
{
    public class Exp : MonoBehaviour
    {
        [SerializeField] float _exp = 10;
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.TryGetComponent<Player>(out var player))
            {
                player.AddExp(_exp);
                Destroy(gameObject);
            }
        }
    }
}
