using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour {

	private Vector3 MouseCoords;
	public float MouseSensitivity = 1f;

	void Update () {
		// MouseCoords = Input.mousePosition;
		// MouseCoords = Camera.main.ScreenToWorldPoint (MouseCoords);
		MouseCoords = new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0.0f);
		// if (MouseCoords.x != 0)
		
		MouseCoords.x = (MouseCoords.x) + transform.position.x;
		// if (MouseCoords.y != 0)
		MouseCoords.y = (MouseCoords.y) + transform.position.y;
	
		// MouseCoords.x += GameObject.Find("Player").transform.position.x;
		// MouseCoords.y += GameObject.Find("Player").transform.position.y;


		transform.position = Vector2.Lerp (transform.position, MouseCoords, MouseSensitivity);
	}

	public void SetPos (Vector2 new_pos) {
		transform.position = new_pos;
		Update();
	}
}
