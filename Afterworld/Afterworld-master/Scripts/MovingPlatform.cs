using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {

    public float speed = 5f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.y >= 25f || transform.position.y <= 4f)
        {
            speed *= -1;
        }

        transform.Translate(new Vector3(0f, speed * Time.deltaTime, 0f));
	}
}
