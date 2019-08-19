using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sinattack : MonoBehaviour {
    //code from unity forums
    public float MoveSpeed = 5.0f;

    public float frequency = 20.0f;  // Speed of sine movement
    public float magnitude = 0.5f;   // Size of sine movement
    private Vector3 axis;

    private Vector3 pos;

    void Start()
    {
        pos = transform.position;
        DestroyObject(gameObject, 3.0f);
        axis = transform.up;  // May or may not be the axis you want

    }

    void Update()
    {
        pos += transform.right * Time.deltaTime * MoveSpeed*-1;
        transform.position = pos + axis * Mathf.Sin(Time.time * frequency) * magnitude;
    }
}
