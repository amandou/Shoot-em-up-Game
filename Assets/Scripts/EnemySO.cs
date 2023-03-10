using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "ScriptableObjects/EnemySO", order = 1)]
public class EnemySO : ScriptableObject
{
    [SerializeField] private string enemyName;
    [SerializeField] private float speed;
    [SerializeField] private int damage;
    [SerializeField] private int points;

    public string EnemyName
    {
        get => enemyName;
        set => enemyName = value;
    }

    public float Speed
    {
        get => speed;
        set => speed = value;
    }

    public int Damage
    {
        get => damage;
        set => damage = value;
    }

    public int Points
    {
        get => points;
        set => points = value;
    }

}
