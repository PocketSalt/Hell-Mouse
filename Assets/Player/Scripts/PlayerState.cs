using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    // so if you collide with a tag Attack
    // then deal damage, and kill attack object.

    // get player stats
    PlayerStats stats;

    public void Start()
    {
        stats = GetComponent<PlayerStats>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        // check if tag == Attack
        if (collision.tag == "Attack")
        {   
            stats.HP -= 1;
            Debug.Log($"HP: {stats.HP}");
            Destroy(collision.gameObject);
        }
    }
}
