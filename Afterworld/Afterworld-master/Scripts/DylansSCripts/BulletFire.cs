using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFire : MonoBehaviour {

	// Use this for initialization
    public int speed=6;
	void Start () {
        GetComponent<Rigidbody2D>().velocity = transform.forward * speed;
    }
	
	// Update is called once per frame
	void Update () {
        Destroy(this.gameObject,2);
	}
}
