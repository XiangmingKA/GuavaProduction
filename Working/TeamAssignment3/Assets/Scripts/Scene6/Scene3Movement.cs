using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene3Movement : MonoBehaviour
{
    public float speed = 2.0f;
    public static bool movable;
    void Start()
    {
        movable = false;
    }
    void Update()
    {
        if (movable && transform.position.x >= -15.7)
        {
            transform.position -= transform.right * speed * Time.deltaTime;
        }

    }
}
