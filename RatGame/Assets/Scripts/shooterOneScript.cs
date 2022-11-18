using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
//using MonsterLove.StateMachine;

public class shooterOneScript : MonoBehaviour
{
    public UnityEvent onEnemyKilled;
    public UnityEvent OnTakeDamage;
    public float health, maxHealth = 3f;
    [SerializeField] float moveSpeed = 5f;
    Rigidbody2D rb;
    Transform target;
    Vector2 moveDirection;
    public GameObject bullet;
    public Transform bulletPos;
    public float bulletLife = 5.0f;
    public float fireDelay;

    private float timer;
    private GameObject clone;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        target = GameObject.FindGameObjectWithTag("Entity").transform;
        clone = Instantiate(bullet);
        clone.gameObject.transform.localScale = new Vector2(1,1);
        Destroy(bullet, 0);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(target) {
            Vector3 direction = (target.position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rb.rotation = angle;
            moveDirection = direction;
        }


        if(timer > fireDelay){
            timer = timer - fireDelay;
            shoot();
        }
    }

    void FixedUpdate()
    {
        if(target) {
            rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * moveSpeed;
        }
    }

    public void TakeDamage(float damageAmount)
    {
        Debug.Log($"Damage amount: {damageAmount}");
        health -= damageAmount;
        Debug.Log($"Health is now: {health}");

        if (health <= 0) {
            Destroy(gameObject);
            onEnemyKilled.Invoke();
        }
    }

    void shoot()
    {
        GameObject fired = Instantiate(clone, bulletPos.position, Quaternion.identity);
        Destroy(fired, bulletLife);
    }
}
