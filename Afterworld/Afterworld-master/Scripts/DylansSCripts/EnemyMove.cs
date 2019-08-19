using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    private bool move;
    public Transform Player;
   public int MoveSpeed = 4;
   public int MaxDist = 10;
    public int MinDist = 5;
    private Vector3 smoothVelocity =  new Vector3(-3f,0f,0f);
    public float smoothTime = 10.0f;
    float randy;
    // Use this for initialization
    void Start()
    {
        move = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            move = true;

        }
    }
    // Update is called once per frame
    void Update()
    {
        randy = Random.Range(1,100);
        if (Vector3.Distance(transform.position, Player.position) <= MaxDist/*&& Vector3.Distance(transform.position, Player.position)>=MinDist*/)
        {
            //transform.LookAt(Player);
            transform.position = Vector3.SmoothDamp(transform.position, Player.position, ref smoothVelocity, smoothTime);
        }
       /* else if(Vector3.Distance(transform.position, Player.position) <MinDist)
        {
            transform.position = Vector3.SmoothDamp(transform.position, transform.position+new Vector3(3f,3f,0f), ref smoothVelocity, smoothTime);
        }*/
    }
}
