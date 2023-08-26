using UnityEngine;
using UniRx;
using UniRx.Triggers;
using GameScene;

/// <summary>
/// エネミーの実体クラス
/// データと移動ルーチンを持つ
/// </summary>
public class EnemyModel : MonoBehaviour, IPausable
{
    [SerializeField] EnemyData _enemyData;
    [SerializeReference] EnemyMoveBase _enemyMove;
    bool _isPausing = false;

    public void InitializeEnemy(GameObject player)
    {
        _enemyMove.SetTarget(player);
        this.UpdateAsObservable().Subscribe(_ => DoMove()).AddTo(this);
    }

    public void DoMove()
    {
        if (_isPausing) return;
        _enemyMove.Move();
    }

    public void Pause(bool isPause)
    {
        _isPausing = isPause;
    }

    private void Death()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            player.Hit(_enemyData.Damage);
        }
    }
}
