using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class player1 : MonoBehaviour {

      public Rigidbody2D rb;
      public float moveSpeed = 5f;
      public Vector2 movement;
      private bool FaceRight = true;

      public Health health;
      public PlayerWeapon weapon;

      Vector2 mousePosition;

      // Auto-load the RigidBody component into the variable:
       void Start(){
            rb = GetComponent<Rigidbody2D> ();
            rb.freezeRotation = true;
      }

      void Update() {
            if(Input.GetMouseButtonDown(0)){
                  weapon.fire();
            }
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
      }

      // Listen for player input to move the object:
      void FixedUpdate(){
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
            movement = movement.normalized;
            rb.MovePosition(rb.position + movement * moveSpeed);

            // Turning. Reverse if input is moving the Player right and Player faces left.
            if ((movement.x <0 && !FaceRight) || (movement.x >0 && FaceRight)){
                  playerTurn();
            }

            Vector2 aimDirection = mousePosition - rb.position;
            float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
            //firept.rotation = aimAngle;
            rb.rotation = aimAngle;
      
      }

      //change facing
      private void playerTurn(){
            // NOTE: Switch player facing label
            FaceRight = !FaceRight;

            // NOTE: Multiply player's x local scale by -1.
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
      }
}