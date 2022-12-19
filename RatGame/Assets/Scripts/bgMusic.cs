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

    }

    // Update is called once per frame
    void Update()
    {
        GameObject bossGameplay = GameObject.Find("bossGameplay");
        GameObject winner = GameObject.Find("winner");
        GameObject loser = GameObject.Find("loser");
        entities = GameObject.FindGameObjectsWithTag("Entities");
        int len = entities.Length;
        if(winner || loser) {
            bg.Pause();
        }
        if(bossGameplay != null && !boss && len > 0) {
            boss = true;
            bs = bossGameplay.GetComponent<AudioSource>();
            bg.Pause();
            bs.Play();
        }
		if (len == 0 && boss) {
            bs.Pause();
            bg.Play();
            boss = false;
        }	
    }
}
