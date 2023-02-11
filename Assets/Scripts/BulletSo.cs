using UnityEngine;

[CreateAssetMenu(fileName = "Bullet", menuName = "ScriptableObjects/BulletSO", order = 0)]
public class BulletSO : ScriptableObject
{
    [SerializeField] private string bulletName;
    [SerializeField] private float speed;
    [SerializeField] private float coolDown;
    [SerializeField] private int damage;

    public string BulletName
    {
        get => bulletName;
        set => bulletName = value;
    }

    public float Speed
    {
        get => speed;
        set => speed = value;
    }

    public float CoolDown
    {
        get => coolDown;
        set => coolDown = value;
    }

    public int Damage
    {
        get => damage;
        set => damage = value;
    }

}
