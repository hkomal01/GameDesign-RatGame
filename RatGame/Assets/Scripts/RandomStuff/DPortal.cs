// a regular portal that teleports the player from A to B.
using UnityEngine;

public class DPortal : MonoBehaviour
{
    public GameObject portal;
    public GameObject player;

    void start() {
        //player = GameObject.FindWithTag("Entity");
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "Entity") {
            player.transform.position = new Vector2(portal.transform.position.x, portal.transform.position.y);
        }
    }
}
