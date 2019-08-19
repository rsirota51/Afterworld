using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {
    public int hp=100;
    public int bulletdamage = 50;
    public GameObject bullet;
	// Use this for initialization
	void Start () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject == bullet)
        {
           
            hp -= bulletdamage;
            Debug.Log(hp);
        }
    }

    // Update is called once per frame
    void Update () {
		if(hp<=0)
        {
            Destroy(this.gameObject);
        }
	}
}
