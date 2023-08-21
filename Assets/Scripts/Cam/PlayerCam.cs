using UnityEngine;
using UniRx;
using UniRx.Triggers;

namespace GameScene
{
    public class PlayerCam : MonoBehaviour
    {
        [SerializeField] Camera _camera;
        [SerializeField] Player _player;

        private void Start()
        {
            this.UpdateAsObservable().Subscribe(_ => _camera.transform.position =
                new Vector3(_player.transform.position.x, _player.transform.position.y, _camera.transform.position.z));
            
        }
    }

}
