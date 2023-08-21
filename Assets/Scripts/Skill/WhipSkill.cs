using UnityEngine;
using UniRx;

namespace GameScene
{
    public class WhipSkill : MonoBehaviour, ISkill, Iposable
    {
        [SerializeField] GameObject _whip;
        [SerializeField] float _destroySec = 0.5f;
        [SerializeField] float _instantiateSec = 1f;
        [SerializeField] Vector3 _generatePos = new Vector3(1, 0 , 0);
        bool _isPose = false;

        private void Start()
        {
            UseSkill();
        }

        public void UseSkill()
        {
            Observable.Interval(System.TimeSpan.FromSeconds(_instantiateSec)).Subscribe(_ => GenerateWhip()).AddTo(this);
        }

        private void GenerateWhip()
        {
            if (_isPose) return;
            var whip = GameObject.Instantiate(_whip);
            whip.transform.localRotation = Quaternion.Euler(-Vector3.right);

            if (transform.localScale.x > 0) whip.transform.position = transform.position + _generatePos;
            else whip.transform.position = transform.position - _generatePos;
            Destroy(whip, _destroySec);
        }

        public void Pose()
        {
            _isPose = true;
        }

        public void UnPose()
        {
            _isPose = false;
        }

        public void Set()
        {
            FindObjectOfType<PoseManager>().SetPosableObj(this);
        }
    }
}
