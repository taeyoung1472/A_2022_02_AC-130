using UnityEngine;
[CreateAssetMenu(fileName = "Info", menuName = "Enemy")]
public class EnemyInfo : ScriptableObject
{
    public string name;
    public int score;
    public int brustCount;
    public int hp;
    public float speed;
    public float attackRange;
}