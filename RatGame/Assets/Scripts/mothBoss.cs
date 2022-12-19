using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using MonsterLove.StateMachine;

public class mothBoss : MonoBehaviour
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
	//public Facings Facing;

    [Header ("Stats")]
    public Health owner;
    public float dashDelay;

    [Header ("Angle")]
    protected float currentAngle = 0f;
	public float randomAngle = 20;
    private Vector3 direction;

    [Header("Targets")]
	public string TargetTag = "Entity";

	[Header ("Damage")]
	public int DamageToCause = 1;

	[Header ("Owner")]
	public GameObject Owner;

    private float timer;
    //private GameObject clone;

    private GameObject grid;
    private GameObject exit;

    private Vector3 last_update;

    public StateMachine<States> fsm;

    [Header ("Trigger")]
    private bool trig;
    public enemyTrigger areaTrig;

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
        target = GameObject.Find("Player").transform;
        trig = false;
        if(target) {
            direction = (target.position - transform.position).normalized;

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            
            currentAngle = angle;
            moveDirection = direction;
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        // Debug.Log("x_pos1:  " + last_update.x);
        // Debug.Log("x_pos2:  " + transform.position.x + "\n");

        trig = areaTrig.trigger;

        if(target) {
            direction = (target.position - transform.position).normalized;

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            
            currentAngle = angle;
            moveDirection = direction;
        }

        if(timer > dashDelay && target && trig){
            timer = timer - dashDelay;
            dash();

            direction = (target.position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            currentAngle = angle;
            moveDirection = direction;
        }

        // if (currentAngle < 0) {
		// 	currentAngle += 360f;
		// }

		// if (currentAngle > 270 || currentAngle < 90) {
        //     Facing = Facings.Right;
        //     //transform.localScale = new Vector3(1,1,1);
		// } else {
		// 	Facing = Facings.Left;
        //     //transform.localScale = new Vector3(-1,1,1);
		// }
    }

    void FixedUpdate()
    {
        
    }

    void LateUpdate() {
        UpdateSprite();
    }

    void UpdateSprite() {

        // var targetScale = Facing == Facings.Right ? new Vector3(-4,4,0) : new Vector3(4,4,0);
		// transform.localScale = targetScale;

    }

    public void TakeDamage(float damageAmount)
    {
        
        // Debug.Log("Health: " + PlayerPrefs.GetFloat("Health"));

    }

    void dash()
    {
        var amount = UnityEngine.Random.Range (-randomAngle, randomAngle);
        if(target) {
            rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * moveSpeed;
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
        GetComponent<Collider2D>().enabled = false;
        animator.Play("Death");
        Destroy(gameObject, 1);
    }
}
