using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgMusic : MonoBehaviour
{
    private bool boss = false;
    public AudioSource bg;
    private AudioSource bs;
    private GameObject[] entities;
    
    // Start is called before the first frame update
    void Start()
    {
        GameObject bossGameplay = GameObject.Find("bossGameplay");
        if(bossGameplay) boss = true;
        if (boss) {
            bs = bossGameplay.GetComponent<AudioSource>();
            bg.Pause();
            bs.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        entities = GameObject.FindGameObjectsWithTag("Entities");	
		if (entities.Length == 0 && boss) {
            bs.Pause();
            bg.Play();
            boss = false;
        }	
    }
}
