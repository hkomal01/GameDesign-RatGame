using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooterOneScript : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;
    public float bulletLife = 5.0f;

    private float timer;
    private GameObject clone;
    // Start is called before the first frame update
    void Start()
    {
        clone = Instantiate(bullet);
        clone.gameObject.transform.localScale = new Vector2(1,1);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer > 2){
            timer = timer - 2;
            shoot();
        }
    }

    void shoot()
    {
        GameObject fired = Instantiate(clone, bulletPos.position, Quaternion.identity);
        Destroy(fired, bulletLife);
    }
}
