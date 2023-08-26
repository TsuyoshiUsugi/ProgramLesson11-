using UnityEngine;
using System.Collections;

/// <summary>
/// 敵を生成するクラスの基底クラス
/// </summary>
public abstract class GenerateBase : MonoBehaviour
{
    [SerializeField] protected float _enableTime = 1;
    [SerializeField] protected float _generateInterval = 1;
    protected float _currentTime = 0;
    public abstract void TurnOn();
    protected abstract void GenerateRoutine();
    
    /// <summary>
    /// 自身が破棄されるまでの時間を計測し、指定した時間を越えたら破棄する
    /// </summary>
    protected void CountDestroyTime()
    {
        _currentTime += Time.deltaTime;
        if (_currentTime >= _enableTime) Destroy(this.gameObject);
    }
    
}
