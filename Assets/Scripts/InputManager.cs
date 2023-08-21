using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameScene
{
    public class InputManager : MonoBehaviour
    {
        [SerializeField] Player _player;
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            var h = Input.GetAxisRaw("Horizontal");
            var v = Input.GetAxisRaw("Vertical");
            if (_player == null) return;
            _player.Move(h, v);
        }
    }
}
