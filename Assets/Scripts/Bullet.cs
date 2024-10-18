using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed = 15f;
    private Rigidbody rb;

    private void OnEnable()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3 (0f,speed,0f);
    }

    void Update()
    {
        if (transform.position.y >= 10f)
        {
            rb.velocity = Vector3.zero;
            transform.position = new Vector3(-10f, -.5f, 0f);
            this.GetComponent<Bullet>().enabled = false;
        }
    }
}
