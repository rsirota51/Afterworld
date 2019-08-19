using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBOSS : MonoBehaviour
{
    public float jumpforce = 3f;
    public Transform Player;
    public int MaxDist = 10;
    public int cooldown = 100;
    public int cooldownspeed = 1;
    public bool FINALFORM = false;
    public int numberOfChildren = 10;
    public GameObject obj;
    public float speed = 3f;
    public float radius = 3f;
    private bool shrink = true;
    private int childlimit = 0;
    public bool s1 = false;
    public GameObject sinballs;
    public float spawnTime = 3;
    public GameObject Bossgun;
    public int health = 10;
    // Use this for initialization

    void Start()
    {
        for (int i = 0; i < numberOfChildren; i++)
            Instantiate(obj, transform);
        startFire();
        //Instantiate(sinballs, transform.position, transform.rotation);
    }

    public void startFire()
    {
        //InvokeRepeating("Fire", spawnTime, spawnTime);
    }
    void Fire()
    {
        // Instantiate(sinballs, transform.position, transform.rotation);
    }
    // Update is called once per frame
    void Update()
    {
        // Instantiate(sinballs, transform.position, transform.rotation);
        if (Vector3.Distance(transform.position, Player.position) <= MaxDist)
        {
            transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), Player.position, Time.deltaTime);
            if (cooldown >= 100)
            {
                cooldown = 0;
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 300f));
            }
            else
            {
                cooldown += cooldownspeed;
            }
            if (s1)
            {
                for (int i = 0; i < transform.childCount; i++)
                {
                    Transform child = transform.GetChild(i);
                    float angle = Time.time * speed + 2f * Mathf.PI * i / transform.childCount;
                    child.localPosition = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0f) * radius;
                }
            }
            //stage2();
            //stage1();
        }



    }
    void stage1()
    {
        for (int i = 0; i < numberOfChildren; i++)
            Instantiate(obj, transform);
    }
    void stage2()
    {

        if (radius < 5 && shrink)
        {
            radius += .1f;
        }
        else if (radius > 0) { radius -= .1f; shrink = false; }
        else { shrink = true; }
    }
}