using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public Transform player;
    public GameObject bullet;
    public float spawnTime = 3f;
    public Transform Gun;
    public bool stopfire;
    
    // Use this for initialization
    void Start () {
        stopfire = true;
        //transform.LookAt(player);
        //Gun = transform.Find("Gun");
        //InvokeRepeating("Fire", spawnTime, spawnTime); 
    }
	public void startFire()
    {
        InvokeRepeating("Fire", spawnTime, spawnTime);
    }
	// Update is called once per frame
    void Fire()
    {

        Instantiate(bullet,Gun.position,Gun.rotation);
        
    }
	void Update () {
        
        //transform.LookAt(player);
        if (stopfire)
        { CancelInvoke(); }
    }
}
