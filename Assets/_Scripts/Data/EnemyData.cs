using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemyData", menuName = "ScriptableObjects/EnemyData")]
public class EnemyData : ScriptableObject
{
    public string EnemyName;
    public int MaxHealth;
    public float MoveSpeed;
    public RuntimeAnimatorController AnimatorController;
}