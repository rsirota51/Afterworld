using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SUPERATTACK : MonoBehaviour {

    public float MoveSpeed = 5.0f;

    public float frequency = 20.0f;  // Speed of sine movement
    public float magnitude = 0.5f;   // Size of sine movement
    public GameObject RotatingBalls;
    public int numberOfChildren = 3;
    public int speed = 2;
    public float radius = 3f;
    private Vector3 axis;

    private Vector3 pos;

    void Start()
    {
        pos = transform.position;
        DestroyObject(gameObject, 9.0f);
        axis = transform.up;  // May or may not be the axis you want
        for (int i = 0; i < numberOfChildren; i++)
            Instantiate(RotatingBalls, transform);

    }

    void Update()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            float angle = Time.time * speed + 2f * Mathf.PI * i / transform.childCount;
            child.localPosition = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0f) * radius;
        }
        pos += transform.right * Time.deltaTime * MoveSpeed * 1;
        transform.position = pos + axis * Mathf.Sin(Time.time * frequency) * magnitude;
    }
}
