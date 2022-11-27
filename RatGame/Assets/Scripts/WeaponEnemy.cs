using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponEnemy : MonoBehaviour
{

    public float ZOffSet = 0f;
    protected float currentAngle = 0f;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void SetRotation (float angle) {
		currentAngle = angle;

		angle += (ZOffSet);
		if (transform.lossyScale.x < 0f) {
			angle = 180 - angle;
		}
			
		//Weapon backwards or infront like in Nuclear Throne
		//if (angle > 25 && angle <= 90) {
		//	spriteRenderer.sortingOrder = -1;
		//} else {
		//	spriteRenderer.sortingOrder = 1;
		//}

		transform.localRotation = Quaternion.Euler(new Vector3(0, 0, angle));
	}

}
