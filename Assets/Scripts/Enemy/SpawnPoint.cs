using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameScene
{
    public class SpawnPoint : MonoBehaviour
    {
        [SerializeField] Player _player;
        Vector3 _offset;

        private void Start()
        {
            _offset = transform.position - _player.transform.position;
        }

        // Update is called once per frame
        void Update()
        {
            transform.position = _player.transform.position + _offset;
        }
    }
}
