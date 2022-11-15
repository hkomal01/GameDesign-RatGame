using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooterOneScript : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;
    public float bulletLife = 5.0f;

    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        bullet = Instantiate(bullet, bulletPos.position, Quaternion.identity);
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
        GameObject clone = Instantiate(bullet, bulletPos.position, Quaternion.identity);
        Destroy(clone, bulletLife);
    }
}
