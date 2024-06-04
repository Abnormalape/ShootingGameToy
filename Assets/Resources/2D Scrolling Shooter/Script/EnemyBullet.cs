using System;
using UnityEngine;

class EnemyBullet : MonoBehaviour
{
    Rigidbody2D Rigidbody2D;
    private void OnEnable()
    {
    }
    float passedTime;
    private void Update()
    {
        passedTime = Time.deltaTime;
        if(passedTime > 5f) { Destroy(gameObject); }
    }
}
