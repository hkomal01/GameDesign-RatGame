using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class pointToCursor : MonoBehaviour
{
    public Vector2 direction;
    public float speed = 5f;

    private void Update() {
        var gamepad = Gamepad.current;
        if (gamepad != null) {
            var mouseScreenPos = Input.mousePosition;
            var startingScreenPos = Camera.main.WorldToScreenPoint(transform.position);
            mouseScreenPos.x -= startingScreenPos.x;
            mouseScreenPos.y -= startingScreenPos.y;
            var angle = Mathf.Atan2(mouseScreenPos.y, mouseScreenPos.x) * Mathf.Rad2Deg - 90f;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        } else {
            direction = gamepad.rightStick.ReadValue();
            direction = direction.normalized;
            var startingScreenPos = Camera.main.WorldToScreenPoint(transform.position);
            var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            //WIP to make player turn to controller direction

        }
        
        
    }
}
