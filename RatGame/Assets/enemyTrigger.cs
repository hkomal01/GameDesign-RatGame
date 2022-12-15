using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyTrigger : MonoBehaviour
{
    public bool trigger = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Entity")
        {
            trigger = true;
        }
    }
}
