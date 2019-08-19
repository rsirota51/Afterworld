using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectScript : MonoBehaviour {

  
	// Use this for initialization
	void Start () {
	}

    // Update is called once per frame
    void Update()
    {
       
    }

    public void PlayLevel1()
    {
        Debug.Log("Loading Level 1...");
        SceneManager.LoadScene(1);
    }

  
    public void quitGame()
    {
        Application.Quit();
    }

}
