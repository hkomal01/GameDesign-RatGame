using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class player1 : Actor {

      public Rigidbody2D rb;
      public float moveSpeed = 5f;
      public Vector2 movement;
      
      private float moveSpeedMultiplier;
      private float moveHorizontal;
      private float moveVertical;
      // Auto-load the RigidBody component into the variable:
      void Start(){
            rb = GetComponent<Rigidbody2D> ();
            moveSpeedMultiplier = 0.3f;

      }

      void Update() {
            moveHorizontal = Input.GetAxisRaw("Horizontal");
            moveVertical = Input.GetAxisRaw("Vertical");
      }

      // Listen for player input to move the object:
      void FixedUpdate(){
            // movement.x = Input.GetAxisRaw ("Horizontal");
            // rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
            rb.AddForce(new Vector2(moveHorizontal*moveSpeedMultiplier, moveVertical*moveSpeedMultiplier),ForceMode2D.Impulse);

            // movement.y = Input.GetAxisRaw ("Vertical");
            // movement.x = Input.GetAxisRaw("Horizontal");
            // movement = movement.normalized;
            // rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
      
      }
}