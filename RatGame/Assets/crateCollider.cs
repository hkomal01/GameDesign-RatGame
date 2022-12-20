using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crateCollider : MonoBehaviour
{
    public Collider2D collision;

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
		Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag != "Entity") {
			Debug.Log("ignoring");
            Physics2D.IgnoreCollision(collision, collider);
		}
	}
}
