using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using MonsterLove.StateMachine;

public class easyEnemy : MonoBehaviour
{

    [Header ("Animator")]
	public Animator animator;

    public enum States {
		Normal, 
		Dead
	}

    [SerializeField] float moveSpeed = 5f;
    Rigidbody2D rb;
    Transform target;
    Vector2 moveDirection;

    [Header ("Facing Direction")]
	public Facings Facing;

    [Header ("Stats")]
    // public ProjectileEnemy bullet;
    // public float bulletLife = 5.0f;
    // public float fireDelay;
    public Health owner;
    // public Transform gunBarrel;
    // public WeaponEnemy weapon;

    [Header ("Angle")]
    protected float currentAngle = 0f;
	public float randomAngle = 20;

    private float timer;
    //private GameObject clone;

    private GameObject grid;
    private GameObject exit;

    private Vector3 last_update;

    public StateMachine<States> fsm;

    [Header ("Trigger")]
    private bool trig;
    public enemyTrigger areaTrig;


    private bool knockback;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        last_update = transform.position;

        fsm = StateMachine<States>.Initialize(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player").transform;
        trig = false;
        knockback = false;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        // Debug.Log("x_pos1:  " + last_update.x);
        // Debug.Log("x_pos2:  " + transform.position.x + "\n");

        trig = areaTrig.trigger;

        if(target && trig) {
            Vector3 direction = (target.position - transform.position).normalized;

            // if (Math.Abs(Math.Abs(transform.position.x) - Math.Abs(last_update.x)) <= 0.1) {
            //     Debug.Log("Stuck x");
            //     direction = new Vector3(direction.x, direction.y + 10.0f, 0.0f).normalized;

            
            // } else if (Math.Abs(Math.Abs(transform.position.y) - Math.Abs(last_update.y)) <= 0.1) {
            //     Debug.Log("Stuck y");
            //     direction = new Vector3(transform.position.x * 2.0f, transform.position.y, 0.0f).normalized;

            // }else {
            //     Debug.Log("Free");
            // }
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            
           
            //rb.rotation = angle;
            currentAngle = angle;
            moveDirection = direction;
        }



        // if(timer > fireDelay){
        //     timer = timer - fireDelay;
        //     shoot();
        // }

        if (currentAngle < 0) {
			currentAngle += 360f;
		}

		if (currentAngle > 270 || currentAngle < 90) {
            Facing = Facings.Right;
            //transform.localScale = new Vector3(1,1,1);
		} else {
			Facing = Facings.Left;
            //transform.localScale = new Vector3(-1,1,1);
		}

        // if (weapon != null) {
		// 	weapon.SetRotation (currentAngle);
		// }
    }

    void FixedUpdate()
    {
        if (knockback)
            Knockback();

        if(target) {
            rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * moveSpeed;
        }
        last_update = transform.position;

    }

    void LateUpdate() {
        // if (knockback)
        //     Knockback();
        UpdateSprite();
    }

    void UpdateSprite() {

        var targetScale = Facing == Facings.Right ? new Vector3(-4,4,0) : new Vector3(4,4,0);
		transform.localScale = targetScale;

    }

    public void TakeDamage(float damageAmount)
    {
        knockback = true;
        // Debug.Log("Health: " + PlayerPrefs.GetFloat("Health"));
        // moveDirection = rb.transform.position - target.position;
        // Debug.Log("direction: " + moveDirection.normalized);

        // rb.AddForce(moveDirection.normalized * -300f);

    }
    
    private void Knockback() {
        moveDirection = rb.transform.position - target.position;

        rb.AddForce(moveDirection.normalized * -1000f, ForceMode2D.Impulse);
        knockback = false;
    }

    // void shoot()
    // {
    //     var amount = UnityEngine.Random.Range (-randomAngle, randomAngle);
    //     ProjectileEnemy fired = Instantiate(bullet, gunBarrel.position, Quaternion.Euler(new Vector3(0f, 0f, currentAngle + amount))) as ProjectileEnemy;//Quaternion.identity);
    //     fired.owner = owner;
    //     Destroy(fired.gameObject, bulletLife);
    // }


    public void Die()
    {
        // grid = GameObject.Find("Grid");

        // if (grid) {
        //     exit = grid.transform.Find("ExitDoor_TM").gameObject;
        //     if (exit) {
        //         exit.gameObject.SetActive(true);
        //     } else {
        //         Debug.Log("Could not find Exit door.");
        //     }
        // }
        rb.constraints = RigidbodyConstraints2D.FreezePosition;
        GetComponent<Collider2D>().enabled = false;
        animator.Play("Death");
        Destroy(gameObject, 1);
    }

}
