using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
//using MonsterLove.StateMachine;

public class shooterOneScript : MonoBehaviour
{
    [Header ("Animator")]
	public Animator animator;

    [SerializeField] float moveSpeed = 5f;
    Rigidbody2D rb;
    Transform target;
    Vector2 moveDirection;

    [Header ("Facing Direction")]
	public Facings Facing;

    [Header ("Stats")]
    public ProjectileEnemy bullet;
    public float bulletLife = 5.0f;
    public float fireDelay;
    public Health owner;
    public Transform gunBarrel;
    public WeaponEnemy weapon;

    [Header ("Angle")]
    protected float currentAngle = 0f;
	public float randomAngle = 20;

    //private GameObject clone;
    private float timer;
    private GameObject grid;
    private GameObject exit;
    private bool dead;

    [Header ("Trigger")]
    private bool trig;
    public enemyTrigger areaTrig;

    private GameObject p;
    public string wep;

    private bool knockback;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Entity").transform;
        dead = false;
        trig = false;
        knockback = false;

        p = GameObject.FindWithTag("Entity");
        wep = "";

    }

    // Update is called once per frame
    void Update()
    {
        if (p.GetComponent<Player>().weapon != null){
            wep = p.GetComponent<Player>().weapon.gunName;
        }

        trig = areaTrig.trigger;

        if (trig) 
        {
            timer += Time.deltaTime;

            if(target) {
                Vector3 direction = (target.position - transform.position).normalized;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                //rb.rotation = angle;
                currentAngle = angle;
                moveDirection = direction;
            }

            if(timer > fireDelay && !dead){
                timer = timer - fireDelay;
                shoot();
            }
        }

        if (currentAngle < 0) {
			currentAngle += 360f;
		}

		if (currentAngle > 270 || currentAngle < 90) {
            Facing = Facings.Right;
		} else {
			Facing = Facings.Left;
		}

        if (weapon != null) {
			weapon.SetRotation (currentAngle);
		}
    }

    void FixedUpdate()
    {
        if (knockback && wep != "ThunderGun")
            Knockback();

        if(target) {
            rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * moveSpeed;
        }
    }

    void LateUpdate()
    {
        UpdateSprite();
    }

    void UpdateSprite () {
		var targetScale = Facing == Facings.Right ? new Vector3((float)1.25,(float)1.25,0) : new Vector3((float)-1.25,(float)1.25,0);
		transform.localScale = targetScale;
    }

    public void TakeDamage(float damageAmount)
    {
        // print("damage");
        knockback = true;
        // moveDirection = rb.transform.position - target.position;
        // rb.AddForce(moveDirection.normalized * -300f);
    }

    private void Knockback() {
        moveDirection = rb.transform.position - target.position;
        // rb.drag = 100;
        rb.AddForce(moveDirection.normalized * -5000f);
        // rb.drag = 0;
        knockback = false;
    }

    void shoot()
    {
        var amount = UnityEngine.Random.Range (-randomAngle, randomAngle);
        ProjectileEnemy fired = Instantiate(bullet, gunBarrel.position, Quaternion.Euler(new Vector3(0f, 0f, currentAngle + amount))) as ProjectileEnemy;//Quaternion.identity);
        fired.owner = owner;
        Destroy(fired.gameObject, bulletLife);
    }

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
        dead = true;
        animator.Play("Death");
        Destroy(gameObject, 1);
    }
}
