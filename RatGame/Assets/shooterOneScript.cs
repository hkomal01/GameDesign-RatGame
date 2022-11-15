using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooterOneScript : MonoBehaviour
{
    public static event Action<shooterOneScript> OnEnemyKilled;
    [SerializeField] float health, maxHealth = 3f;
    public GameObject bullet;
    public Transform bulletPos;
    public float bulletLife = 5.0f;

    private float timer;
    private GameObject clone;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        clone = Instantiate(bullet);
        clone.gameObject.transform.localScale = new Vector2(1,1);
        Destroy(bullet, 0);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer > 2){
            timer = timer - 2;
            shoot();
        }
    }

    public void TakeDamage(float damageAmount)
    {
        Debug.Log($"Damage amount: {damageAmount}");
        health -= damageAmount;
        Debug.Log($"Health is now: {health}");

        if (health < 0) {
            Destroy(gameObject);
            OnEnemyKilled?.Invoke(this);
        }
    }

    void shoot()
    {
        GameObject fired = Instantiate(clone, bulletPos.position, Quaternion.identity);
        Destroy(fired, bulletLife);
    }
}
