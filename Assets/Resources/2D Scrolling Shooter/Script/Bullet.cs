using System;
using Unity.VisualScripting;
using UnityEngine;
class Bullet : MonoBehaviour
{
    float time;
    Rigidbody2D rb;

    private void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        time = time + Time.deltaTime;
        if(time > 2f)
        {
            Destroy(gameObject);
        }
        rb.velocity = Vector2.up *10f;
    }
}

