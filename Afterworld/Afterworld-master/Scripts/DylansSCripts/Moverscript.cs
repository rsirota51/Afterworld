using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moverscript : MonoBehaviour {
    public float jumpforce=3f;
    public Transform Player;
    public int MaxDist = 10;
    public int cooldown = 100;
    public int cooldownspeed = 1;
    public bool FINALFORM = false;
    public int numberOfChildren = 1;
    // Use this for initialization
    void Start () {
       
    }
   
    // Update is called once per frame
    void Update () {
       
        if (Vector3.Distance(transform.position, Player.position) <= MaxDist)
        {
            transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y),Player.position, Time.deltaTime);
            if (cooldown >= 100)
            {
                cooldown = 0;
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 300f));
            }
            else
                    {
                cooldown+=cooldownspeed;
            }
           
            
        }

    }
}
