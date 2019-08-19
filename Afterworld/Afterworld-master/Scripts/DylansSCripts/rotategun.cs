using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotategun : MonoBehaviour {
    public Transform player;
	// Use this for initialization
	void Start () {
        transform.LookAt(player);
	}
   
    // Update is called once per frame
    void Update () {
        transform.LookAt(player);
    }
}
