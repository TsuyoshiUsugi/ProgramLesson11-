using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameScene
{
    public class Player : MonoBehaviour
    {
        [SerializeField] float _hp = 10;
        [SerializeField] float _speed = 1;
        [SerializeField] float _aquiredExp = 0;
        [SerializeField] List<GameObject> _skills;
        [SerializeField] ExpTable _expTable;
        [SerializeField] GameObject _levelUpUI;
        [SerializeField] List<Item> _items = new();
        int _currentLevel = 1;

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

        public void Hit(float damage)
        {
            _hp -= damage;
            if (_hp <= 0) Death();
        }

        private void Death()
        {
            Destroy(gameObject);
        }

        public void AddExp(float exp)
        {
            _aquiredExp += exp;

            if (_expTable._levelUpTable.Count < _currentLevel) return;
            if (_expTable._levelUpTable[_currentLevel - 1] <= _aquiredExp)
            {
                LevelUp();
                _currentLevel++;
            }
        }

        private void LevelUp()
        {
            FindObjectOfType<PoseManager>().Pose();
            _levelUpUI.SetActive(true);
        }

        public void GetItem(Item item)
        {
            _items.Add(item);
        }
    }
}
