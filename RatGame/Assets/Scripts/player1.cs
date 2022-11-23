using System.Collections.Generic;
using System.Collections;
using UnityEngine.InputSystem;
using UnityEngine;

public class player1 : MonoBehaviour {

      public Rigidbody2D rb;
      public float moveSpeed = 5f;
      public Vector2 movement;
      private bool FaceRight = true;
      public Animator Animator;

      public Health health;
      public PlayerWeapon weapon;
      private bool controller;

      Vector2 mousePosition;


      // Auto-load the RigidBody component into the variable:
       void Start(){
            rb = GetComponent<Rigidbody2D> ();
            rb.freezeRotation = true;
            controller = false;
      }

      void Update() {
            var gamepad = Gamepad.current;
            if (Gamepad.current != null) {
                  gamepad = Gamepad.current;
            } else {
                  gamepad = null;
            }

            
            if(!controller && Input.GetButtonDown("Fire1")){
                  weapon.fire();
                  if (CameraShaker.instance != null) {
			      CameraShaker.instance.InitShake(0.125f, 1f);
		      }
            } else if (gamepad != null && gamepad.rightTrigger.wasPressedThisFrame){
                  weapon.fire();
                  if (CameraShaker.instance != null) {
			      CameraShaker.instance.InitShake(0.125f, 1f);
		      }
            }
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // if(health.health == 0) {
            //       Animator.Play ("Dead");
            // }
      }

      // Listen for player input to move the object:
      void FixedUpdate(){
            var gamepad = Gamepad.current;
            if (gamepad == null) {
                  movement.x = Input.GetAxisRaw("Horizontal");
                  movement.y = Input.GetAxisRaw("Vertical");
            } else {
                  movement = gamepad.leftStick.ReadValue();
            }
            
            movement = movement.normalized;
            rb.MovePosition(rb.position + movement * moveSpeed);

            // Turning. Reverse if input is moving the Player right and Player faces left.
            if ((movement.x <0 && !FaceRight) || (movement.x >0 && FaceRight)){
                  playerTurn();
            }

            
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
