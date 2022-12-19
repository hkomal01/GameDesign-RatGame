using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using MonsterLove.StateMachine;

public class ratKing : MonoBehaviour
{
    [Header ("Animator")]
	public Animator animator;

    public enum States {
		Normal, 
		Dead
	}

    [SerializeField] float moveSpeed = 5f;
    public float dashSpeed;
    Rigidbody2D rb;
    Transform target;
    Vector2 moveDirection;

    [Header ("Facing Direction")]
	public Facings Facing;

    [Header ("Stats")]
    public ProjectileEnemy bullet;
    public float bulletLife = 5.0f;
    public float fireDelay;
    public float dashDelay;
    public Health owner;
    public Transform gunBarrel;
    public WeaponEnemy weapon;

    [Header ("Angle")]
    protected float currentAngle = 0f;
	public float randomAngle = 20;
    private Vector3 direction;

    [Header ("Trigger")]
    private bool trig;
    public enemyTrigger areaTrig;

    [Header("Targets")]
	public string TargetTag = "Entity";

	[Header ("Damage")]
	public int DamageToCause = 1;

	[Header ("Owner")]
	public GameObject Owner;

    private float timer1;
    private float timer2;
    private GameObject grid;
    private GameObject exit;
    private bool dead;
    private bool phase2;
    private GameObject body1;
    private GameObject body2;
    private bool dashing = false;

    private Vector3 last_update;

    public StateMachine<States> fsm;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        last_update = transform.position;

        fsm = StateMachine<States>.Initialize(this);

        if (Owner == null) {
			Owner = gameObject;
		}
    }

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Entity").transform;
        body1 = GameObject.Find("phase1Sprite");
        body2 = GameObject.Find("phase2Sprite");
        Debug.Log(body1);
        Debug.Log(body2);
        body2.SetActive(false);
        dead = false;
        trig = false;
    }

    // Update is called once per frame
    void Update()
    {
        trig = areaTrig.trigger;
        float hp = (float)((float)owner.health / (float)owner.maxHealth);

        if(hp <= .66 && !phase2) {
            phase2 = true;
            body2.SetActive(true);
            body1.SetActive(false);
            timer2 = 0;
            timer1 = 0;
            moveSpeed = 60;
        }

        if (trig) 
        {
            timer1 += Time.deltaTime;
            timer2 += Time.deltaTime;

            if(target && !dashing) {
                Vector3 direction = (target.position - transform.position).normalized;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                
                currentAngle = angle;
                moveDirection = direction;
            }

            if(timer1 > fireDelay && !dead && !phase2){
                timer1 = timer1 - fireDelay;
                shoot();
            }
            if(timer1 > 1 && !dead && phase2){
                timer1 = timer1 - 1;
                dashing = false;
            }
            if(timer2 > dashDelay && !dead && phase2){
                timer2 = timer2 - dashDelay;
                dash();
                dashing = true;
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
        if(target && !dashing) {
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
        print("damage");
    }

    void shoot()
    {
        var amount = UnityEngine.Random.Range (-randomAngle, randomAngle);
        ProjectileEnemy fired = Instantiate(bullet, gunBarrel.position, Quaternion.Euler(new Vector3(0f, 0f, currentAngle + amount))) as ProjectileEnemy;//Quaternion.identity);
        fired.owner = owner;
        Destroy(fired.gameObject, bulletLife);
    }

    void dash()
    {
        var amount = UnityEngine.Random.Range (-randomAngle, randomAngle);
        if(target) {
            rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * dashSpeed;
        }
        last_update = transform.position;
    }

    public virtual void OnTriggerEnter2D(Collider2D collider)
	{			
		Colliding (collider);
	}

	public virtual void OnTriggerStay2D(Collider2D collider)
	{			
		Colliding (collider);
	}

	protected virtual void Colliding(Collider2D collider)
	{
		if (!isActiveAndEnabled) {
			return;
		}

		// if what we're colliding with isn't the target tag, we do nothing and exit
		if (!collider.gameObject.CompareTag(TargetTag)) {
			return;
		}

		var health = collider.gameObject.GetComponent<Health>();

		// If what we're colliding with is damageable / Has  health component
		if (health != null)
		{
			if(health.health > 0 && !health.invincible)
			{
				// Apply the Damage
				health.TakeDamage(DamageToCause);
			}
		} 
	}

    public void Die()
    {
        rb.constraints = RigidbodyConstraints2D.FreezePosition;
        dead = true;
        animator.Play("Death");
        Destroy(gameObject, 1);
    }
}
