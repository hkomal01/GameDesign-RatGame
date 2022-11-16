using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class player1 : MonoBehaviour {

      public Rigidbody2D rb;
      public float moveSpeed = 5f;
      public Vector2 movement;

      // Auto-load the RigidBody component into the variable:
       void Start(){
            rb = GetComponent<Rigidbody2D> ();
            rb.freezeRotation = true;
      }

      // Listen for player input to move the object:
      void FixedUpdate(){
            movement.x = Input.GetAxisRaw("Player0Horizontal");
            movement.y = Input.GetAxisRaw("Player0Vertical");
            movement = movement.normalized;
            rb.MovePosition(rb.position + movement * moveSpeed);
      
      }
}
