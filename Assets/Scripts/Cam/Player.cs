using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameScene
{
    public class Player : MonoBehaviour
    {
        [SerializeField] int _hp = 10;
        [SerializeField] float _speed = 1;

        public void Move(float horizontal, float vertical)
        {
            transform.position += _speed * Time.deltaTime * new Vector3(horizontal, vertical, 0);
            Turn(horizontal);
        }

        private void Turn(float horizontal)
        {
            if (horizontal > 0) transform.localScale = 
                    new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            else if (horizontal < 0) transform.localScale = 
                    new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }

        public void Hit(int damage)
        {
            _hp -= damage;
            if (_hp <= 0) Death();
        }

        private void Death()
        {
            this.gameObject.SetActive(false);
        }
    }
}