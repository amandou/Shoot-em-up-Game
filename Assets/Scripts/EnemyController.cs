using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private EnemySO enemy;


    public EnemySO getEnemySO()
    {
        return enemy;
    }
}