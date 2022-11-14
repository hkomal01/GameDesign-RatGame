using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    private Rigidbody2D rb2D;

    private float moveSpeedMultiplier;
    private float moveHorizontal;
    private float moveVertical;

    // Start is called before the first frame update
    void Start()
    {
      rb2D = GetComponent<Rigidbody2D>();
      moveSpeedMultiplier = 0.3f;
    }

    // Update is called once per frame
    void Update()
    {
      // Left = -1, No keypress = 0, Right = 1
      moveHorizontal = Input.GetAxisRaw("Horizontal");
      moveVertical = Input.GetAxisRaw("Vertical");
      
    }

    void FixedUpdate()
    {
        rb2D.AddForce(new Vector2(moveHorizontal*moveSpeedMultiplier, moveVertical*moveSpeedMultiplier),ForceMode2D.Impulse);
        // if (moveHorizontal == 1) {
        //   this.gameObject.GetComponent<SpriteRenderer>().sprite = RightSprite;
        // } else if (moveHorizontal == -1) {
        //   this.gameObject.GetComponent<SpriteRenderer>().sprite = LeftSprite;
        // } else {
        //   this.gameObject.GetComponent<SpriteRenderer>().sprite = IdleSprite;
        // }
        
    }
}
