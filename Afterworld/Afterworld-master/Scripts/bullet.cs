using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class bullet : MonoBehaviour {



    

 
	// Use this for initialization
	void Start () {
        


        Destroy(gameObject, 5f);
	}



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.GetComponent<Rigidbody2D>().IsTouchingLayers(LayerMask.GetMask("Enemy")))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }


        else if (gameObject.GetComponent<Rigidbody2D>().IsTouchingLayers(LayerMask.GetMask("djinn")))
        {
            collision.gameObject.GetComponent<liveLine>().decrementHealth();
            Destroy(gameObject);
            if (collision.gameObject.GetComponent<liveLine>().gethealth() <= 0)
            {
                collision.gameObject.GetComponent<liveLine>().destroyGin();
                
                SceneManager.LoadScene(0);
            }
        }

       else if(collision.GetType() == typeof(BoxCollider2D))
        {
            Destroy(collision.gameObject);
        }
        
        
    }




    // Update is called once per frame
    void Update () {
		
	}
}
