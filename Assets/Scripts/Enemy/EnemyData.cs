using UnityEngine;

/// <summary>
/// 敵のデータをまとめたデータクラス
/// </summary>
[CreateAssetMenu(fileName = "EnemyData")]
public class EnemyData : ScriptableObject
{
    public string Name;
    public int HP;
    public Sprite Image;
    public float MoveSpeed;
    //public 
}
