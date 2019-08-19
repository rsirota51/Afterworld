using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour {
    private float horo;
    private float vert;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        horo = Input.GetAxis("Horizontal");
        vert = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(horo, vert, 0f));
	}
}
