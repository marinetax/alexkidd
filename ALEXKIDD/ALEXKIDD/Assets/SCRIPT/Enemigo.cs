using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{

    private float direction;

    void Start()
    {
        direction = 1;
    }


    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * direction * 0.9f);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (transform.rotation.y == 0.0f)
        {
            transform.rotation = new Quaternion(0.0f, 180.0f, 0.0f, 0.0f);

        }
        else
        {
            transform.rotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
        }
    }
}
