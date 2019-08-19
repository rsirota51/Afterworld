using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cranecode : MonoBehaviour {
    public Transform Player;
    private Transform old;
    public float cooldown = 50;
    private bool crashed = true;
	// Use this for initialization
	void Start () {
        old = transform;
	}
    private void OnTrigger(Collider2D collision)
    {
        crashed = false;
        Vector3 p = transform.position;
        p.y += 50f;
    }

    // Update is called once per frame
    void Update()
    {
        if ((transform.position.x < Player.transform.position.x - 3f || transform.position.x < Player.transform.position.x + 3f))
        {
            //Debug.Log("Hello");
            if (cooldown > 400&&crashed)
            {
                cooldown = 0;
                
                transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), new Vector2(old.position.x, 0f), 200 * Time.deltaTime);
                
            }
            else
      
            {
                transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), new Vector2(old.position.x,old.position.y ), 200 * Time.deltaTime);
                cooldown++;
            }
        }
        cooldown++;
    }
        
            
           
        
    
}
