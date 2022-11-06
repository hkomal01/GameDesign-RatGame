// a regular portal that teleports the player from A to B.
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class DPortal : MonoBehaviour
{
    public Transform currdestination;

    void OnPortal(Player player)
    {
        //if (currdestination != null)
            //transform.position = currdestination.GetComponent<Teleporter>().GetDestination.position;
    }

    void OnTriggerEnter2D(Collider2D co)
    {
        // if(collision.CompareTag("Teleporter")) {
        //     currdestination = collision.gameObject();
        // }
    }
}
