using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameScene
{
    public class InputManager : MonoBehaviour, Iposable
    {
        [SerializeField] Player _player;
        bool _isPose = false;

        public void Pose()
        {
            _isPose = true;
        }

        public void Set()
        {
            FindObjectOfType<PoseManager>().SetPosableObj(this);
        }

        private void OnDestroy()
        {
            FindObjectOfType<PoseManager>().RemovePosableObj(this);
        }

        public void UnPose()
        {
            _isPose = false;
        }

        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            
            
            if (_isPose) return;
            var h = Input.GetAxisRaw("Horizontal");
            var v = Input.GetAxisRaw("Vertical");
            if (_player == null) return;
            _player.Move(h, v);
        }
    }
}
