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
    [SerializeField] float moveSpeed = 5f;
    Rigidbody2D rb;
    Transform target;
    Vector2 moveDirection;

    [Header ("Stats")]
    public ProjectileEnemy bullet;
    public Transform bulletPos;
    public float bulletLife = 5.0f;
    public float fireDelay;
    public Health owner;
    public Transform gunBarrel;

    [Header ("Angle")]
    protected float currentAngle = 0f;
	public float randomAngle = 20;

    private float timer;
    //private GameObject clone;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Entity").transform;
        //clone = Instantiate(bullet);
        //clone.gameObject.transform.localScale = new Vector2(1,1);
        //Destroy(bullet, 0);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(target) {
            Vector3 direction = (target.position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rb.rotation = angle;
            currentAngle = angle;
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
        print("damage");
    }

    void shoot()
    {
        var amount = UnityEngine.Random.Range (-randomAngle, randomAngle);
        ProjectileEnemy fired = Instantiate(bullet, gunBarrel.position, Quaternion.Euler(new Vector3(0f, 0f, currentAngle + amount))) as ProjectileEnemy;//Quaternion.identity);
        fired.owner = owner;
        Destroy(fired, bulletLife);
    }

    public void Die()
    {
        Destroy(gameObject);
        onEnemyKilled.Invoke();
    }
}
