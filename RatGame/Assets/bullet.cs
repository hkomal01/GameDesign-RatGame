using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    float damage = 1f;

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Enemies")
        {
            shooterOneScript eHealth = collision.gameObject.GetComponent<shooterOneScript>();
            //collision.getComponent<shooterOneScript>().Health -= damage;
            eHealth.TakeDamage(damage);
            Destroy(gameObject);
        }
        if (collision.collider.CompareTag ("Walls"))
        {
            Destroy(gameObject);
        }
    }
}
