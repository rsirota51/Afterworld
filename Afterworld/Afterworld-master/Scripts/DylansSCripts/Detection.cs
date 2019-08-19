using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection : MonoBehaviour {

    public GameObject player;

    // Use this for initialization
    void Start () {
        GetComponent<Enemy>().stopfire = true;
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D col)
    {

        
        if (col.gameObject == player)
        {

            GetComponent<Enemy>().stopfire = false;
            GetComponent<Enemy>().startFire();
           
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            
            GetComponent<Enemy>().stopfire = true;
           // GameObject.Find("Bullet spawner").GetComponent<Enemy>().enabled = false;

        }
    }
    void Update () {
		
	}
}
