using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class Player : Actor {

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
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
            movement = movement.normalized;
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
      
      }
}