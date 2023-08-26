using UnityEngine;
using System.Collections;

/// <summary>
/// �G�𐶐�����N���X�̊��N���X
/// </summary>
public abstract class GenerateBase : MonoBehaviour
{
    [SerializeField] protected float _enableTime = 1;
    [SerializeField] protected float _generateInterval = 1;
    protected float _currentTime = 0;
    public abstract void TurnOn();
    protected abstract void GenerateRoutine();
    
    /// <summary>
    /// ���g���j�������܂ł̎��Ԃ��v�����A�w�肵�����Ԃ��z������j������
    /// </summary>
    protected void CountDestroyTime()
    {
        _currentTime += Time.deltaTime;
        if (_currentTime >= _enableTime) Destroy(this.gameObject);
    }
    
}
