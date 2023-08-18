using UnityEngine;
using UniRx;

namespace GameScene
{
    public class WhipSkill : MonoBehaviour, ISkill
    {
        [SerializeField] GameObject _whip;
        [SerializeField] float _destroySec = 0.5f;
        [SerializeField] float _instantiateSec = 1f;
        [SerializeField] Vector3 _generatePos = new Vector3(1, 0 , 0);

        private void Start()
        {
            UseSkill();
        }

        public void UseSkill()
        {
            Observable.Interval(System.TimeSpan.FromSeconds(_instantiateSec)).Subscribe(_ => GenerateWhip());
        }

        private void GenerateWhip()
        {
            var whip = GameObject.Instantiate(_whip);
            whip.transform.localRotation = Quaternion.Euler(-Vector3.right);

            if (transform.localScale.x > 0) whip.transform.position = transform.position + _generatePos;
            else whip.transform.position = transform.position - _generatePos;
            Destroy(whip, _destroySec);
        }
    }
}
