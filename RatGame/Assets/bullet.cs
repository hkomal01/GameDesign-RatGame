using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Enemies")
        {
            Destroy(gameObject);
        }
        if (collision.collider.CompareTag ("Walls"))
        {
            Destroy(gameObject);
        }
    }
}
