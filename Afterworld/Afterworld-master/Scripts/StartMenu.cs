using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : MonoBehaviour {

	// Use this for initialization

	void Start () {
        gameObject.GetComponent<AudioSource>().Play();
        GameObject Level_Camera;
        if ( Level_Camera = GameObject.Find("Level 1 Cameras")){
            Destroy(Level_Camera);
        }
        
            }
	
	// Update is called once per frame
	void Update () {
		
	}
}
