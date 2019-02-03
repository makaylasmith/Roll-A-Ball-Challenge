using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wall2 : MonoBehaviour
{
    Vector3 pointA = new Vector3(-3.5f, 0.0f, 4.5f);
    Vector3 pointB = new Vector3(-3.5f, 0.0f, -6.3f);
    public float speed;

    void Update()
    {
        transform.position = Vector3.Lerp(pointA, pointB, Mathf.PingPong(Time.time * speed, 1.0f));
    }

}
