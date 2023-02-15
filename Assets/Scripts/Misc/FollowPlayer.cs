using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    
    void Update()
    {
        if (!player) return;
        transform.position = player.transform.position + new Vector3(0,0,transform.position.z);   
    }
}
